namespace DllDatabase.Configs
{
	class Config
	{
		private string Db1fileName { get; set; } = "banco.db";
		private string Db1fileFullPath { get; set; } = @"D:\sources\BaseSolution\BaseProject\Database\SQLite";

		public string SetxDb1fileName(string fileName)
		{
			Db1fileName = fileName;
			return Db1fileName;
		}
		public string SetDb1fileFullPath(string fileFullPath)
		{
			Db1fileFullPath = fileFullPath;
			return Db1fileFullPath;
		}

		public string GetxDb1fileName()
		{
			return Db1fileName;
		}
		public string GetDb1fileFullPath()
		{
			return Db1fileFullPath;
		}

	}
}
