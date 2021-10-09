using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models.Bases
{
    public class BaseValidation : INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        [NotMapped]
        public ObservableCollection<string> ErrorList { get; set; } = new ObservableCollection<string>();

        //public void ClearErrorList()
        //{
        //    _errors.Clear();
        //}


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private object _lock = new object();

        public bool HasErrors { get { return _errors.Any(propErrors => propErrors.Value != null && propErrors.Value.Count > 0); } }
        //public bool HasErrors
        //{
        //    get
        //    {
        //        return GetErrors(null).OfType<object>().Any();
        //    }
        //}





        public bool IsValid { get { return !this.HasErrors; } }

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

        public void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

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

            //add to listo que a viewmodel usa para exibir
            ErrorList.Clear();
            foreach (var x in _errors)
            {

                foreach (var y in x.Value)
                {
                    ErrorList.Add(y.ToString());
                }
            }
        }



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


        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}


        //protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(sender, e);
        //    }
        //}

        //public virtual void ForceValidation()
        //{
        //    OnPropertyChanged(null);
        //}











    }
}
