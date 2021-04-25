using MaterialDesignThemes.Wpf.Transitions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WptfTest.Models;
using WptfTest.Models.BaseViewModels;
using WptfTest.ViewModels.MainView;
using WptfTestWptfTest.Models;
using MaterialDesignThemes.Wpf;
using static WptfTest.Models.MenuItens;
using WptfTest.Views.Dialogs;
using WptfTest.ViewModels.Dialogs;
using System.Windows;
using System.Threading.Tasks;
using WptfTest.Views.LoggedUserView;
using WptfTest.ViewModels.LoggedUserViewModel;

namespace WptfTest
{
	// EVERY new view need to:
	//	Implement some constructor as "MainViewModel" and "MainViewModel"
	//  Crete a data template in MainWIndowViewModel
	//  Create permissions in MainWIndowViewModel
	//  Crete route in method "Open in tab"

	// I nedd implement: 
	// [  ]	Dynamic menu generator relationed based on permissions, 
	//		Maybe crete a new atribute in model "baseviewmodel" -> "canUsarOpenThis"
	// [  ] Base view to default display in tab with headers, like "close", "save", "edit this" and some default actions.
	// [  ] general user control for "quick search" to any collection/model
	// [x ] Dialogs
	// [  ] context menu for main window
	// [X ] login screen
	// [X ] splash screen
	// [  ] auto update pattern
	// [  ] code refactoring: VerifyPermission -> move it to class User as method

	class MainWindowViewModel : BaseViewModel
	{
		#region Properties
		public enum MainMaterialTransitioner
		{
			loginView = 0,
			mainView = 1
		}

		private MainMaterialTransitioner _selectedMainMaterialTransitionerIndex = MainMaterialTransitioner.loginView;
		public int SelectedMainMaterialTransitionerIndex
		{
			get
			{
				var result = (int)_selectedMainMaterialTransitionerIndex;
				return result;
			}
			set
			{
				SetField(ref _selectedMainMaterialTransitionerIndex, (MainMaterialTransitioner)value);
			}
		}

		static bool isDebugMode = false;

		//general permission - move to bata base in future, is here just for test.
		public ObservableCollection<ViewModelPermissions> AllPersmissionsList { get; set; }

		//logged user details
		public User loggedUser { get; set; }

		//collection that i will use to check user permission to open a view
		public ObservableCollection<ViewModelPermissions> loggedUserPermissions { get; set; }

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

		//Collection of menu itens in search
		public ObservableCollection<MenuN1Item> MenuItensFoundInSearch { get; set; }
		#endregion

		#region General Methods

		#region Opening itens in a new main tab
		public bool OpenNewViewInMainTab(object param = null)
		{
			var menuItemReceived = (MenuN1Item)param;


			//the permission about the VM will be verified when instance the VM
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
			BaseViewModel newViewModel;
			switch (parameter)
			{
				case MenuN1Item.MenuN1ItemParameters.TestViewModel:
					newViewModel = new TestViewModel(VerifyPermission(parameter), visibility: true);
					break;

				case MenuN1Item.MenuN1ItemParameters.MainViewModel:
					newViewModel = new MainViewModel(VerifyPermission(parameter), visibility: true);
					break;

				default:
					return false;

			}
			int viewsToShowTotalTabs = ViewsToShow.Count();

			if (viewsToShowTotalTabs >= 0)
			{
				//verify if tab is already open, but now nothing is done.
				bool tabAlreadyOpen = ViewsToShow.Any(t => t.MenuN1ItemParameter.Equals(newViewModel.MenuN1ItemParameter));
				ViewsToShow.Add(newViewModel);
				SelectedViewToShow = newViewModel;
			}


			return true;
		}
		#endregion

		#region GenericDialogs
		public async void CreateGenericOneIconDialog()
		{
			var dialog = new OneIconDialog
			{
				DataContext = new OneIconDialogViewModel
				{
					TitleDialog = "Icon dialog test",
					MessageDialog = "Message test here",
					IconName = "LanguageCsharp",
				}
			};
			await DialogHost.Show(dialog, "MainDialog");
		}


		public async Task<bool> CreateGenericYesNoDialog(string title = null, string message = null, string trueButton = null, string falseButton = null)
		{
			var sampleMessageDialog = new YesNoDialog
			{
				DataContext = new YesNoDialogViewModel
				{
					TitleDialog = title,
					MessageDialog = message,
					TrueButtonDialog = trueButton,
					FalseButtonDialog = falseButton,
				}
			};
			var dialogResult = await DialogHost.Show(sampleMessageDialog, "MainDialog");
			return (bool)dialogResult;
		}


