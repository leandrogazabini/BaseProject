using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllModels.Models.Util;


namespace BusinessLogic.Interfaces
{
	public interface IBaseInterface
	{
		public DefaultResponses.Response dbCreateOne(Object obj = null);
		//public Responses.Response dbCreate(Object obj);
		public DefaultResponses.Response dbReadOne(string guid = null);
		public DefaultResponses.Response dbUpdateOne(Object obj);
		public bool dbIsActive(int id);
		//public Responses.Response dbUpdate();
		//public Responses.Response dbDelete();
		//public Responses.Response dbDeleteFull();
	}
}
