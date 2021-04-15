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


using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using WptfTest.Models;
using WptfTest.Models.BaseViewModels;
using WptfTest.ViewModels.MainView;
using WptfTestWptfTest.Models;

namespace WptfTest
{



	class MainWindowViewModel : BaseViewModel
	{

		public ObservableCollection<BaseViewModel> ViewsToShow { get; set; }
		private BaseViewModel _selectedViewToShow;
		public BaseViewModel SelectedViewToShow
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


		#region General Methods
		public void OpenNewViewInMainTab()
		{
			var newViewTab = new MainViewModel();
			newViewTab.Visibility = true;
			if (ViewsToShow.Any()) ViewsToShow.Add(newViewTab);

		}



		#endregion
		public MainWindowViewModel()
		{

			TestNewCommand = new SimpleCommand<string>(TestNew);

			ViewsToShow = new ObservableCollection<BaseViewModel>();

			var mainView = new MainViewModel();
			mainView.Visibility = true;
			ViewsToShow.Add(mainView);

			mainView = new MainViewModel();
			mainView.Visibility = true;

			ViewsToShow.Add(mainView);

			var mainView2 = new TestViewModel();
			mainView2.Visibility = false;
			ViewsToShow.Add(mainView2);

			MenuItensList = new ObservableCollection<Models.MenuItens>();
			var objMenu = new MenuItens();
			//objMenu = objMenu.CreateMenu();
			MenuItensList.Add(objMenu);



		}
		#region Commands

		public ICommand TestNewCommand { get; private set; }
		private void TestNew(string open = "") { this.OpenNewViewInMainTab(); }


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
				viewModel.OpenNewViewInMainTab();
			}
		}
		public ExempleCommand DoExempleCommand { get; private set; } = new ExempleCommand();

		#endregion








	}
}


