using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllModels;
using MahApps.Metro.Controls.Dialogs;

namespace WptfTest
{
	class MainWindowViewModel : DllModels.Models.Bases.BaseClass
	{
		private IDialogCoordinator dialogCoordinator;



		public MainWindowViewModel(IDialogCoordinator instance)
		{
			dialogCoordinator = instance;
		}
	}

}
