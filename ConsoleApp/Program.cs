
using BusinessLogic.BLLs;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{

	class Program
	{

		static void Main(string[] args)
		{

			////////dont erase it
			//////var bllCtx = new BusinessLogic.Methods();

			//////var modelObjectTest = new DllModels.Models.ObjectTest();
			//////var validator = new DllModels.Models.ModelsValidators.ObjectTestValidator();

			//////var modelPerson = new DllModels.Models.Person();


			//////var q = bllCtx.ConnectDb();
			//////var Person = new DllModels.Models.Person();

			//////var qResult = bllCtx.FindPersonByName("Leandro Prandini Gazabini");
			//////Console.WriteLine($"Pessoa localizada. Id: {(qResult.PersonId).ToString()}");


			//////Person.CreatePerson(OficialName: "Leandro Prandini Gazabini",
			//////						AlternativeName: "Liandru",
			//////						Nickname: "Leee!" + DateTime.Now,
			//////						MainDocumentNumber: "1234",
			//////						AlternativeDocumentNumber: "456");
			//////var qResult2 = bllCtx.AddPersonAsync(Person);
			//////Console.WriteLine($"Pessoa salva no banco: {(Person.PersonId).ToString()}");



			//////CompareLogic compareLogic = new CompareLogic();

			//////var list1 = new List<string> { "a", "b", "c" };
			//////var list2 = new List<string> { "a", "b", "c" };
			//////var list3 = new List<string> { "d", "f", "g" };
			//////var list4 = new List<string> { "d", "f", "g" };
			//////var MainList1 = new List<List<String>>();
			//////var MainList2 = new List<List<String>>();
			//////MainList1.Add(list1);
			//////MainList1.Add(list2);
			//////MainList2.Add(list3);
			//////MainList2.Add(list4);


			//////ComparisonResult result = compareLogic.Compare(MainList1, MainList2);
			//////Console.WriteLine(result.AreEqual.ToString());

			//var bllCtx = new BusinessLogic.Methods();
			//var x = bllCtx.ConnectDb();

			//////var list1 = new List<Person>();

			var testeBasePerson = new Person();
			testeBasePerson.OfficialName = "";
			testeBasePerson.AlternativeName = "123";
			testeBasePerson.MainDocumentNumber = "doc@@@@12";
			testeBasePerson.SecondDocumentNumber = "doc23";
			testeBasePerson.ValidateObject();
			if (testeBasePerson.IsValidObject && testeBasePerson.ErrorList.Count < 1)
			{
				_ = "ok";
			}
			else
			{
				_ = "Erro";
			}

			for (int i = 0; i < 222; i++)
			{
				Console.WriteLine($"-----------------  {i}  -----------------");
				testeBasePerson = new Person();
				testeBasePerson.OfficialName = "123";
				testeBasePerson.AlternativeName = "123";
				testeBasePerson.MainDocumentNumber = "doc12@";
				testeBasePerson.SecondDocumentNumber = "doc23";
				testeBasePerson.ValidateObject();
				var result = testeBasePerson.dbCreate();
				Console.WriteLine(result.ResponseStatus);
				Console.WriteLine(result.ResponseMessage);
				Console.WriteLine(result.Reference);
			}

			//var testeJuridicalPerson = new Person(Person.PersonLegalKindEnum.Juridical);
			//testeJuridicalPerson.MainDocumentNumber = "456";
			//testeJuridicalPerson.SecondDocumentNumber = "456";
			//testeJuridicalPerson.OficialName = "liandro";
			//testeJuridicalPerson.AlternativeName = "gz";
			//if (testeJuridicalPerson.IsValid && testeJuridicalPerson.ErrorList.Count < 1)
			//{
			//	_ = "ok";
			//}
			//else
			//{
			//	_ = "Erro";
			//}


			//teste.AdressList.Add(new Adress { FullAdress = "ad 1 here"});
			//teste.AdressList.Add(new Adress { FullAdress = "ad 2 here" });


			//var qResult2 = bllCtx.AddPersonAsync(teste);
			//Console.WriteLine($"Pessoa salva no banco: {(teste.PersonId).ToString()}");
			//var qResult = bllCtx.FindPersonById(teste.PersonId);
			//qResult.OficialName = "troquei";
			//_ = bllCtx.ChangeDataPerson(qResult);


		}



	}
}
