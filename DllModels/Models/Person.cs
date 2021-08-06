using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using static DllModels.Models.CustomValidations.CustomValidations;

namespace DllModels.Models
{

	public class Person : BaseClass
	{


		public enum PersonLegalKindEnum //https://en.wikipedia.org/wiki/Legal_person
		{
			Empty = 0,
			Natural = 1,
			Juridical = 2
		}

		public enum PersonSystemKindEnum
		{ 
			Empty = 0,
			NotDefiniedYet = 999,
			Employer = 1,
			Client = 2,
			Provider = 3                  

		}

		#region PROPERTIES

		private int _personId;
		[KeyAttribute]
		public int PersonId
		{
			get { return _personId; }
			set
			{
				SetField(ref _personId, value);
				ValidateProperty(value);
			}
		}


		//KIND OF PERSON
		[Display(Name = "Legal kind of Person")]
		[Required(ErrorMessage = "{0} is required.")]
		private PersonLegalKindEnum _personLegalKind;
		public PersonLegalKindEnum PersonLegalKind
		{
			get { return _personLegalKind; }
			//protected set
			set
			{
				SetField(ref _personLegalKind, value);
				ValidateProperty(value);
				this.OficialName = this.OficialName; // i do this to force validation "required if"
			}
		}


		//OFFICIAL NAME
		private string _oficialName = null;
		[Display(Name = "Official name")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[Required(ErrorMessage = "{0} is required.")]
		//[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Empty, ErrorMessage ="{0} is required for")]
		public string OficialName
		{
			get { return _oficialName; }
			set
			{
				SetField(ref _oficialName, value);
				ValidateProperty(value);

			}
		}


		//ALTERNATIVE NAME
		private string _alternativeName = null;
		[Display(Name = "Alternative name")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		//[Required(ErrorMessage = "{0} is required.")]
		[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Juridical, ErrorMessage = "{0} is required for juridical person.")]
		public string AlternativeName
		{
			get { return _alternativeName; }
			set
			{
				SetField(ref _alternativeName, value);
				ValidateProperty(value);

			}
		}


		//MAIN DOCUMENT
		private string _mainDocumentNumber;
		[Display(Name = "Main document number")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[Required(ErrorMessage = "{0} is required.")]
		//[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Juridical, ErrorMessage = "{0} is required for juridcal person.")]
		public string MainDocumentNumber
		{
			get { return _mainDocumentNumber; }
			set { SetField(ref _mainDocumentNumber, value); }
		}


		//SECOND DOCUMENT
		private string _secondDocumentNumber;
		[Display(Name = "Main document number")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[Required(ErrorMessage = "{0} is required.")]
		//[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Juridical, ErrorMessage = "{0} is required for juridcal person.")]
		public string SecondDocumentNumber
		{
			get { return _secondDocumentNumber; }
			set { SetField(ref _secondDocumentNumber, value); }
		}


		#region RELATIONSHIP
		// FK
		//public PersonNaturalDetails PersonNaturalDetails { get; set; }
		//public List<Adress> AdressList { get; set; }
		#endregion


		#region METHODS
		public void CreateBasePeson()
		{
			this.PersonLegalKind = PersonLegalKindEnum.Empty;
			this.OficialName = OficialName;
			this.AlternativeName = AlternativeName;
			this.MainDocumentNumber = MainDocumentNumber;
			this.SecondDocumentNumber = SecondDocumentNumber;
			//this.AdressList = new List<Adress>();
			this.ForceValidation();
		}
		public void CreateNaturalPerson() {
			CreateBasePeson();
			this.PersonLegalKind = PersonLegalKindEnum.Natural;
			//this.PersonNaturalDetails = new PersonNaturalDetails();

		}
		#endregion


		#region CONSTRUCTORS
		public Person()
		{
			CreateBasePeson();

		}

		public Person(PersonLegalKindEnum personLegalKindType = PersonLegalKindEnum.Empty)
		{
			switch (personLegalKindType)
			{
				case PersonLegalKindEnum.Empty:
					CreateBasePeson();
					break;
				case PersonLegalKindEnum.Natural:
					CreateNaturalPerson();
					break;
				case PersonLegalKindEnum.Juridical:
					CreateBasePeson();
					break;
				default:
					CreateBasePeson();
					break;
			}
		}

		#endregion
	}

}

#endregion