using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
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
using static WptfTest.Models.MenuItens;

namespace WptfTest
{



	class MainWindowViewModel : BaseViewModel
	{
		bool isDebugMode = false;
		#region Properties
		//it is used always when a new view will be iniciated
		public ViewModelPermissions viewModelPermissions { get; set; }

		//Collection of views to display in main tab
		public ObservableCollection<BaseViewModel> ViewsToShow { get; set; }
		public int SelectedViewToShowTabIndex { get; set; }
		private BaseViewModel _selectedViewToShow;
		public BaseViewModel SelectedViewToShow
		{
			get { return _selectedViewToShow; }
			set
			{
				SetField(ref _selectedViewToShow, value);
			}
		}

		//Collection of menu itens to dispay in main menu
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
		#endregion

		#region General Methods

		#region Opening itens in a new main tab
		public bool OpenNewViewInMainTab(object param = null)
		{
			var menuItemReceived = (MenuN1Item)param;

			//when it want to open a new tab, it checks permissns to the view 
			viewModelPermissions = VerifyPermission(menuItemReceived.MenuN1ItemParameter);

			//after permission verified, 
			switch (menuItemReceived.MenuN1ItemType)
			{
				case MenuN1Item.MenuN1ItemTypes.MainTabNewItem: // if type is request a new main tab
					IncludeNewItemInMainTab(menuItemReceived.MenuN1ItemParameter);
					break;

				default: // another implementations will come here, but the default is nothing
					break;
			}

			return true;

		}
		public bool IncludeNewItemInMainTab(MenuN1Item.MenuN1ItemParameters parameter = 0)
		{
			// a dynamic object that is used to set the view that will be included in tab
			dynamic newViewModel;
			switch (parameter)
			{
				case MenuN1Item.MenuN1ItemParameters.TestViewModel:
					newViewModel = new TestViewModel();
					newViewModel.Visibility = true;
					break;

				case MenuN1Item.MenuN1ItemParameters.MainViewModel:
					newViewModel = new MainViewModel(viewModelPermissions, visibility: true);
					break;

				default:
					return false;

			}
			int viewsToShowTotalTabs = ViewsToShow.Count();

			if (viewsToShowTotalTabs > 0)
			{
				ViewsToShow.Add(newViewModel);
				
				SelectedViewToShow = newViewModel;
			}



			return true;
		}
		#endregion

		#region Verifing logged user 
		public ViewModelPermissions VerifyPermission(MenuN1Item.MenuN1ItemParameters itemParam)
		{
			//nedd to improve this feature, to check the permission to view selected
			var result = new ViewModelPermissions(true, true);
			return result;
		}
		#endregion


		#region Others
		public MenuItens CreateMainMenu(string menuName = null)
		{
			//nedd to impleimprovement this feature, to check the menus itens allowed to user
			var result = new MenuItens();
			return result;
		}
		#endregion

		#endregion


		public MainWindowViewModel()
		{
			// can use this bool to identify if the app is running in debug
			// ... and then make some stuffs work only if debug easier
#if DEBUG
			isDebugMode = true;
#endif

			// delete ater 17/04/2021 if no bug detected. the perissions is a new instance every time new action requires.
			//viewModelPermissions = new ViewModelPermissions();

			ViewsToShow = new ObservableCollection<BaseViewModel>();

			TestNewCommand = new SimpleCommand<object>(TestNew);


			// data population for tests... 
			if (isDebugMode)
			{
				var mainView = new MainViewModel(viewModelPermissions);
				mainView.Visibility = true;
				ViewsToShow.Add(mainView);

				mainView = new MainViewModel(viewModelPermissions);
				mainView.Visibility = true;

				ViewsToShow.Add(mainView);

				var mainView2 = new MainViewModel();
				mainView2.Visibility = false;
				ViewsToShow.Add(mainView2);




			}

			// Menu request 
			MenuItensList = new ObservableCollection<Models.MenuItens>();
			var objMenu = CreateMainMenu("MainMenu");
			MenuItensList.Add(objMenu);

		}






		#region Commands

		//Commands usin "SimpleCommand" base class, that use Action implementation

		//This one is used for open a menu item, originally its could be only in a tab, but can be implemented ther ways, like modal window.
		public ICommand TestNewCommand { get; private set; }
		private void TestNew(object open)
		{
			this.OpenNewViewInMainTab(open);
			IsMenuOpen = false;
		}

		//Command usin a class for each command. In this case nedd to use parameter to send the object to command,
		//... it may be a problem in almost cases.
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
				//viewModel.OpenNewViewInMainTab(parameter);
			}
		}
		public ExempleCommand DoExempleCommand { get; private set; } = new ExempleCommand();

		#endregion








	}
}


