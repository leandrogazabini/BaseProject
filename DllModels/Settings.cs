using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels
{
	public class Settings
	{
		public class CultureSettings
		{
			public static CultureInfo ActualCultureInfo
			{
				get
				{
					var cs = new CommonSettings.CultureSettings();
					return cs.GetCultureInfo();
				}
				protected set {; }
			}

			public CultureSettings()
			{
				var cs = new CommonSettings.CultureSettings();
				ActualCultureInfo = cs.GetCultureInfo();
			}
		}

	}
}
