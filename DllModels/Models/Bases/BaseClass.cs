using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models.Bases
{
    public abstract class BaseClass : BaseValidation, INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                if (propertyName != "CreatedAt") this._changedAt = DateTime.Now;
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }



        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public virtual void ForceValidation()
        {
            OnPropertyChanged(null);
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
		{
            get { return _createdAt; }
            protected set
            {
                SetField(ref _createdAt, (DateTime)value);
                ValidateProperty(value);
            }
        }

        private DateTime? _changedAt;
        public DateTime? ChangedAt
        {
            get { return _changedAt; }
            protected set
            {
                SetField(ref _changedAt, (DateTime)value);
                ValidateProperty(value);
            }
        }

        private DateTime? _deletedAt;
        public DateTime? DeletedAt
        {
            get { return _deletedAt; }
            protected set
            {
                SetField(ref _deletedAt, (DateTime)value);
                ValidateProperty(value);
            }
        }

        public BaseClass()
		{
            CreatedAt = DateTime.Now;
		}

    }
}
