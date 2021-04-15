using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

		private string _viewHelpMessage = "Not implemented";
		public string ViewHelpMessage
		{
			get { return _viewHelpMessage; }
			set
			{
				SetField(ref _viewHelpMessage, value);
			}
		}


		private bool _visibility = false;
		public bool Visibility
		{
			get { return _visibility; }
			set { SetField(ref _visibility, value); }
		}


		public ViewModelPermissions ViewModelPermissions { get; set; }

		public BaseViewModel()
		{
			this.ViewModelPermissions = new ViewModelPermissions();
		}


		
	}
}
