﻿//using BusinessLogic.BLLs;


//namespace BusinessLogic
//{


//	public class Methods
//	{

//		#region DB1 CONFIG

//		//private DbContext ctxDb1 { get; set; } = new DbContext();
//		private string Db1fileName { get; set; } = "banco.db";
//		private string Db1fileFullPath { get; set; } = @"D:\fontes\BaseSolution\BaseProject\Database\SQLite";

//		public string SetxDb1fileName(string fileName)
//		{
//			Db1fileName = fileName;
//			return Db1fileName;

//		}
//		public string SetDb1fileFullPath(string fileFullPath)
//		{
//			Db1fileFullPath = fileFullPath;
//			return Db1fileFullPath;

//		}
//		//public bool ConnectDb()
//		//{
//		//	var isConnectionOk = ctxDb1.ConfigureDbString(fileName: Db1fileName,
//		//										  fileFullPath: Db1fileFullPath,
//		//										  forceCreateFolder: true,
//		//										  forceCreateFile: true);
//		//	return isConnectionOk;
//		//}

//		#endregion
		
//		public void teste()
//		{
//		}
//		#region PERSON METHODS
//		public object AddPersonAsync(Person person)
//		{

//			//var x = ConnectDb();
//			ctxDb1.tbPerson.Add(person);
//			ctxDb1.SaveChangesAsync();
//			return person;


//		}

//		public void FindPersonById(int PersonId = 0)
//		{
//			var result = ctxDb1.tbPerson.Find(PersonId);
//			//return result;
//		}

//		public object ChangeDataPerson(Person person)
//		{
//			var find = ctxDb1.tbPerson.Find(person.PersonId);
//			find = (Person)person.Clone();
//			ctxDb1.SaveChangesAsync();
//			return find;
//		}

//		//public Person FindPersonByName(string name)
//		//{

//		//	var result = ctxDb1.dbPerson.Where(p => p.OficialName == name).FirstOrDefault();
//		//	return result;
//		//}
//		#endregion
//	}


//}
