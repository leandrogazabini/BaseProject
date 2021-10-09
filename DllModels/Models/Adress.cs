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

	public class Adress : BaseClass
	{

		#region PROPERTIES
		//FK
		public Person Person { get; set; }
		public int PersonId { get; set; }

		private int _adressId;
		[KeyAttribute]
		public int AdressId
		{
			get { return _adressId; }
			set
			{
				SetField(ref _adressId, value);
				ValidateProperty(value);
			}
		}

		//NICKNAME
		private string _fullAdress;
		[Display(Name = "Nickname")]
		public string FullAdress
		{
			get { return _fullAdress; }
			set
			{
				SetField(ref _fullAdress, value);
				ValidateProperty(value);
			}
		}


		#region CONSTRUCTOR

		public Adress()
		{

		}

		#endregion CONSTRUCTOR




		#endregion
	}
}