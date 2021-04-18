using DllModels.Models.Bases;
using System.ComponentModel.DataAnnotations;



namespace DllModels.Models
{


	public class Person : BaseClass
    {
        #region PROPERTIES
        public int PersonId { get; set; }

        //public int RegisterVersion { get; set; }

        private string _oficialName;

        [MinLength(3, ErrorMessage = "{0} dígitos insuficientes.")]
        [Display(Name = "Atributo 1")]
        [Required(ErrorMessage = "{0} precisa ser informado.")]
        public string OficialName
        {
            get { return _oficialName; }
            set { SetField(ref _oficialName, value);
                ValidateProperty(value);
            }
        }

        private string _alternativeName;
        public string AlternativeName
        {
            get { return _alternativeName; }
            set { SetField(ref _alternativeName, value); }
        }

        private string _nickname;
        public string Nickname
        {
            get { return _nickname; }
            set { SetField(ref _nickname, value); }
        }

        private string _mainDocumentNumber;
        public string MainDocumentNumber
        {
            get { return _mainDocumentNumber; }
            set { SetField(ref _mainDocumentNumber, value); }
        }

        private string _alternativeDocumentNumber;
        public string AlternativeDocumentNumber
        {
            get { return _alternativeDocumentNumber; }
            set { SetField(ref _alternativeDocumentNumber, value); }
        }
        #endregion




        #region METHODS
        public Person CreatePerson(string OficialName = null,
                                   string AlternativeName = null,
                                   string Nickname = null,
                                   string MainDocumentNumber = null,
                                   string AlternativeDocumentNumber = null)
        {

            this.OficialName = OficialName;
            this.AlternativeName = AlternativeName;
            this.Nickname = Nickname;
            this.MainDocumentNumber = MainDocumentNumber;
            this.AlternativeDocumentNumber = AlternativeDocumentNumber;
            return this;
        }
        
        #endregion
    }

}

