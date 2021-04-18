namespace WptfTest.Models
{
	public class ViewModelPermissions
	{
		//permission ID
		public int? Id { get;}
		//type of user
		public UserProfiles.UserProfileTypes userProfileType { get; }
		//view name

		public MenuItens.MenuN1Item.MenuN1ItemParameters viewName { get; }
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


		public ViewModelPermissions( UserProfiles.UserProfileTypes _userProfileType  = UserProfiles.UserProfileTypes.ordinaryUser,
									MenuItens.MenuN1Item.MenuN1ItemParameters _viewName = 0,
									bool _canRead = false,
									bool _canWrite = false,
									bool _canExecute = false,
									bool _canSaveChanges = false,
									bool _canDeleteLogic = false,
									bool _canDeleteData = false)
		{
			userProfileType = _userProfileType;
			viewName = _viewName;
			canRead = _canRead;
			canWrite = _canWrite;
			canExecute = _canExecute;
			canSaveChanges = _canSaveChanges;
			canDeleteLogic = _canDeleteLogic;
			canDeleteData = _canDeleteData;
		}

		

	}
}
