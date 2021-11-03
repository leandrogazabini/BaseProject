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
		public Responses.Response dbCreate(object obj = null)
		{
			throw new NotImplementedException();
		}

		public Responses.Response dbRead(string guid = null)
		{
			throw new NotImplementedException();
		}
	}

}
