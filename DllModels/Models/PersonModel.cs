using DllModels.Models.Bases;
using static DllModels.Models.CustomValidations.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace DllModels.Models
{
	public abstract class PersonModel : BaseClass
	{
		#region CONSTRUCTORS
		/// <summary>
		/// Construct to create a Person and also validate all rules.
		/// </summary>
		/// <param name="personLegalKindType">Choose what kind of Person what to create. Default is natural personal. </param>
		public PersonModel(PersonLegalKindEnum personLegalKindType = PersonLegalKindEnum.Natural)
		{
			CreatePerson(personLegalKindType);
		}


		#endregion CONSTRUCTORS

		#region PROPERTIES
		/// <summary>
		/// Kind of legal person possible to use. See definiton in https://en.wikipedia.org/wiki/Legal_person
		/// Natual = 1,
		/// Juridical = 2.
		/// </summary>
		public enum PersonLegalKindEnum
		{
			Natural = 1,
			Juridical = 2
		}


		/// <summary>
		/// Kind of person use by system definition
		/// </summary>
		public enum PersonSystemKindEnum
		{
			Empty = 0,
			NotDefiniedYet = 999,
			Employer = 1,
			Client = 2,
			Provider = 3
		}


		private int _personId;
		/// <summary>
		/// Person ID used as unique key in database.
		/// Uses JsonIgnore.
		/// </summary>
		[KeyAttribute]
		[JsonIgnore]
		public int PersonId
		{
			get { return _personId; }
			protected set
			{
				SetField(ref _personId, value);
			}
		}


		/// <summary>
		/// Kind of legal person possible to use. See definiton in https://en.wikipedia.org/wiki/Legal_person
		/// </summary>
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
			}
		}


		private string _officialName = null;
		/// <summary>
		/// Person official name.
		/// </summary>
		[Display(Name = "Official name")]
		//[TesteValidation]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[Required(ErrorMessage = "{0} is required.")]
		public string OfficialName
		{
			get { return _officialName; }
			set
			{
				SetField(ref _officialName, value);
				ValidateProperty(value);
			}
		}


		private string _alternativeName = null;
		/// <summary>
		/// Person alternative name.
		/// </summary>
		[Display(Name = "Alternative name")]
		//[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Juridical, ErrorMessage = "{0} is required for juridical person.")]
		public string AlternativeName
		{
			get { return _alternativeName; }
			set
			{
				SetField(ref _alternativeName, value);
			}
		}


		private string _mainDocumentNumber;
		/// <summary>
		/// Person main document number.
		/// </summary>
		[Display(Name = "Main document number")]
		[Required(ErrorMessage = "{0} is required.")]
		[OnlyLetterAndNumbers(ErrorMessage ="{0} must have only number and letter.")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		//[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Juridical, ErrorMessage = "{0} is required for juridcal person.")]
		public string MainDocumentNumber
		{
			get { return _mainDocumentNumber; }
			set { SetField(ref _mainDocumentNumber, value);
				ValidateProperty(value); 
			}
		}


		private string _secondDocumentNumber;
		/// <summary>
		/// Person second document number.
		/// </summary>
		[Display(Name = "Second document number")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[Required(ErrorMessage = "{0} is required.")]
		//[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Juridical, ErrorMessage = "{0} is required for juridcal person.")]
		public string SecondDocumentNumber
		{
			get { return _secondDocumentNumber; }
			set { SetField(ref _secondDocumentNumber, value); }
		}


		private string _note;
		/// <summary>
		/// Person note.
		/// </summary>
		[Display(Name = "Note")]
		public string FreeField
		{
			get { return _note; }
			set { SetField(ref _note, value); }
		}


		#endregion PROPERTIES

		#region METHODS
		/// <summary>
		/// Private method to create a person.
		/// </summary>
		/// <param name="personLegalKindType">Kind of Person</param>
		public void CreatePerson(PersonLegalKindEnum personLegalKindType)
		{
			switch (personLegalKindType)
			{
				case PersonLegalKindEnum.Natural:
					MakeThisNaturalPerson();
					break;
				case PersonLegalKindEnum.Juridical:
					MakeThisJuridicalPeson();
					break;
				default:
					this.ValidateObject();
					break;
			}
		}


		/// <summary>
		/// Change the type of PersonLegalKind and validate the object rules.
		/// </summary>
		public void MakeThisNaturalPerson()
		{
			PersonLegalKind = PersonLegalKindEnum.Natural;
			ValidateObject();

		}


		/// <summary>
		/// Change the type of PersonLegalKind and validate the object rules.
		/// </summary>
		private void MakeThisJuridicalPeson()
		{
			PersonLegalKind = PersonLegalKindEnum.Juridical;
			ValidateObject();
		}
		#endregion METHODS

	}

}

