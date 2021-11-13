using BusinessLogic.Interfaces;
using DllModels.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllDatabase;
using System.Threading;
using AutoMapper;

namespace BusinessLogic.BLLs
{
	public class Person : DllDatabase.Models.Person, IPersonRepository
	{
		public DefaultResponses.Response dbCreateOne(Object objCreate = null)
		{
			objCreate = objCreate ?? this;
			var result = new DefaultResponses();
			Person person;
			try
			{
				try
				{
					person = (Person)objCreate;
				}
				catch
				{
					return result.ReturnError(message: "001", reference: $"Expected: {this.GetType().Name}.");
				}

				if (!person.ValidateObject())
				{
					return result.ReturnError(message: "002", reference: $"{String.Join(" | ", person.ErrorList)}");
				}

				using (var db = new DllDatabase.AppDbContext())
				{
					if (!IsThisNewItem(person))
					{
						return result.ReturnError(message: "004", reference: $"Person GUID: {person.GUID}");
					}

					if (dbIsActive(person.Id))
					{
						if (dbMainDocExists(person.MainDocumentNumber))
						{
							return result.ReturnError(message: "005", reference: $"{nameof(this.MainDocumentNumber)}");
						}
					}

					else
					{
						try // try rec data base
						{
							db.tbPerson.Add(person);
							person.SetCreatedAt(); ;
							db.SaveChangesAsync();
						}
						catch (Exception ex)
						{
							return result.ReturnError(message: $"Database Error.", reference: $"{ex.ToString()}");
						}
					}

				}
				var objOut = dbReadOne(person.GUID).ReferenceObject;
				//Success
				return result.ReturnSuccess(message: "003", reference: $"Person GUID: {person.GUID}", obj: objOut);
			}
			//Generic Error
			catch (Exception ex)
			{
				return result.ReturnError(message: "999", reference: $"{ex.ToString()}");
			}
		}

		public DefaultResponses.Response dbUpdateOne(Object objUpdate)
		{

			var result = new DefaultResponses();
			Person personDataUpdate;
			DllDatabase.Models.Person personDatabase;

			try
			{
				personDataUpdate = (Person)objUpdate;
				var qResult = this.dbReadOne(personDataUpdate.GUID);
				if (qResult.ResponseStatus == DefaultResponses.ResponseStatus.Error)
				{
					return qResult;
				}
				personDatabase = (DllDatabase.Models.Person)qResult.ReferenceObject;
				if (personDatabase.GUID != personDataUpdate.GUID) { return result.ReturnError(message: "007", reference: $" GUID: {personDataUpdate.GUID}"); }
			}
			catch (Exception ex)
			{
				return result.ReturnError(message: "001", reference: $"Expected: {this.GetType().Name}.");
			}
			try
			{
				{
					if (!personDataUpdate.ValidateObject())
					{
						return result.ReturnError(message: "002", reference: $"{String.Join(" | ", personDataUpdate.ErrorList)}");
					}

					using (var db = new DllDatabase.AppDbContext())
					{
						try // try rec data base
						{
							if (true)
							{
								personDatabase = db.tbPerson.Find(dbIsActive(personDatabase.GUID));
								var map = new Mapping.PersonMapping();
								//personToUpdate = map.MapToDbPerson(personDataUpdate);
								//personToUpdate = map._mapper.Map<DllDatabase.Models.Person>(personDataUpdate);
								map._mapper.Map<Person, DllDatabase.Models.Person>(personDataUpdate, personDatabase);
								personDatabase.SetChangedAt();
								////erro no mapping
								//asyncasd

								db.SaveChangesAsync();
							}
							else
							{ }
						}
						catch (Exception ex)
						{
							return result.ReturnError(message: $"Database Error.", reference: $"{ex.ToString()}");
						}
					}
					var objOut = dbReadOne(personDatabase.GUID).ReferenceObject;
					return result.ReturnSuccess(message: "008", reference: $"Person GUID: {personDatabase.GUID}", obj: objOut);
				}
			}
			catch (Exception ex)
			{
				return result.ReturnError(message: "999", reference: $"{ex.ToString()}");
			}
		}
		
		public DefaultResponses.Response dbReadOne(string guid = null)
		{
			var result = new DefaultResponses();
			Person resultPerson = new Person();
			try
			{
				if (!String.IsNullOrEmpty(guid))
				{
					using (var db = new DllDatabase.AppDbContext())
					{
						var qResult = db.tbPerson.Where(p => p.GUID == guid.ToString()).FirstOrDefault() ?? null;
						var map = new Mapping.PersonMapping();
						map._mapper.Map<DllDatabase.Models.Person, Person >(qResult, resultPerson);

						//resultPerson = map.MapToPerson(qResult);

						if (qResult != null)
						{
							
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


		public bool dbIsActive(int id)
		{
			if (id > 0 )
				using (var db = new DllDatabase.AppDbContext())
				{
					var check = db.tbPerson.Find(id);
					if (check.DeletedAt.HasValue) return false;
					else return true;
				}
			return false;
		}

		public int dbIsActive(string guid)
		{
			if (!String.IsNullOrEmpty(guid))
			{
				using (var db = new DllDatabase.AppDbContext())
				{
					var check = db.tbPerson.Where(x=>x.GUID == guid);
					if (check.Count() != 1) return 0;
					if (check.FirstOrDefault().DeletedAt.HasValue) return 0;
					else return check.FirstOrDefault().Id;
				}

			}
			else return 0;
		}


		private bool dbMainDocExists(string doc)
		{
			using (var db = new DllDatabase.AppDbContext())
			{
				var verify = db.tbPerson.Where(p => p.MainDocumentNumber == doc);
				if (verify.Any()) return true;
			}
			return false;
		}

		private bool IsThisNewItem(Person person)
		{
			if (person.Id != 0) return false;
			else return true;
		}

	}


}