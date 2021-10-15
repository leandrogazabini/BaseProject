using DllModels.Models.Bases;
using System.ComponentModel.DataAnnotations;
using static DllModels.Models.CustomValidations.CustomValidations;

namespace DllModels.Models
{

	public abstract class PersonModel : BaseClass
	{

		#region PROPERTIES

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
			}
		}


		//OFFICIAL NAME
		private string _oficialName = null;
		[Display(Name = "Official name")]
		[TesteValidation]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[Required(ErrorMessage = "{0} is required.")]
		public string OficialName
		{
			get { return _oficialName; }
			set
			{
				SetField(ref _oficialName, value);
			}
		}


		//ALTERNATIVE NAME
		private string _alternativeName = null;
		[Display(Name = "Alternative name")]
		//[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
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
		[Display(Name = "Second document number")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		[Required(ErrorMessage = "{0} is required.")]
		//[RequiredIf("PersonLegalKind", PersonLegalKindEnum.Juridical, ErrorMessage = "{0} is required for juridcal person.")]
		public string SecondDocumentNumber
		{
			get { return _secondDocumentNumber; }
			set { SetField(ref _secondDocumentNumber, value); }
		}

		private string _test;
		[Display(Name = "Teste")]
		[MinLength(2, ErrorMessage = "{0} must have at least 2 caracters.")]
		public string Teste
		{
			get { return _test; }
			set { SetField(ref _test, value); }
		}


		#region METHODS
		public PersonModel CreateBasePeson()
		{
			//this.PersonLegalKind = PersonLegalKindEnum.Empty;
			//this.OficialName = OficialName;
			//this.AlternativeName = AlternativeName;
			//this.MainDocumentNumber = MainDocumentNumber;
			//this.SecondDocumentNumber = SecondDocumentNumber;
			//this.AdressList = new List<Adress>();
			this.ValidateObject();
			return this;

		}
		public void CreateNaturalPerson()
		{
			CreateBasePeson();
			this.PersonLegalKind = PersonLegalKindEnum.Natural;
			//this.PersonNaturalDetails = new PersonNaturalDetails();

		}


		private void MakeItJuridicalPeson()
		{
			PersonLegalKind = PersonLegalKindEnum.Juridical;
			ValidateObject();

		}
		#endregion


		#region CONSTRUCTORS
		//public Person()
		//{
		//	CreateBasePeson();
		//	NotifyDataChange(false);

		//}

		/// <summary>
		///		This constructor create a person.
		/// </summary>
		public PersonModel(PersonLegalKindEnum personLegalKindType = PersonLegalKindEnum.Empty)
		{
			switch (personLegalKindType)
			{
				case PersonLegalKindEnum.Empty:
					CreateBasePeson();
					break;
				case PersonLegalKindEnum.Natural:
					CreateBasePeson();
					break;
				case PersonLegalKindEnum.Juridical:
					CreateBasePeson();
					MakeItJuridicalPeson();
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