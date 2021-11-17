
using BusinessLogic.BLLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonSettings;
using System.Resources;
using System.Threading;
using System.Globalization;

namespace ConsoleApp
{

	class Program
	{
		public static Settings AppSettings;
		static void Main(string[] args)
		{
			AppSettings = new Settings();
			var bll = new BusinessLogic.Default.ResponsesMessages.DefaultResponses();

			Console.BackgroundColor = ConsoleColor.Green;
			Console.ForegroundColor = ConsoleColor.Black;

			foreach (var item in AppSettings._cultureSetting.ListAllSupportedCulture())
			{
				Console.WriteLine($"{item.Key} - {item.Value}");
			}
			

			Console.WriteLine(AppSettings._cultureSetting.GetCurrentCulture());
			Console.WriteLine(bll.ReturnError().Message);

			AppSettings._cultureSetting.SetCurrentCulture(2);
			Console.WriteLine(AppSettings._cultureSetting.GetCurrentCulture());
			Console.WriteLine(bll.ReturnError().Message);

			AppSettings._cultureSetting.SetCurrentCulture(1);
			Console.WriteLine(AppSettings._cultureSetting.GetCurrentCulture());
			Console.WriteLine(bll.ReturnError().Message);


			//settings._cultureSetting.SetCurrentCulture("en-US");





		}
	}

	public class UtilConsole
	{
		private static Random random = new Random();
		public string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}
		public string RandomMainDocTest()
		{
			//string[] docs = { "@"," ", "*", "_", "!","💤" };
			string[] docs = { "" };
			var r = new Random();
			int x = r.Next(0, docs.Count());
			return docs[x];
		}
	}
}
