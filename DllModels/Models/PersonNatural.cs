using DllModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models
{
	//public class PersonNatural : Person
	//{
	//	//OFFICIAL NAME
	//	private string _oficialName;
	//	[Display(Name = "Official name")]
	//	[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
	//	[Required(ErrorMessage = "{0} is required.")]
	//	public string OficialName
	//	{
	//		get { return _oficialName; }
	//		private set
	//		{
	//			SetField(ref _oficialName, value);
	//			ValidateProperty(value);
	//		}
	//	}

	//	//ALTERNATIVE NAME
	//	private string _alternativeName;
	//	[Display(Name = "Alternative name")]
	//	[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
	//	[Required(ErrorMessage = "{0} is required.")]
	//	public string AlternativeName
	//	{
	//		get { return _alternativeName; }
	//		private set
	//		{
	//			SetField(ref _alternativeName, value);
	//			ValidateProperty(value);
	//		}
	//	}

	//	//MAIN DOC
	//	private string _mainDocumentNumber;
	//	[Display(Name = "Main document number")]
	//	[MinLength(11, ErrorMessage = "{0} must have at least 2 caracters.")]
	//	[Required(ErrorMessage = "{0} is required.")]
	//	public string MainDocumentNumber
	//	{
	//		get { return _mainDocumentNumber; }
	//		private set
	//		{
	//			SetField(ref _mainDocumentNumber, value);
	//			ValidateProperty(value);
	//		}
	//	}

	//	#region Constructors
	//	public PersonNatural()
	//	{
	//		this.PersonLegalKind = PersonLegalKindEnum.Natural;
	//		this.OficialName = null;
	//		this.AlternativeName = null;
	//		this.MainDocumentNumber = null;

	//	}
	//	#endregion
	//}
}
