using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using WptfTest.Models.BaseViewModels;

namespace WptfTest.ViewModels.Dialogs
{
	class YesNoDialogViewModel : BaseViewModel
	{
		private string _titleDialog ="Title";
		public string TitleDialog
		{
			get { return (string)_titleDialog.ToUpper(); }
			set { SetField(ref _titleDialog, value); }
		}


		private string _messageDialog = "Message";
		public string MessageDialog
		{
			get { return (string)_messageDialog.ToUpper(); }
			set { SetField(ref _messageDialog, value); }
		}

		private string _trueButtonDialog = "Ok";
		public string TrueButtonDialog
		{
			get { return (string)_trueButtonDialog.ToUpper(); }
			set { SetField(ref _trueButtonDialog, value); }
		}

		private string _falseButtonDialog = "Cancel";
		public string FalseButtonDialog
		{
			get { return (string)_falseButtonDialog.ToUpper(); }
			set { SetField(ref _falseButtonDialog, value); }
		}



	}
}