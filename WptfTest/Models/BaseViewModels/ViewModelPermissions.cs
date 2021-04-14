using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WptfTest.Models.BaseViewModels
{
	class ViewModelPermissions
	{

		private bool canExecute = false;
		private bool canRead = false;
		private bool canWrite = false;
		private bool canSaveChanges = false;
		private bool canDeleteLogic = false;
		private bool canDeleteData = false;

		private ObservableCollection<bool> ViewModelPermissionsList { get; set; }

		public ViewModelPermissions(bool _canExecute = false,
									bool _canRead = false,
									bool _canWrite = false,
									bool _canSaveChanges = false,
									bool _canDeleteLogic = false,
									bool _canDeleteData = false)
		{
			this.ViewModelPermissionsList = new ObservableCollection<bool>();
			this.ViewModelPermissionsList.Clear();
			this.ViewModelPermissionsList.Add(canExecute = _canExecute);
			this.ViewModelPermissionsList.Add(canRead = _canRead);
			this.ViewModelPermissionsList.Add(canWrite = _canWrite);
			this.ViewModelPermissionsList.Add(canSaveChanges = _canSaveChanges);
			this.ViewModelPermissionsList.Add(canDeleteLogic = _canDeleteLogic);
			this.ViewModelPermissionsList.Add(canDeleteData = _canDeleteData);
		}

	}
}
