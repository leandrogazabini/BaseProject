using DllModels.Models.Bases;
using System.Windows;
using static WptfTest.Models.MenuItens.MenuN1Item;

namespace WptfTest.Models.BaseViewModels
{
	class BaseViewModel : BaseClass
	{


		private string _viewTitle = "Not implemented";
		public string ViewTitle
		{
			get { return _viewTitle; }
			set
			{
				SetField(ref _viewTitle, value);
			}
		}

		public MenuN1ItemParameters MenuN1ItemParameter { get; set; }
		

		private string _viewHelpMessage = "Not implemented";
		public string ViewHelpMessage
		{
			get { return _viewHelpMessage; }
			set
			{
				SetField(ref _viewHelpMessage, value);
			}
		}


		private bool _visibility = true;
		public bool Visibility
		{
			get { return _visibility; }
			set { SetField(ref _visibility, value); }
		}


		public ViewModelPermissions ViewModelPermissions { get; set; }

		public bool SetViewModelPermissions(ViewModelPermissions viewModelPermissions = null)
		{
			if (viewModelPermissions == null)
			{
				this.ViewModelPermissions = new ViewModelPermissions();
			}
			else
			{
				this.ViewModelPermissions = viewModelPermissions;
			}

			return true;
		}

		public BaseViewModel(ViewModelPermissions viewModelPermissions = null, bool visibility = false)
		{
			SetViewModelPermissions();
			this.Visibility = visibility;
		}



	}
}
