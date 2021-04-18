using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WptfTest.Models;
using WptfTest.Models.BaseViewModels;
using WptfTest.ViewModels.MainView;
using WptfTestWptfTest.Models;
using static WptfTest.Models.MenuItens;

namespace WptfTest
{



	class MainWindowViewModel : BaseViewModel
	{
		static bool isDebugMode = false;

		//general permission - move to bata base in future, is here just for test.
		public ObservableCollection<ViewModelPermissions> AllPersmissionsList { get; set; }

		//logged user details
		public User loggedUser { get; set; }

		//collection that i will use to check user permission to open a view
		public ObservableCollection<ViewModelPermissions> loggedUserPermissions { get; set; }



		#region Properties

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

			SearchMenuItemsCommand = new SimpleCommand<string>(SearchMenuItems);

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
					false,
					false
					);
				AllPersmissionsList.Add(vmp3);



			}
			//Loading user properties
			loggedUser = new User();
			loggedUser.UserName = "Leandro";
			loggedUser.UserProfile = UserProfiles.UserProfileTypes.sysAdmim;


			// Menu request 
			MenuItensList = new ObservableCollection<Models.MenuItens>();
			var objMenu = CreateMainMenu("MainMenu");
			MenuItensList.Add(objMenu);

			//Collection to display itens in menu search items
			MenuItensFoundInSearch = new ObservableCollection<MenuN1Item>();

			//User permissions
			loggedUserPermissions = new ObservableCollection<ViewModelPermissions>();
			var tempUserPermissions = AllPersmissionsList.Where(x => x.userProfileType.Equals(loggedUser.UserProfile));
			{
				foreach (var item in tempUserPermissions)
				{
					loggedUserPermissions.Add(item);
				}

			}



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


