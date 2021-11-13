using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
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

		public class ValidKindPerson : ValidationAttribute
		{
			public override bool IsValid(object value)
			{
				//DateTime dateTime = Convert.ToDateTime(value);
				//return dateTime <= DateTime.Now;
				try
				{
					var newValue = Convert.ToInt32(value);
					if (Enum.IsDefined(typeof(PersonModel.PersonLegalKindEnum), newValue))
						return true;
					else return false;
				}
				catch (Exception ex)
				{
					return false;
				}
			}

			protected override ValidationResult IsValid(object value, ValidationContext context)
			{
				ValidationResult result = base.IsValid(value, context) ?? null;
				if (result != null)
				{
					if (String.IsNullOrEmpty(ErrorMessage)) result.ErrorMessage = $"{context.DisplayName} invalid value.";
					return result;

				}
				else
					return ValidationResult.Success;
			}

		}

		public class OnlyLetterAndNumbers : ValidationAttribute
		{
			public override bool IsValid(object value)
			{
				var r = @"^[a-zA-Z0-9_.-]*$";
				var match = Regex.IsMatch(value.ToString(), r);

				if (match) return true;
				else return false;
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
