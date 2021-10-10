using DllModels.Models;
using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models
{

	public class PersonNaturalDetails : BaseClass
	{
		//FK
		public PersonModel Person { get; set; }
		public int PersonId { get; set; }

		#region PROPERTIES

		private int _personNaturalDetailsId;
		[KeyAttribute]
		public int PersonNaturalDetailsId
		{
			get { return _personNaturalDetailsId; }
			set
			{
				SetField(ref _personNaturalDetailsId, value);
				ValidateProperty(value);
			}
		}


		//NICKNAME
		private string _nickName;
		[Display(Name = "Nickname")]
		public string NickName
		{
			get { return _nickName; }
			set
			{
				SetField(ref _nickName, value);
				ValidateProperty(value);
			}
		}
		public PersonNaturalDetails()
		{

		}






		#endregion
	}
}