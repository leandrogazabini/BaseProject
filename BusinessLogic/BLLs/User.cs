using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
//using DllModels.Models.Util;
using DefaultResponses = BusinessLogic.Default.ResponsesMessages.DefaultResponses;



namespace BusinessLogic.BLLs
{
	public class User : DllDatabase.Models.User, IUserRepository
	{
		public DefaultResponses.Response dbCreateOne(object obj = null)
		{
			throw new NotImplementedException();
		}

		public bool dbIsActive(int id)
		{
			throw new NotImplementedException();
		}

		public DefaultResponses.Response dbReadOne(string guid = null)
		{
			throw new NotImplementedException();
		}

		DefaultResponses.Response IBaseInterface.dbUpdateOne(object obj)
		{
			throw new NotImplementedException();
		}
	}

}
