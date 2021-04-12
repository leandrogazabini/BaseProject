using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using DllModels;
using DllModels.Models.Bases;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using WptfTest.Models;
using WptfTest.ViewModels.MainView;
using WptfTestWptfTest.Models;

namespace WptfTest
{



	class MainWindowViewModel : DllModels.Models.Bases.BaseClass
	{
	

		//private IDialogCoordinator dialogCoordinator;

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

		public ObservableCollection<BaseClass> ViewsToShow { get; set; }
		private BaseClass _selectedViewToShow;
		public BaseClass SelectedViewToShow
		{
			get { return _selectedViewToShow; }
			set
			{
				SetField(ref _selectedViewToShow, value);
			}
		}

		public ObservableCollection<Models.MenuItens> MenuItensList { get; set; }

		public void Teste()
		{
			
			var mainViewx = new ViewModels.MainView.MainViewModel();
			//mainViewx.blabla = "bla5";
			if (ViewsToShow.Count > 0) ViewsToShow.Add(mainViewx);

		}
	
		private bool _isMenuOpen = true;
		public bool IsMenuOpen
		{
			get { return _isMenuOpen; }
			set
			{
				SetField(ref _isMenuOpen, value);
			}
		}


		#region Commands
		public class ExempleCommand : BaseCommand
		{
			public override bool CanExecute(object parameter)
			{
				return true;
			}

			public override async void Execute(object parameter)
			{
				var viewModel = (MainWindowViewModel)parameter;
				//if (viewModel.TesteBool == false) viewModel.TesteBool = true;
				//else viewModel.TesteBool = true;

				//using (var db = new DBL.db())
				//{
				//}
				viewModel.Teste();
			}
		}
		public ExempleCommand DoExempleCommand { get; private set; } = new ExempleCommand();

		#endregion





		public MainWindowViewModel()
		{
			


			StringTestToShow = new ObservableCollection<string>();

			StringTestToShow.Add("Banana");
			StringTestToShow.Add("Batata");
			StringTestToShow.Add("Arroz");
			StringTestToShow.Add("Maça");
			StringTestToShow.Add("Jaca");


			ViewsToShow = new ObservableCollection<BaseClass>();
			var mainView = new MainViewModel();
			ViewsToShow.Add(mainView);

			mainView = new MainViewModel();
			ViewsToShow.Add(mainView);

			var mainView2 = new TestViewModel();
			ViewsToShow.Add(mainView2);

			MenuItensList = new ObservableCollection<Models.MenuItens>();
			var objMenu = new MenuItens();
			objMenu = objMenu.CreateMenu();
			MenuItensList.Add(objMenu);

			

		}


	}

}
