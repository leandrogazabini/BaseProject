	using BusinessLogic.Interfaces;
using DllModels.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllDatabase;
using System.Threading;

namespace BusinessLogic.BLLs
{
	public class Person : DllDatabase.Models.Person, IPersonRepository
	{
		public Responses.Response dbCreate(Object obj = null)
		{
			obj = obj ?? this;
			var result = new Responses();
			Person person;
			try
			{
				// verifying the type of object
				try
				{
					person = (Person)obj;
					person.ValidateObject();
				}
				catch
				{
					return result.ReturnError(message: "001",
											  reference: $"Expected: {this.GetType()}.");
				}

				if (person.HasErrorObject)
				{
					return result.ReturnError(message: "002",
											  reference: $"{String.Join(" | ", person.ErrorList)}");
				}

				//data base validation start
				using (var db = new DllDatabase.AppDbContext())
				{
					//is this new item?
					if (person.Id != 0)
					{
						return result.ReturnError(message: "004",
												  reference: $"Person GUID: {person.GUID}");
					}
					//main doc exists?
					var verify = db.tbPerson.Where(p => p.MainDocumentNumber == person.MainDocumentNumber
													 && p.DeletedAt.Equals(null));
					if (db.tbPerson.Where(p => p.MainDocumentNumber == person.MainDocumentNumber).Any())
					{
						return result.ReturnError(message: "005",
												  reference: $"{nameof(this.MainDocumentNumber)}");
					}

					else
					{
						try // try access data base
						{
							//db.ConfigureDb1String(forceCreateFile: true, forceCreateFolder: true);
							person.CreatedAt = DateTime.Now;
							var t = db.tbPerson.Add(person);
							var dbResult = db.SaveChangesAsync().Wait(5000);
						}
						catch (Exception ex)
						{
							return result.ReturnError(message: $"Database Error.",
													  reference: $"{ex.ToString()}");
						}
					}

					//data base validation end
				}
				//Success
				return result.ReturnSuccess(message: "003",
											reference: $"Person GUID: {person.GUID}");
			}
			//Generic Error
			catch (Exception ex)
			{
				return result.ReturnError(message: "999",
										  reference: $"{ex.ToString()}");
			}
		}

		public Responses.Response dbRead(string guid = null)
		{
			var result = new Responses();
			Person resultPerson = null;
			try
			{
				if (!String.IsNullOrEmpty(guid))
				{
					using (var db = new DllDatabase.AppDbContext())
					{
						var qResult = db.tbPerson.Where(p => p.GUID == guid.ToString()).FirstOrDefault() ?? null;
						bool isNull = qResult == null;
						if (!isNull)
						{
							resultPerson = new Person()
							{
								OfficialName = qResult.OfficialName,
								AlternativeName = qResult.AlternativeName,
								PersonLegalKind = qResult.PersonLegalKind,
								MainDocumentNumber = qResult.MainDocumentNumber,
								SecondDocumentNumber = qResult.SecondDocumentNumber
							};
							return result.ReturnSuccess(message: "00",
													  reference: $"{guid}",
													  obj: resultPerson);
						}
					}
				}
				return result.ReturnError(message: "99",
										  reference: $"GUID invalid: {guid}.");
			}
			catch (Exception ex)
			{
				return result.ReturnError(message: "999",
										  reference: $"{ex.ToString()}");
			}


		}
	}


}