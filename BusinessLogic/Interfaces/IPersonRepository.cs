using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllDatabase.Models;
using DllModels.Models.Util;


namespace BusinessLogic.Interfaces
{
	public interface IPersonRepository : IBaseInterface
	{
		public Responses.Response dbCreate(Object obj = null);
		//public Responses.Response dbCreate(Object obj);
		public Responses.Response dbRead();
		public Responses.Response dbUpdate();
		public Responses.Response dbDelete();
		public Responses.Response dbDeleteFull();
	}
}
