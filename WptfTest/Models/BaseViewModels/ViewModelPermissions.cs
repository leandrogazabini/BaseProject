using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WptfTest.Models.BaseViewModels
{
	public class ViewModelPermissions
	{
		//can logged user read content of view?
		public bool canRead { get; } = false;
		//can logged user write anything in view?
		public bool canWrite { get; } = false;
		//can logged user execute general actions in the view?
		public bool canExecute { get; } = false;
		//can logged user SAVE data in database?
		public bool canSaveChanges { get; } = false;
		//can logged user DELETE (LOGIC LEVEL) data in database?
		public bool canDeleteLogic { get; } = false;
		//can logged user DELETE (real!!!) data in database?
		public bool canDeleteData { get; } = false;


		public ViewModelPermissions(bool _canRead = false,
									bool _canWrite = false,
									bool _canExecute = false,
									bool _canSaveChanges = false,
									bool _canDeleteLogic = false,
									bool _canDeleteData = false)
		{
			canRead = _canRead;
			canWrite = _canWrite;
			canExecute = _canExecute;
			canSaveChanges = _canSaveChanges;
			canDeleteLogic = _canDeleteLogic;
			canDeleteData = _canDeleteData;
		}

		

	}
}
