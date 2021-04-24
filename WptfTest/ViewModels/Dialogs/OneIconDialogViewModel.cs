using WptfTest.Models.BaseViewModels;

namespace WptfTest.ViewModels.Dialogs
{
	class OneIconDialogViewModel : BaseViewModel
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



		private string _iconName = "Cancel";
		public string IconName
		{
			get { return (string)_iconName; }
			set { SetField(ref _iconName, value); }
		}
		private string _iconForeground;
		public string IconForeground
		{
			get { return (string)_iconForeground; }
			set { SetField(ref _iconForeground, value); }
		}


		private string _okButton = "Ok";
		public string  OkButton
		{
			get { return (string)_okButton.ToUpper(); }
			set { SetField(ref _okButton, value); }
		}




	}
}