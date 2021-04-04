using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using DllModels;
using MahApps.Metro.Controls.Dialogs;
using BusinessLogic;



namespace WptfTest.ViewModels.MainView
{
	class MainViewModel : DllModels.Models.Bases.BaseClass
	{
		//private IDialogCoordinator dialogCoordinator;

		private string _test = "Isso é um teste";
		public string Test
		{
			get { return _test; }
			set
			{
				SetField(ref _test, value);
			}
		}

		public MainViewModel()
		{

			var bllCtx = new BusinessLogic.Methods();
			
			var connection = bllCtx.ConnectDb();
			var qResult = bllCtx.FindPersonByName("Leandro Prandini Gazabini");
			Test = qResult.OficialName;
		}




	}
}

