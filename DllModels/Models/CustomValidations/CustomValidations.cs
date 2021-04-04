using System;
using System.ComponentModel.DataAnnotations;

namespace DllModels.Models.CustomValidations
{
    class CustomValidations
    {
        public class CPFCNPJValidation : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                //DateTime dateTime = Convert.ToDateTime(value);
                //return dateTime <= DateTime.Now;
                string valor = Convert.ToString(value);
                if (valor == "123") return true;
                else return false;
                //return true;
            }
        }


        public class NaoPodeVazio : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                //DateTime dateTime = Convert.ToDateTime(value);
                //return dateTime <= DateTime.Now;
                string valor = Convert.ToString(value);
                if (valor != null) return true;
                else return false;
                //return true;
            }
        }
    }
}
