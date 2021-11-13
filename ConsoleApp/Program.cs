
using BusinessLogic.BLLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{

	class Program
	{
		static void Main(string[] args)
		{
			var t = new UtilConsole();
			var person = new Person();
			person.OfficialName = "";
			person.AlternativeName = "123";
			person.MainDocumentNumber = "doc@@@@12";
			person.SecondDocumentNumber = "doc23";
			person.ValidateObject();
			if (person.IsValidObject)
			{
				_ = "ok";
			}
			else
			{
				_ = "Erro";
			}

			for (int i = 0; i < 1000; i++)
			{
				Console.WriteLine($"START:-----------------  {i}  -----------------");
				person = new Person()
				{
					OfficialName = t.RandomString(i),
					AlternativeName = t.RandomString(i),
					MainDocumentNumber = t.RandomString(i) + t.RandomMainDocTest(),
					SecondDocumentNumber = t.RandomString(i)
				};
				person.ValidateObject();

				Console.WriteLine("     OfficialName:" + person.OfficialName);
				Console.WriteLine("     AlternativeName:" + person.AlternativeName);
				Console.WriteLine("     MainDocumentNumber:" + person.MainDocumentNumber);
				Console.WriteLine("     SecondDocumentNumber:" + person.SecondDocumentNumber);
				
				var result = person.dbCreateOne();
				
				Console.WriteLine(result.ResponseStatus);
				Console.WriteLine(result.ResponseMessage);
				Console.WriteLine(result.ReferenceMessage);

				//System.Threading.Thread.Sleep(3000);
				//Console.ReadLine();

				Console.WriteLine($"  END:-----------------  {i}  -----------------");
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
			}
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
