using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DllModels.Models.Util;

namespace BusinessLogic.BLLs
{
	public class User : DllDatabase.Models.User, IUserRepository
	{
		public DefaultResponses.Response dbCreateOne(object obj = null)
		{
			throw new NotImplementedException();
		}

		public bool dbIsActive(object obj = null)
		{
			throw new NotImplementedException();
		}

		public DefaultResponses.Response dbReadOne(string guid = null)
		{
			throw new NotImplementedException();
		}

	}

}
