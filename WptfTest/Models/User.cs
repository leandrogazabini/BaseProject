using DllModels.Models.Bases;
using System;

namespace WptfTest.Models
{
	class User : BaseClass
	{

		private string _userName = String.Empty;
		public string UserName
		{
			get { return _userName; }
			set { SetField(ref _userName, value); }
		}


		private UserProfiles.UserProfileTypes? _userProfile;
		public UserProfiles.UserProfileTypes? UserProfile
		{
			get { return _userProfile; }
			set { SetField(ref _userProfile, value); }
		}


	}
}
