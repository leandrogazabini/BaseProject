using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models
{


    public class ObjectTest : BaseClass
    {
        #region PROPERTIES
        public int id { get; set; }

        //[NotMapped]
        //[Required(ErrorMessage = "{0} precisa ser informado.")]
        //[MaxLength(14, ErrorMessage = "{0} não pode ter mais de 14 números.")]
        //[CPFCNPJValidation(ErrorMessage = "{0} tem que ser 123")] //ver Models/CustomValidations para mais informação
        //[NaoPodeVazio(ErrorMessage = "{0} nao pode vazio")] //ver Models/CustomValidations para mais informação
        [MinLength(3, ErrorMessage = "{0} dígitos insuficientes.")]
        [Display(Name = "Atributo 1")]
        [Required(ErrorMessage = "{0} precisa ser informado.")]
        public string Atrib1 { get; set; }

        public string Atrib2 { get; set; }

        public string? Atrib3 { get; set; }

        [Required(ErrorMessage = "{0} precisa ser informado.")]
        public string? Atrib4 { get; set; }
        #endregion

        #region METHODS
        public ObjectTest ReturnObject(string a1 = null, string a2 = null)
        {
            ObjectTest objCreated = new ObjectTest { Atrib1 = a1, Atrib2 = a2, Atrib3 = "", Atrib4 = ""};
            return objCreated;
        }
        #endregion
    }

}

