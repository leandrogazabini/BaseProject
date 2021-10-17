using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DllModels.Models.Bases
{
	public class BaseValidation : INotifyDataErrorInfo
	{

		#region CONSTRUCTORS
		#endregion CONSTRUCTORS

		#region PROPERTIES
		/// <summary>
		/// Dictionary used to list the errors of property validation.
		/// </summary>
		private Dictionary<string, List<string>> _errors { get; set; } = new Dictionary<string, List<string>>();


		/// <summary>
		/// List of error(s) of last object validation.
		/// This use JsonIgnore.
		/// </summary>
		[JsonIgnore]
		[NotMapped]
		protected ObservableCollection<string> ErrorList { get;  set; } = new ObservableCollection<string>();


		/// <summary>
		///	Return if this object have any validation error while validation last property.
		/// This use JsonIgnore.
		/// </summary>
		[JsonIgnore]
		public bool HasErrors { get { return _errors.Any(propErrors => propErrors.Value != null && propErrors.Value.Count > 0); } }


		/// <summary>
		///	Return if this object have any validation error in all properties.
		/// This use JsonIgnore.
		/// </summary>
		[JsonIgnore]
		[System.ComponentModel.DefaultValue(false)]
		public bool HasErrorObject { get { return ErrorList.Any(); } }


		/// <summary>
		///	Return the status of the last property validation
		/// This use JsonIgnore.
		/// </summary>
		[JsonIgnore]
		[System.ComponentModel.DefaultValue(false)]
		public bool IsValid { get { return !this.HasErrors; } }

		/// <summary>
		///	Return the status of the object validation
		/// This use JsonIgnore.
		/// </summary>
		[JsonIgnore]
		[System.ComponentModel.DefaultValue(false)]
		public bool IsValidObject { get { return !this.HasErrorObject; } }


		/// <summary>
		/// This is used to create validation process.
		/// </summary>
		private object _lock = new object();

		#endregion PROPERTIES


		#region METHODS
		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


		/// <summary>
		/// Used in validation process.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		public void OnErrorsChanged(string propertyName)
		{
			if (ErrorsChanged != null)
				ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
		}


		/// <summary>
		/// Used in validation proccess.
		/// </summary>
		/// <param name="validationResults">Result.</param>
		private void HandleValidationResults(List<ValidationResult> validationResults)
		{
			//Group validation results by property names  
			var resultsByPropNames = from res in validationResults
									 from mname in res.MemberNames
									 group res by mname into g
									 select g;
			//add _errors to dictionary and inform binding engine about _errors  
			foreach (var prop in resultsByPropNames)
			{
				var messages = prop.Select(r => r.ErrorMessage).ToList();
				_errors.Add(prop.Key, messages);
				OnErrorsChanged(prop.Key);
			}
		}


		/// <summary>
		/// Gets the error of a property validation.
		/// </summary>
		/// <param name="propertyName">Property name</param>
		/// <returns>Return a List</returns>
		public IEnumerable GetErrors(string propertyName)
		{
			if (!string.IsNullOrEmpty(propertyName))
			{
				if (_errors.ContainsKey(propertyName) && (_errors[propertyName] != null) && _errors[propertyName].Count > 0)
				{
					return _errors[propertyName].ToList();
				}
				else
					return null;
			}
			else
			{
				return _errors.SelectMany(err => err.Value.ToList());
			}
		}


		/// <summary>
		/// Validade a only one property by validation rules.
		/// </summary>
		/// <param name="value">New value.</param>
		/// <param name="propertyName">Property name.</param>
		public void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
		{
			lock (_lock)
			{
				var validationContext = new ValidationContext(this, null, null);
				validationContext.MemberName = propertyName;
				var validationResults = new List<ValidationResult>();
				Validator.TryValidateProperty(value, validationContext, validationResults);

				//clear previous _errors from tested property  
				if (_errors.ContainsKey(propertyName))
					_errors.Remove(propertyName);
				OnErrorsChanged(propertyName);
				HandleValidationResults(validationResults);
			}
			ErrorList.Clear();
			foreach (var x in _errors)
			{

				foreach (var y in x.Value)
				{
					ErrorList.Add(y.ToString());
				}
			}
		}


		/// <summary>
		/// Use this to validate all object validation rules.
		/// </summary>
		/// <returns>Return true if all validations is ok.</returns>
		public bool ValidateObject()
		{
			lock (_lock)
			{
				var validationContext = new ValidationContext(this, null, null);
				var validationResults = new List<ValidationResult>();
				try
				{
					var r = Validator.TryValidateObject(this, validationContext, validationResults,true);

				}
				catch (Exception)
				{

					throw;
				}

				//clear previous _errors from tested property  
				ErrorList.Clear();
				foreach (var item in validationResults)
				{
					if (!ErrorList.Contains(item.ErrorMessage)) ErrorList.Add(item.ErrorMessage.ToString());
				}
				if (ErrorList.Any()) return false;
				else return true;
			}

		}


		#endregion METHODS

	}
}
