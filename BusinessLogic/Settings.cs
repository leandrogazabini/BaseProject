using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public static class Settings
	{
		public static string JwtKey = "fedaf7d8863b48e197b9287d492b708e!";

		public static CultureInfo ActualCultureInfo
		{
			get
			{
				var cs = new CommonSettings.CultureSettings();
				return cs.GetCultureInfo();
			}
			set {; }
		}


		//}
		//


	}
}
