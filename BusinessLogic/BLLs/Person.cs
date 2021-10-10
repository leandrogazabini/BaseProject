using BusinessLogic.Interfaces;
using DllModels.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLLs
{
	public class Person : DllModels.Models.PersonModel, IBaseInterface
	{
		Responses.Response IBaseInterface.dbCreate(Object obj)
		{
			var result = new Responses();
			try
			{
				var person = (Person)obj;
			}
			catch
			{
				return result.Error(message: $"Object is not a Person");
			}

			if (!HasErrorObject)
			{
				return result.Error(message: $"Validation rules have {ErrorList.Count()} error(s).",
									reference: $"{String.Join("|", ErrorList)}");
			}


			return result.Success(message: $"Person created",
								  reference: $"UUID: {this.Uuid}");
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
