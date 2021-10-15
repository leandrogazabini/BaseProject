﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
//using DllModels.Models;

namespace DllDatabase
{
	public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public AppDbContext()
		{
			var r = ConfigureDb1String(forceCreateFile: true, forceCreateFolder: true);
		}
		#region MAPPED CLASSES
		//classe que vai gerar o log de auditoria do banco de dados
		public DbSet<Audit> Audits { get; set; }

		//models
		//public DbSet<DllModels.Models.PersonNaturalDetails> tbPersonNaturalDetails { get; set; }
		public DbSet<Models.Person> tbPerson { get; set; }
		//public DbSet<DllModels.Models.Adress> tbAdress { get; set; }
		//public DbSet<DllModels.Models.ObjectTest> dbObjectTest { get; set; }

		#endregion

		#region AUDIT CONFIGURATION
		//https://www.meziantou.net/entity-framework-core-history-audit-table.htm

		public class AuditEntry
		{
			public AuditEntry(EntityEntry entry)
			{
				Entry = entry;
			}

			public EntityEntry Entry { get; }
			public string TableName { get; set; }
			public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
			public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
			public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
			public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

			public bool HasTemporaryProperties => TemporaryProperties.Any();

			public Audit ToAudit()
			{
				var audit = new Audit();
				audit.TableName = TableName;
				audit.DateTime = DateTime.Now;
				audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
				audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues); // In .NET Core 3.1+, you can use System.Text.Json instead of Json.NET
				audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
				audit.Username = "NoUsername";
				audit.Local = "NoLocal";
				audit.IP = "NoIpAdress";
				audit.GeoLocation = "NoGeoLocation";
				return audit;
			}
		}

		public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			var entriesList = ChangeTracker.Entries();
			var auditEntries = OnBeforeSaveChanges();
			foreach (var entry in entriesList.Where(x=>x.State != Microsoft.EntityFrameworkCore.EntityState.Unchanged ))
			{
				var obj = entry.Entity;
				PropertyInfo prop = obj.GetType().GetProperty("Version", BindingFlags.Public | BindingFlags.Instance);
				if (null != prop && prop.CanWrite)
				{
					int v = (int)prop.GetValue(obj)+1;
					prop.SetValue(obj, v, null);
				}
			}
			var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
			
			await OnAfterSaveChanges(auditEntries);
			return result;
		}


		private List<AuditEntry> OnBeforeSaveChanges()
		{
			ChangeTracker.DetectChanges();
			var auditEntries = new List<AuditEntry>();
			foreach (var entry in ChangeTracker.Entries())
			{

				if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
					continue;

				var auditEntry = new AuditEntry(entry);
				auditEntry.TableName = entry.Metadata.GetTableName(); // EF Core 3.1: entry.Metadata.GetTableName();
				auditEntries.Add(auditEntry);

				foreach (var property in entry.Properties)
				{
					// The following condition is ok with EF Core 2.2 onwards.
					// If you are using EF Core 2.1, you may need to change the following condition to support navigation properties: https://github.com/dotnet/efcore/issues/17700
					// if (property.IsTemporary || (entry.State == EntityState.Added && property.Metadata.IsForeignKey()))
					if (property.IsTemporary)
					{
						// value will be generated by the database, get the value after saving
						auditEntry.TemporaryProperties.Add(property);
						continue;
					}

					string propertyName = property.Metadata.Name;
					if (property.Metadata.IsPrimaryKey())
					{
						auditEntry.KeyValues[propertyName] = property.CurrentValue;
						continue;
					}

					switch (entry.State)
					{
						case EntityState.Added:
							auditEntry.NewValues[propertyName] = property.CurrentValue;
							break;

						case EntityState.Deleted:
							auditEntry.OldValues[propertyName] = property.OriginalValue;
							break;

						case EntityState.Modified:
							if (property.IsModified)
							{
								auditEntry.OldValues[propertyName] = property.OriginalValue;
								auditEntry.NewValues[propertyName] = property.CurrentValue;
							}
							break;
					}
				}
			}

			// Save audit entities that have all the modifications
			foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
			{
				Audits.Add(auditEntry.ToAudit());
			}

			// keep a list of entries where the value of some properties are unknown at this step
			return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
		}

		private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
		{
			if (auditEntries == null || auditEntries.Count == 0)
				return Task.CompletedTask;

			foreach (var auditEntry in auditEntries)
			{
				// Get the final value of the temporary properties
				foreach (var prop in auditEntry.TemporaryProperties)
				{
					if (prop.Metadata.IsPrimaryKey())
					{
						auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
					}
					else
					{
						auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
					}
				}
				// Save the Audit entry
				Audits.Add(auditEntry.ToAudit());
			}
			return SaveChangesAsync();
		}

		#endregion

		#region PRIVATE VARIABLES
		private string DatabaseLocation { get; set; }
		private string dbType { get; set; }
		#endregion

		#region PUBLIC METHODS
		public bool ConfigureDb1String(string fileFullPath = @"D:\sources\BaseSolution\BaseProject\Database\SQLite",
									  string fileName = @"banco.db",
									  bool forceCreateFolder = false,
									  bool forceCreateFile = false)

		{
			var config = new Configs.Config();
			fileFullPath = config.GetDb1fileFullPath();
			fileName = config.GetxDb1fileName();
			// se não informou o nome do arquivo, retorna falso.
			if (String.IsNullOrWhiteSpace(fileName))
			{
				return false;
			}
			else
			{
				// se existe nome de paste, acrescenta "\"
				if (!String.IsNullOrWhiteSpace(fileFullPath))
				{
					StringBuilder sb = new StringBuilder();
					sb.Append(fileFullPath);
					sb.Append(@"\");
					string strFP = sb.ToString();

					fileFullPath = strFP;
				}
				// guarda a localização do bando
				DatabaseLocation = fileFullPath + fileName;

				//verifica se existe o arquivo informado e a pasta
				var DatabaseLocationExists = File.Exists(DatabaseLocation);
				var fileFullPathExists = Directory.Exists(fileFullPath);

				//caso tenha que criar a pasta
				if (forceCreateFolder)
				{
					if (!fileFullPathExists) Directory.CreateDirectory(fileFullPath);
				}
				//caso tenha que criar pasta e banco e arquivo não existe.
				fileFullPathExists = Directory.Exists(fileFullPath);

				if (forceCreateFile && fileFullPathExists && !DatabaseLocationExists)
				{

					var result = Database.EnsureCreated();
					return result;
				}
				else
				{
					//DatabaseLocation = "";
					return DatabaseLocationExists;
				}
			}
		}

		public string GetDatabaseLocation()
		{
			return DatabaseLocation;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			dbType = "SqLite";
			if (dbType == "SqLite")
			{
				optionsBuilder.UseSqlite($@"Data Source={DatabaseLocation};");
			}
			else { }
		}



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Produto>().HasIndex(i => i.ProdutoSKU).IsUnique();
			//modelBuilder.Entity<Pedido>().Property(i => i.PedidoId).ValueGeneratedOnAdd();
		}
		#endregion

	}

}
