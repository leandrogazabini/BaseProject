using BusinessLogic.Interfaces;
using DllModels.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllDatabase;

namespace BusinessLogic.BLLs
{
	public class Person : DllDatabase.Models.Person, IBaseInterface
	{
		
		public Responses.Response dbCreate(Object obj = null)
		{
			var result = new Responses();
			Person person = null;
			
			try
			{
				obj = obj ?? this;
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

				using (var db = new DllDatabase.DbContext())
				{
					db.ConfigureDbString(forceCreateFile: true, forceCreateFolder: true);
					person.CreatedAt = DateTime.Now;
					var teste = db.tbPerson.Add(person);
					db.SaveChanges();
				}
				return result.ReturnSuccess(message: result.getDefaultMessages("003"),
									  reference: $"Person UUID: {person.Uuid}");
			}
			catch (Exception ex)
			{
				return result.ReturnError(message: $"Unexpected error occurred.",
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
