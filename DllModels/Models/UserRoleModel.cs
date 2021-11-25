using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models
{
	public class UserRoleModel : BaseClass
	{

		//#region CONSTRUCTORS
		public UserRoleModel()
		{

		}

		private string _roleName;
		[Display(Name = "Role Name")]
		public string RoleName
		{
			get
			{
				return _roleName;
			}
			set
			{
				SetField(ref _roleName, value);
			}
		}

		private string _details;
		
		//#endregion PROPERTIES

		//#region METHODS
		//#endregion METHODS


	}

}
