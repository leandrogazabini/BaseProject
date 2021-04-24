using System;
using System.ComponentModel;
using DllModels;
using DllDatabase;
using BusinessLogic;
using System.Collections.ObjectModel;

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

			var obc1 = new ObservableCollection<int>();
			Console.WriteLine(obc1.GetHashCode());
			obc1.Add(1);
			Console.WriteLine(obc1.GetHashCode());
			obc1.Add(1);
			Console.WriteLine(obc1.GetHashCode());
			obc1.Add(1);

		}
	}
}
