using System;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CommonSettings
{
	public class Settings
	{
		public readonly JwtSettings _jwtSettings;
		public readonly CultureSetting _cultureSetting;


		public Settings()
		{
			_jwtSettings = new JwtSettings();
			_cultureSetting = new CultureSetting();
		}


		public class JwtSettings
		{
			private string JwtKey = "fedaf7d8863b48e197b9287d492b708e!";
			public string GetJwtKey()
			{
				return JwtKey;
			}
		}


		public class CultureSetting
		{
			public CultureInfo CurrentCultureInfo { get; set; }
			public string CurrentCultureInfoString { get; set; }
			public List<KeyValuePair<int, CultureInfo>> SupportedCultures { get; set; }
			public CultureSetting(bool configureCultureToDefault = true)
			{
				//Culture = new CultureSetting();
				//SupportedCultures  = new string[] { "en-US", "pt-BR" };
				SupportedCultures = new List<KeyValuePair<int, CultureInfo>>()
				{
					new KeyValuePair<int, CultureInfo>(1, new CultureInfo("en-US") ),
					new KeyValuePair<int, CultureInfo>(2, new CultureInfo("pt-BR") )
				};

				if (configureCultureToDefault)
				{
					SetCurrentCulture(SupportedCultures.FirstOrDefault(x => x.Key == 1).Key);
				}
				GetCurrentCulture();




			}
			public CultureInfo FindSupportedCulture(int choice)
			{
				return SupportedCultures.SingleOrDefault(x => x.Key == choice).Value;
			}

			public List<KeyValuePair<int, CultureInfo>> ListAllSupportedCulture()
			{
				return SupportedCultures;
			}

			public bool SetCurrentCulture(int cultureInfoChoice)
			{
				try
				{
					var cultureInfo = FindSupportedCulture(cultureInfoChoice);
					CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
					CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

					CurrentCultureInfoString = cultureInfo.ToString();
					return true;
				}
				catch (Exception)
				{

					return false;
				}
				//var cultureInfo = new CultureInfo(_cultureInfo.Name);

			}

			public string GetCurrentCulture()
			{
				CurrentCultureInfo = System.Globalization.CultureInfo.CurrentCulture;
				CurrentCultureInfoString = CurrentCultureInfo.ToString();
				return CurrentCultureInfoString;
			}
		}

	}
}
