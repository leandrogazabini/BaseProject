using System;
using System.ComponentModel;
using DllModels;
using DllDatabase;
using BusinessLogic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using DllModels;
using System.Collections.Generic;
using DllModels.Models;
using System.Reflection;
using KellermanSoftware.CompareNetObjects;

namespace ConsoleTest
{
	
		class Program
	{

		
		public static string Compare(object obj1, object obj2, string path = "")
		{
			string path1 = string.IsNullOrEmpty(path) ? "" : path + ": ";
			if (obj1 == null && obj2 != null)
				return path1 + "null != not null";
			else if (obj2 == null && obj1 != null)
				return path1 + "not null != null";
			else if (obj1 == null && obj2 == null)
				return null;

			if (!obj1.GetType().Equals(obj2.GetType()))
				return "different types: " + obj1.GetType() + " and " + obj2.GetType();

			Type type = obj1.GetType();
			if (path == "")
				path = type.Name;

			if (type.IsPrimitive || typeof(string).Equals(type))
			{
				if (!obj1.Equals(obj2))
					return path1 + "'" + obj1 + "' != '" + obj2 + "'";
				return null;
			}
			if (type.IsArray)
			{
				Array first = obj1 as Array;
				Array second = obj2 as Array;
				if (first.Length != second.Length)
					return path1 + "array size differs (" + first.Length + " vs " + second.Length + ")";

				var en = first.GetEnumerator();
				int i = 0;
				while (en.MoveNext())
				{
					string res = Compare(en.Current, second.GetValue(i), path);
					if (res != null)
						return res + " (Index " + i + ")";
					i++;
				}
			}
			else if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
			{
				System.Collections.IEnumerable first = obj1 as System.Collections.IEnumerable;
				System.Collections.IEnumerable second = obj2 as System.Collections.IEnumerable;

				var en = first.GetEnumerator();
				var en2 = second.GetEnumerator();
				int i = 0;
				while (en.MoveNext())
				{
					if (!en2.MoveNext())
						return path + ": enumerable size differs";

					string res = Compare(en.Current, en2.Current, path);
					if (res != null)
						return res + " (Index " + i + ")";
					i++;
				}
			}
			else
			{
				foreach (PropertyInfo pi in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
				{
					try
					{
						var val = pi.GetValue(obj1);
						var tval = pi.GetValue(obj2);
						if (path.EndsWith("." + pi.Name))
							return null;
						var pathNew = (path.Length == 0 ? "" : path + ".") + pi.Name;
						string res = Compare(val, tval, pathNew);
						if (res != null)
							return res;
					}
					catch (TargetParameterCountException)
					{
						//index property
					}
				}
				foreach (FieldInfo fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
				{
					var val = fi.GetValue(obj1);
					var tval = fi.GetValue(obj2);
					if (path.EndsWith("." + fi.Name))
						return null;
					var pathNew = (path.Length == 0 ? "" : path + ".") + fi.Name;
					string res = Compare(val, tval, pathNew);
					if (res != null)
						return res;
				}
			}
			return null;
		}

		static void Main(string[] args)
		{

			////dont erase it
			//var bllCtx = new BusinessLogic.Methods();

			//var modelObjectTest = new DllModels.Models.ObjectTest();
			//var validator = new DllModels.Models.ModelsValidators.ObjectTestValidator();

			//var modelPerson = new DllModels.Models.Person();


			//var q = bllCtx.ConnectDb();
			//var Person = new DllModels.Models.Person();

			//var qResult = bllCtx.FindPersonByName("Leandro Prandini Gazabini");
			//Console.WriteLine($"Pessoa localizada. Id: {(qResult.PersonId).ToString()}");


			//Person.CreatePerson(OficialName: "Leandro Prandini Gazabini",
			//						AlternativeName: "Liandru",
			//						Nickname: "Leee!" + DateTime.Now,
			//						MainDocumentNumber: "1234",
			//						AlternativeDocumentNumber: "456");
			//var qResult2 = bllCtx.AddPersonAsync(Person);
			//Console.WriteLine($"Pessoa salva no banco: {(Person.PersonId).ToString()}");



			CompareLogic compareLogic = new CompareLogic();

			var list1 = new List<string> { "a", "b", "c" };
			var list2 = new List<string> { "a", "b", "c" };
			var list3 = new List<string> { "d", "f", "g" };
			var list4 = new List<string> { "d", "f", "g" };
			var MainList1 = new List<List<String>>();
			var MainList2 = new List<List<String>>();
			MainList1.Add(list1);
			MainList1.Add(list2);
			MainList2.Add(list3);
			MainList2.Add(list4);

			//Console.WriteLine("main list 1 e 2: " + Compare(list1, list2).ToString());

			ComparisonResult result = compareLogic.Compare(MainList1, MainList2);
			Console.WriteLine(result.AreEqual.ToString());
	
		}
	}
}
