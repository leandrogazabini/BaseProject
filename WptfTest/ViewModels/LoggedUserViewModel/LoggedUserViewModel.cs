using DllModels.Models;
using WptfTest.Models;
using WptfTest.Models.BaseViewModels;

namespace WptfTest.ViewModels.LoggedUserViewModel
{
	class LoggedUserViewModel : BaseViewModel
	{

		private string _test = "Test string.";
		public string Test
		{
			get { return _test; }
			set
			{
				SetField(ref _test, value);
			}
		}


		public PersonModel Person { get; set; }


		private string _selectedMenuItem;
		public string SelectedMenuItem
		{
			get { return _selectedMenuItem; }
			set
			{
				SetField(ref _selectedMenuItem, value);
			}
		}

		public LoggedUserViewModel(ViewModelPermissions viewModelPermissions = null, bool visibility = false)
		{			
			SetViewModelPermissions(viewModelPermissions);
			this.Visibility = visibility;
			this.CanCloseIt = false;
			this.MenuN1ItemParameter = MenuItens.MenuN1Item.MenuN1ItemParameters.MainViewModel;
		}


	}
}

