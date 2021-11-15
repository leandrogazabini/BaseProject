using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models
{
	public class UserModel : BaseClass
	{

		//#region CONSTRUCTORS
		public UserModel()
		{

		}

		private string _username;
		[Display(Name ="Username")]
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				SetField(ref _username, value);
			}
		}
		private string _password;
		[Display(Name ="Password")]
		[Required]
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				SetField(ref _password, value);
			}
		}
		private string _role;
		[Display(Name ="Role")]
		public string Role
		{
			get
			{
				return _role;
			}
			set
			{
				SetField(ref _role, value);
			}
		}
		//#endregion PROPERTIES

		//#region METHODS
		//#endregion METHODS


	}
}
