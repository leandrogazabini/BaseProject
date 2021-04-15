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

		public bool canExecute { get; } = false;
		public bool canRead { get; } = false;
		public bool canWrite { get; } = false;
		public bool canSaveChanges { get; } = false;
		public bool canDeleteLogic { get; } = false;
		public bool canDeleteData { get; } = false;


		public ViewModelPermissions(bool _canExecute = false,
									bool _canRead = false,
									bool _canWrite = false,
									bool _canSaveChanges = false,
									bool _canDeleteLogic = false,
									bool _canDeleteData = false)
		{
			canExecute = _canExecute;
			canRead = _canRead;
			canWrite = _canWrite;
			canSaveChanges = _canSaveChanges;
			canDeleteLogic = _canDeleteLogic;
			canDeleteData = _canDeleteData;
		}

		

	}
}
