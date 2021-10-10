using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using DllModels.Models.Bases;

namespace DllModels.Models.CustomValidations
{
	class CustomValidations : BaseValidation
	{
		public class TesteValidation : ValidationAttribute
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

			protected override ValidationResult IsValid(object value, ValidationContext context)
			{
				ValidationResult result = base.IsValid(value, context) ?? null;
				if (result != null)
				{
					if (String.IsNullOrEmpty(ErrorMessage)) result.ErrorMessage = $"{context.DisplayName} is not 123.";
					return result;

				}
				else
				return ValidationResult.Success;
			}

		}



		public class RequiredIfAttribute : RequiredAttribute // here -> https://stackoverflow.com/questions/7390902/requiredif-conditional-validation-attribute
		{
			private String PropertyName { get; set; }
			private Object DesiredValue { get; set; }

			public RequiredIfAttribute(String propertyName, Object desiredvalue)
			{
				PropertyName = propertyName;
				DesiredValue = desiredvalue;
			}

			protected override ValidationResult IsValid(object value, ValidationContext context)
			{
				Object instance = context.ObjectInstance;
				Type type = instance.GetType();
				Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
				if (proprtyvalue.ToString() == DesiredValue.ToString())
				{
					ValidationResult result = base.IsValid(value, context);
					return result;
				}
				return ValidationResult.Success;
			}
		}
	}
}