		#endregion
		#region Removing item in main tab collection
		public async void RemoveItemInMainTabCollection(object parameter = null)
		{

			var sampleMessageDialog = new YesNoDialog
			{
				DataContext = new YesNoDialogViewModel
				{
					TitleDialog = "Whant close?",
					MessageDialog = "You will lose not saved data. Do you really want close it?",
					TrueButtonDialog = "Close",
					FalseButtonDialog = "Cancel"
				}
			};

			var dialogResult = await DialogHost.Show(sampleMessageDialog, "MainDialog");
			if ((bool)dialogResult)
			{
				int viewsToShowTotalTabs = ViewsToShow.Count();

				if (viewsToShowTotalTabs >= 0)
				{
					//var tabToRemove = ViewsToShow.FirstOrDefault();
					var tabToRemove = (BaseViewModel)parameter;
					if (tabToRemove.CanCloseIt) ViewsToShow.Remove(tabToRemove);
					//SelectedViewToShow = ;
				}
			}
			var dialog = new OneIconDialog
			{
				DataContext = new OneIconDialogViewModel
				{
					TitleDialog = "Done!",
					MessageDialog = "Item closed ;)",
					IconName = "Check",
				}
			};
			await DialogHost.Show(dialog, "MainDialog");


			//



			//var result = await DialogHost.Show("a", "MainDialog");
			//return true;
		}
		#endregion


