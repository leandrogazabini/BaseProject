using DllModels.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IUserRepository : IBaseInterface
	{
		public Responses.Response dbCreate(Object obj = null);
		//public Responses.Response dbCreate(Object obj);
		public Responses.Response dbRead(string guid = null);

		//public Responses.Response dbUpdate();
		//public Responses.Response dbDelete();
		//public Responses.Response dbDeleteFull();
	}
}

