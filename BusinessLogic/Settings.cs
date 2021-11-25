using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Settings : CommonSettings.Settings
	{
		public class LoggedUser : CommonSettings.Settings.LoggedUser
		{
			//public LoggedUser(string token = null)
			//{
			//	var result = Services.TokenService.GetDataFromToken(token);
			//	this.Name = result.Name;
			//	this.Role = result.Role;

			//}

		}


	}
}
