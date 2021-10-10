using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllModels.Models.Util;


namespace BusinessLogic.Interfaces
{
	interface IBaseInterface
	{
		Responses.Response dbCreate(Object obj);
		Responses.Response dbRead();
		Responses.Response dbUpdate();
		Responses.Response dbDelete();
		Responses.Response dbDeleteFull();
	}
}
