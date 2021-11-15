using System;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace CommonSettings
{
	public class CultureSettings
	{
		private CultureSetting Culture { get; set; }		
		public class CultureSetting
		{
			public CultureInfo CurrentCultureInfo { get; set; }
			public string Current { get; set; }
			public string[] Options { get; set; }
		}


		public CultureSettings(bool configureCultureToDefault = false)
		{
			this.Culture = new CultureSetting();
			Culture.Options = new string[] { "en-US", "pt-BR" };
			GetCurrentCulture();
			if (configureCultureToDefault)
			{
				SetCurrentCulture(Culture.Options[0]);
			}
		}

		public void SetCurrentCulture(string cultureInfo)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfo);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);
			Culture.Current = cultureInfo;
		}


		public string GetCurrentCulture()
		{
			this.Culture.Current =  System.Globalization.CultureInfo.CurrentCulture.ToString();
			return this.Culture.Current;
		}
		public CultureInfo GetCultureInfo()
		{
			var result = System.Globalization.CultureInfo.CurrentCulture;
			return result;
		}

	}
}
