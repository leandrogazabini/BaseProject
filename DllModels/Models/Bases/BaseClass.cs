using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DllModels.Models.Bases
{
	public abstract class BaseClass : BaseValidation, INotifyPropertyChanged, ICloneable
	{


		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public object Clone()
		{
			return this.MemberwiseClone();
		}

		protected void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(field, value))
			{
				field = value;
				RaisePropertyChanged(propertyName);
				if (propertyName == "CreatedAt" || propertyName == "isModified")
				{
			
				}
				else
				{
					this._changedAt = DateTime.Now;
					this.NotifyDataChange();
				}
			

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



		[NotMapped]
		[Display(Name = "Is this modified?")]
		private Boolean _isModified = false;
		public bool isModified
		{
			get { return _isModified; }
			protected set
			{
				SetField(ref _isModified, value);
				ValidateProperty(value);
			}
		}

		public void NotifyDataChange(bool _bool = true)
		{
			if (_bool == false) this.isModified = false;
			else
			{
				this.isModified = true;
			}
		}



		[Display(Name = "Created at")]
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


		[Display(Name = "Changed at")]
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
		[Display(Name = "Deleted at")]
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


		//UUID
		private string _Uuid;
		[Display(Name = "UUID")]
		public string Uuid
		{
			get { return _Uuid; }
			private set
			{
				SetField(ref _Uuid, value);
				ValidateProperty(value);
			}
		}


		//VERSION
		private int _Version = 1;
		[Display(Name = "Version")]
		public int Version
		{
			get { return _Version; }
			private set
			{
				SetField(ref _Version, value);
				ValidateProperty(value);
			}
		}
		public void IncrementVersion()
		{
			this.Version = this.Version + 1;
		}

		public BaseClass()
		{
			CreatedAt = DateTime.Now;
			this.Uuid = Guid.NewGuid().ToString();
			NotifyDataChange(false);
		}

	}
}
