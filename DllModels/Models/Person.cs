using DllModels.Models.Bases;
using System;
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

		#region PROPERTIES
		// Id
		private int _personId;
		private int PersonId
		{
			get { return _personId; }
			set
			{
				SetField(ref _personId, value);
				ValidateProperty(value);
			}
		}

		//public int RegisterVersion { get; set; }

		//UUID
		private string _personUuid;
		[KeyAttribute]
		[Display(Name = "Person UUID")]
		public string PersonUuid
		{
			get { return _personUuid; }
			private set
			{
				SetField(ref _personUuid, value);
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
		private string _oficialName = string.Empty;
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
		private string _alternativeName = string.Empty;
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


		#region METHODS

		public Person()
		{
			this.PersonUuid = Guid.NewGuid().ToString();
			this.PersonLegalKind = PersonLegalKindEnum.Empty;
			this.OficialName = OficialName;
			this.ForceValidation();
		}

		#endregion
	}

}

#endregion