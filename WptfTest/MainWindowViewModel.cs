using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DllModels;
using DllModels.Models.Bases;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using WptfTest.Models;

namespace WptfTest
{

	

	class MainWindowViewModel : DllModels.Models.Bases.BaseClass
	{
		private IDialogCoordinator dialogCoordinator;
		public class ViewModelBase
		{
			public BaseClass Viewww { get; set; }

			public string blabla { get; set; }
		}

		public ObservableCollection<string> StringTestToShow { get; set; }
		private string _selectedStringTestToShow;
		public string SelectedStringTestToShow
		{
			get { return _selectedStringTestToShow; }
			set
			{
				SetField(ref _selectedStringTestToShow, value);
			}
		}

		public ObservableCollection<ViewModelBase> ViewsToShow { get; set; }
		private ViewModelBase _selectedViewToShow;
		public ViewModelBase SelectedViewToShow
		{
			get { return _selectedViewToShow; }
			set
			{
				SetField(ref _selectedViewToShow, value);
			}
		}

		public ObservableCollection<Models.MenuItens> MenuItensList { get; set; }
		





		private bool _isMenuOpen = true;
		public bool IsMenuOpen
		{
			get { return _isMenuOpen; }
			set
			{
				SetField(ref _isMenuOpen, value);
			}
		}

		public MainWindowViewModel()
		{
			


			StringTestToShow = new ObservableCollection<string>();

			StringTestToShow.Add("Banana");
			StringTestToShow.Add("Batata");
			StringTestToShow.Add("Arroz");
			StringTestToShow.Add("Maça");
			StringTestToShow.Add("Jaca");


			ViewsToShow = new ObservableCollection<ViewModelBase>();
			ViewModelBase  mainView = new ViewModelBase();
			mainView.Viewww = new ViewModels.MainView.MainViewModel();
			mainView.blabla = "bla1";
			ViewsToShow.Add(mainView);
			
			mainView = new ViewModelBase();
			mainView.Viewww = new ViewModels.MainView.MainViewModel();
			mainView.blabla = "bla2";
			ViewsToShow.Add(mainView);

			mainView = new ViewModelBase();
			mainView.Viewww = new ViewModels.MainView.TestViewModel();
			mainView.blabla = "teste";
			ViewsToShow.Add(mainView);

			MenuItensList = new ObservableCollection<Models.MenuItens>();
			var objMenu = new MenuItens();
			objMenu = objMenu.CreateMenu();
			MenuItensList.Add(objMenu);
		}
	}

}
