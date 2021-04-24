using DllModels.Models.Bases;
using System;
using System.Windows;
using static WptfTest.Models.MenuItens.MenuN1Item;

namespace WptfTest.Models.BaseViewModels
{
	class BaseViewModel : BaseClass, System.IConvertible
	{
		#region IConvertible Interface
		public TypeCode GetTypeCode()
		{
			return TypeCode.Object;
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public byte ToByte(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public char ToChar(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public double ToDouble(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public short ToInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public int ToInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public long ToInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public float ToSingle(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public string ToString(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}
		#endregion


		private string _viewTitle = "Not implemented";
		public string ViewTitle
		{
			get { return _viewTitle; }
			set
			{
				SetField(ref _viewTitle, value);
			}
		}

		public MenuN1ItemParameters MenuN1ItemParameter { get; set; }
		

		private string _viewHelpMessage = "Not implemented";
		public string ViewHelpMessage
		{
			get { return _viewHelpMessage; }
			set
			{
				SetField(ref _viewHelpMessage, value);
			}
		}


		private bool _visibility = true;
		public bool Visibility
		{
			get { return _visibility; }
			set { SetField(ref _visibility, value); }
		}


		public ViewModelPermissions ViewModelPermissions { get; set; }

		public bool SetViewModelPermissions(ViewModelPermissions viewModelPermissions = null)
		{
			if (viewModelPermissions == null)
			{
				this.ViewModelPermissions = new ViewModelPermissions();
			}
			else
			{
				this.ViewModelPermissions = viewModelPermissions;
			}

			return true;
		}


		public BaseViewModel(ViewModelPermissions viewModelPermissions = null, bool visibility = false)
		{
			SetViewModelPermissions();
			this.Visibility = visibility;
		}



	}
}
