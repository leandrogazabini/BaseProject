using System;
using System.Linq;
using DllDatabase;
using DllModels;
using DllModels.Models;

namespace BusinessLogic
{


	public class Methods
	{

		#region DB1 CONFIG

		private DbContext ctxDb1 { get; set; } = new DbContext();
		private string Db1fileName { get; set; } = "banco.db";
		private string Db1fileFullPath { get; set; } = @"D:\fontes\BaseSolution\BaseProject\Database\SQLite";

		public string SetxDb1fileName(string fileName)
		{
			Db1fileName = Db1fileName;
			return Db1fileName;

		}
		public string SetDb1fileFullPath(string fileFullPath)
		{
			Db1fileFullPath = fileFullPath;
			return Db1fileFullPath;

		}
		public bool ConnectDb()
		{
			var isConnectionOk = ctxDb1.ConfigureDbString(fileName: Db1fileName,
												  fileFullPath: Db1fileFullPath,
												  forceCreateFolder: false,
												  forceCreateFile: false);
			return isConnectionOk;
		}

		#endregion

		#region PERSON METHODS
		public object AddPersonAsync(DllModels.Models.Person person)
		{

			//var x = ConnectDb();
			ctxDb1.dbPerson.Add(person);
			ctxDb1.SaveChangesAsync();
			return person;


		}

		public Person FindPersonByName(string name)
		{

			var result = ctxDb1.dbPerson.Where(p => p.OficialName == name).FirstOrDefault();
			return result;
		}
		#endregion
	}
}
