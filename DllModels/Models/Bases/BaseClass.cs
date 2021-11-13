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
		/// <summary>
		/// This constructor generate a new GUID return a isModified = false
		/// </summary>
		public BaseClass()
		{
			this.GUID = Guid.NewGuid().ToString();
			NotifyDataChange(false);


		}
		#endregion CONSTRUCTORS

		#region PROPERTIES
		private int _Id;
		/// <summary>
		/// ID used as unique key in database.
		/// Uses JsonIgnore.
		/// </summary>
		[KeyAttribute]
		//[JsonIgnore]
		public int Id
		{
			get { return _Id; }
			private set
			{
				SetField(ref _Id, value);
			}
		}
		private Boolean _isActive = false;
		/// <summary>
		/// Return if this object is active in database. 
		/// The propoerty must use "SetField".
		/// </summary>
		//[JsonIgnore]
		[NotMapped]
		[Display(Name = "Is this Active in DataBase?")]
		public bool IsActive
		{
			get { return _isActive; }
			private protected set
			{
				SetField(ref _isActive, value);
			}
		}


		private Boolean _isModified = false;
		/// <summary>
		/// Return if this object have they properties changed. 
		/// The propoerty must use "SetField".
		/// </summary>
		//[JsonIgnore]
		[NotMapped]
		[Display(Name = "Is this modified?")]
		public bool isModified
		{
			get { return _isModified; }
			private protected set
			{
				SetField(ref _isModified, value);
			}
		}

		private DateTime? _createdAt;
		/// <summary>
		/// Date when object is saved in database.
		/// This property have implemented JsonIgnore.
		/// </summary>
		//[JsonIgnore]
		[Display(Name = "Created at")]
		public DateTime? CreatedAt
		{
			get { return _createdAt; }
			private protected set
			{
				SetField(ref _createdAt, (DateTime)value);
			}
		}


		private DateTime? _changedAt;
		/// <summary>
		/// Date when object is edited in database.
		/// This property have implemented JsonIgnore.
		/// </summary>
		//[JsonIgnore]
		[Display(Name = "Changed at")]
		public DateTime? ChangedAt
		{
			get { return _changedAt; }
			private protected set
			{
				SetField(ref _changedAt, (DateTime)value);
			}
		}


		private DateTime? _deletedAt;
		/// <summary>
		/// Date when object is deleted (logic mode) in database.
		/// This property have implemented JsonIgnore.
		/// </summary>
		//[JsonIgnore]
		[Display(Name = "Deleted at")]
		public DateTime? DeletedAt
		{
			get { return _deletedAt; }
			private protected set
			{
				SetField(ref _deletedAt, (DateTime)value);
			}
		}


		private string _guid;
		/// <summary>
		/// The GUID is generated when create the instance of object. This can not be changed.
		/// </summary>
		[Display(Name = "GUID")]
		public string GUID
		{
			get { return _guid; }
			private set
			{
				SetField(ref _guid, value);
			}
		}


		private int _Version = 0;
		/// <summary>
		/// The new object start with version 0. 
		/// Every time when it have database changes, it increment +1.
		/// </summary>
		//[JsonIgnore]
		[Display(Name = "Version")]
		public int Version
		{
			get { return _Version; }
			protected set
			{
				SetField(ref _Version, value);
			}
		}


		#endregion PROPERTIES

		#region METHODS
		/// <summary>
		/// Set database creation DateTime.
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns>CreatedAt</returns>
		public DateTime? SetCreatedAt(DateTime? dateTime = null)
		{
			CreatedAt = dateTime ?? DateTime.Now;
			return CreatedAt;
		}

		/// <summary>
		/// Set database edited DateTime.
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns>ChangedAt</returns>
		public DateTime? SetChangedAt(DateTime? dateTime = null)
		{
			ChangedAt = dateTime ?? DateTime.Now;
			return ChangedAt;
		}

		/// <summary>
		/// Set database deleted DateTime.
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns>DeletedAt</returns>
		public DateTime? SetDeletedAt(DateTime? dateTime = null)
		{
			DeletedAt = dateTime ?? DateTime.Now;
			return DeletedAt;
		}
		/// <summary>
		/// ICloneable interface implementation.
		/// </summary>
		/// <returns>Return the object clone.</returns>
		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Used to notify that a property have changes.
		/// </summary>
		/// <param name="propertyName">Property Name</param>
		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Use this to change the value of a property. 
		/// When use it, the property have the validation done.
		/// When use it, the proprty isModified sets true (CreatedAt and isModified don't).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="field">Refered propertie</param>
		/// <param name="value">New value</param>
		/// <param name="propertyName"></param>
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
					this.NotifyDataChange();
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

		/// <summary>
		/// This notify that this object have changes.
		/// </summary>
		/// <param name="_bool"></param>
		private void NotifyDataChange(bool _bool = true)
		{
			if (_bool == false) this.isModified = false;
			else
			{
				this.isModified = true;
			}
		}


		/// <summary>
		/// It's created to solve a problem validation in WPF UI.
		/// </summary>
		public virtual void ForceValidation()
		{
			OnPropertyChanged(null);
		}


		#endregion METHODS







	}
}
