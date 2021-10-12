namespace DllDatabase.Configs
{
	class Config
	{


		private DbContext data { get; set; } = new DbContext();
		private string Db1fileName { get; set; } = "banco.db";
		private string Db1fileFullPath { get; set; } = @"D:\fontes\BaseSolution\BaseProject\Database\SQLite";

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
		public bool ConnectDb()
		{
			var isConnectionOk = data.ConfigureDbString(fileName: Db1fileName,
												  fileFullPath: Db1fileFullPath,
												  forceCreateFolder: true,
												  forceCreateFile: true);
			return isConnectionOk;
		}
	}
}