		#region Verifing logged user 
		public ViewModelPermissions VerifyPermission(MenuN1Item.MenuN1ItemParameters itemParam)
		{
			//nedd to improve this feature, to check the permission to view selected
			var result = loggedUserPermissions.Where(x => x.viewName.Equals(itemParam)).FirstOrDefault();
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

		public bool SearchMenuItemsNow(string query)
		{
			foreach (var item in MenuItensList)
			{
				foreach (var subItem in item.MenuN1SubList)
				{
					foreach (var menuItem in subItem.MenuN1ItensList)
					{
						bool itemExistisInCollection = MenuItensFoundInSearch.Any(i => i.MenuN1ItemName.Equals(menuItem.MenuN1ItemName));
						bool itemNameContainsQuery = menuItem.MenuN1ItemName.Contains(query);
						bool itemTagsContainQuery = menuItem.MenuN1ITags.Any(x => x.Contains(query));
						bool itemIsVisible = menuItem.Visibility.Equals(true);
						if ((itemNameContainsQuery ||
							itemTagsContainQuery) &&
							itemIsVisible &&
							!itemExistisInCollection)
						{
							MenuItensFoundInSearch.Add(menuItem);
						}
						else { }

					}
				}
			}

			return true;
		}


		public bool LoginDesktopWinAppNow(object user = null)
		{
			//check user sent
			if (isDebugMode)
			{
				if ((loggedUser.UserName).ToUpper() == "admin".ToUpper())
				{
					//Loading user properties

					loggedUser.UserName = "Leandro Admin";
					loggedUser.UserProfile = UserProfiles.UserProfileTypes.sysAdmim;

				}
				else
				{

					loggedUser.UserName = "Leandro ORDINARY USER";
					loggedUser.UserProfile = UserProfiles.UserProfileTypes.ordinaryUser;

				}

				//User permissions
				loggedUserPermissions = new ObservableCollection<ViewModelPermissions>();
				var tempUserPermissions = AllPersmissionsList.Where(x =>
				x.userProfileType.Equals(loggedUser.UserProfile));
				{
					foreach (var item in tempUserPermissions)
					{
						loggedUserPermissions.Add(item);
					}

				}


				
			}

			var loggedUserViewModel = new LoggedUserViewModel(VerifyPermission(MenuN1Item.MenuN1ItemParameters.LoggedUserViewModel), visibility: true);
			ViewsToShow.Add(loggedUserViewModel);
			SelectedViewToShowTabIndex = 0;
			return true;

		}


		public void CloseWindowNow(object window = null)
		{

			if (window != null)
			{
				Window windowToCLose = (Window)window;
				windowToCLose.Close();

			}

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
			//commands instance
			TestNewCommand = new SimpleCommand<object>(TestNew);
			RemoveIntemFromMainTabCommand = new SimpleCommand<object>(RemoveIntemFromMainTab);
			CloseWindowCommand = new SimpleCommand<object>(CloseWindow);

			SearchMenuItemsCommand = new SimpleCommand<string>(SearchMenuItems);

			LoginDesktopWinAppCommand = new SimpleCommand<object>(LoginDesktopWinApp);

			// data population for tests... 
			if (isDebugMode)
			{
				//var mainView = new MainViewModel();
				//mainView.Visibility = true;
				//ViewsToShow.Add(mainView);

				//mainView = new MainViewModel();
				//mainView.Visibility = true;

				//ViewsToShow.Add(mainView);

				//var mainView2 = new TestViewModel();
				//mainView2.Visibility = false;
				//ViewsToShow.Add(mainView2);


				// creating list of permissions
				AllPersmissionsList = new ObservableCollection<ViewModelPermissions>();
				ViewModelPermissions vmp = new ViewModelPermissions(
					UserProfiles.UserProfileTypes.sysAdmim,
					MenuN1Item.MenuN1ItemParameters.MainViewModel,
					true,
					true,
					true,
					true,
					true,
					false
					);
				AllPersmissionsList.Add(vmp);
				ViewModelPermissions vmp2 = new ViewModelPermissions(
					UserProfiles.UserProfileTypes.ordinaryUser,
					MenuN1Item.MenuN1ItemParameters.MainViewModel,
					true,
					false,
					true,
					false,
					true,
					false
					);
				AllPersmissionsList.Add(vmp2);
				ViewModelPermissions vmp3 = new ViewModelPermissions(
					UserProfiles.UserProfileTypes.sysAdmim, 
					MenuN1Item.MenuN1ItemParameters.TestViewModel,
					true,
					true,
					true,
					true,
					true,
					true
					);
				AllPersmissionsList.Add(vmp3);

				ViewModelPermissions vmp4 = new ViewModelPermissions(
				UserProfiles.UserProfileTypes.ordinaryUser,
				MenuN1Item.MenuN1ItemParameters.TestViewModel,
				true,
				false,
				false,
				false,
				false,
				false
				);
				AllPersmissionsList.Add(vmp4);

				ViewModelPermissions vmp5 = new ViewModelPermissions(
					UserProfiles.UserProfileTypes.sysAdmim,
					MenuN1Item.MenuN1ItemParameters.LoggedUserViewModel,
					true,
					true,
					true,
					true,
					true,
					true
					);
				AllPersmissionsList.Add(vmp5);

				ViewModelPermissions vmp6 = new ViewModelPermissions(
					UserProfiles.UserProfileTypes.ordinaryUser,
					MenuN1Item.MenuN1ItemParameters.LoggedUserViewModel,
					true,
					true,
					true,
					true,
					true,
					true
				);
				AllPersmissionsList.Add(vmp6);



			}

	

			//instace logged user
			loggedUser = new User();

			// Menu request 
			MenuItensList = new ObservableCollection<Models.MenuItens>();
			var objMenu = CreateMainMenu("MainMenu");
			MenuItensList.Add(objMenu);

			//Collection to display itens in menu search items
			MenuItensFoundInSearch = new ObservableCollection<MenuN1Item>();



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

		//This one is used for close a menu item in main tab
		public ICommand RemoveIntemFromMainTabCommand { get; private set; }
		private void RemoveIntemFromMainTab(object open)
		{
			this.RemoveItemInMainTabCollection(open);
			IsMenuOpen = false;
		}

		//search engine for menu itens
		public ICommand SearchMenuItemsCommand { get; private set; }
		private void SearchMenuItems(string query = null)
		{
			MenuItensFoundInSearch.Clear();

			if (!string.IsNullOrWhiteSpace(query))
			{
				SearchMenuItemsNow(query);
			}

		}

		//login action for win desktop app
		public ICommand LoginDesktopWinAppCommand { get; private set; }
		private void LoginDesktopWinApp(object user = null)
		{

			var result = LoginDesktopWinAppNow(user);
			if (result) SelectedMainMaterialTransitionerIndex = (int)MainMaterialTransitioner.mainView;

		}


		//Close window
		public ICommand CloseWindowCommand { get; private set; }
		private void CloseWindow(object window = null)
		{
			CloseWindowNow(window);

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

		//test to close window
		public class CloseMainWindowCommand : BaseCommand
		{
			public override bool CanExecute(object parameter)
			{
				return true;
			}

			public override async void Execute(object parameter)
			{
				var window = (Window)parameter;
				var dt = (MainWindowViewModel)window.DataContext;
				var result = await dt.CreateGenericYesNoDialog(title: "Close?",
					message: "All not saved data will be lost.", trueButton: "Yes, close!", falseButton: "Ops, cancel...");
				if (result) window.Close();

			}
		}
		public CloseMainWindowCommand CloseCommand { get; private set; } = new CloseMainWindowCommand();

		#endregion








	}
}


