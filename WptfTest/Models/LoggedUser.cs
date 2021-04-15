using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WptfTest.Models
{
	class LoggedUser : BaseClass
	{
		public string UserName = String.Empty;

		public bool canExecuteMainView = true;
		public bool canExecuteTestView= false;
	}
}
