using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DllModels.Models.Bases
{
	public abstract class BaseClass : BaseValidation, INotifyPropertyChanged, ICloneable
	{
		//#region CONSTRUCTORS
		//#endregion CONSTRUCTORS

		//#region PROPERTIES
		//#endregion PROPERTIES

		//#region METHODS
		//#endregion METHODS

		#region CONSTRUCTORS
		public BaseClass()
		{
			//CreatedAt = DateTime.Now; just set created when recorded in db
			this.Uuid = Guid.NewGuid().ToString();
			NotifyDataChange(false);


		}
		#endregion CONSTRUCTORS

		#region PROPERTIES

		private Boolean _isModified = false;
		[JsonIgnore]
		[NotMapped]
		[Display(Name = "Is this modified?")]
		public bool isModified
		{
			get { return _isModified; }
			protected set
			{
				SetField(ref _isModified, value);
				ValidateProperty(value);
			}
		}




		private DateTime? _createdAt;
		[JsonIgnore]
		[Display(Name = "Created at")]
		public DateTime? CreatedAt
		{
			get { return _createdAt; }
			protected set
			{
				SetField(ref _createdAt, (DateTime)value);
				ValidateProperty(value);
			}
		}

		private DateTime? _changedAt;
		[JsonIgnore]
		[Display(Name = "Changed at")]
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
		[JsonIgnore]
		[Display(Name = "Deleted at")]
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
		private int _Version = 0;
		[JsonIgnore]
		[Display(Name = "Version")]
		public int Version
		{
			get { return _Version; }
			protected set
			{
				SetField(ref _Version, value);
				ValidateProperty(value);
			}
		}


		#endregion PROPERTIES

		#region METHODS
		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}

		protected void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(field, value))
			{
				field = value;
				try
				{
					ValidateProperty(value, propertyName);

				}
				catch { }
				RaisePropertyChanged(propertyName);
				if (propertyName == "CreatedAt" || propertyName == "isModified") { }
				else
				{
					//this._changedAt = DateTime.Now; use when record in db
					this.NotifyDataChange();
					//this.ForceValidation();
				}


			}
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


		public void NotifyDataChange(bool _bool = true)
		{
			if (_bool == false) this.isModified = false;
			else
			{
				this.isModified = true;
			}
		}


		#endregion METHODS



		

		

	}
}
