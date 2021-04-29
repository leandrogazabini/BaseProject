using System;
using System.ComponentModel;
using DllModels;
using DllDatabase;
using BusinessLogic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;
using DllModels.Models;
using System.Reflection;
using KellermanSoftware.CompareNetObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConsoleTest
{
	
		class Program
	{

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



			//CompareLogic compareLogic = new CompareLogic();

			//var list1 = new List<string> { "a", "b", "c" };
			//var list2 = new List<string> { "a", "b", "c" };
			//var list3 = new List<string> { "d", "f", "g" };
			//var list4 = new List<string> { "d", "f", "g" };
			//var MainList1 = new List<List<String>>();
			//var MainList2 = new List<List<String>>();
			//MainList1.Add(list1);
			//MainList1.Add(list2);
			//MainList2.Add(list3);
			//MainList2.Add(list4);


			//ComparisonResult result = compareLogic.Compare(MainList1, MainList2);
			//Console.WriteLine(result.AreEqual.ToString());

			//var bllCtx = new BusinessLogic.Methods();
			//bllCtx.ConnectDb();

			//var list1 = new List<Person>();
		
			//var np = new PersonNatural();
			var p = new Person();
			p.PersonLegalKind = Person.PersonLegalKindEnum.Natural;
			//p.PersonLegalKind = Person.PersonLegalKindEnum.Empty;
			_ = p;
			//list1.Add(np);



		}
	}
}
