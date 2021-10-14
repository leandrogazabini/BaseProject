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
	public class Person : DllDatabase.Models.Person, IBaseInterface
	{

		public Responses.Response dbCreate(Object obj = null)
		{
			var result = new Responses();
			Person person = null;
			obj = obj ?? this;
			try
			{
				// verifying the type of object
				try
				{
					person = (Person)obj;
				}
				catch
				{
					return result.ReturnError(message: result.getDefaultMessages("001"),
											  reference: $"Expected: {this.GetType()}.");
				}

				if (HasErrorObject)
				{
					return result.ReturnError(message: result.getDefaultMessages("002"),
											  reference: $"{String.Join(" | " + Environment.NewLine, ErrorList)}");
				}
				//data base validation start
				using (var db = new DllDatabase.DbContext())
				{
					//is this new item?
					if (person.PersonId != 0)
					{
						return result.ReturnError(message: result.getDefaultMessages("004"),
													  reference: $"Person UUID: {person.Uuid}");
					}
					else
					{
						try
						{
							db.ConfigureDb1String(forceCreateFile: true, forceCreateFolder: true);
							person.CreatedAt = DateTime.Now;
							db.tbPerson.Add(person);
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
				return result.ReturnSuccess(message: result.getDefaultMessages("003"),
											reference: $"Person UUID: {person.Uuid}");
			}
			//Generic Error
			catch (Exception ex)
			{
				return result.ReturnError(message: result.getDefaultMessages("999"),
										  reference: $"{ex.ToString()}");
			}
		}

		Responses.Response IBaseInterface.dbDelete()
		{
			throw new NotImplementedException();
		}

		Responses.Response IBaseInterface.dbDeleteFull()
		{
			throw new NotImplementedException();
		}

		Responses.Response IBaseInterface.dbRead()
		{
			throw new NotImplementedException();
		}

		Responses.Response IBaseInterface.dbUpdate()
		{
			throw new NotImplementedException();
		}
	}
}
