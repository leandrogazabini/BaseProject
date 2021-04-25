using DllModels.Models.Bases;
using System;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace WptfTest.Models
{
	#region MAIN MENU
	public class MenuItens : BaseClass
	{
		#region ATRIBUTES

		private string _menuName;
		public string MenuName
		{
			get { return _menuName; }
			set { SetField(ref _menuName, value); }
		}

		private bool _visibility = false;
		public bool Visibility
		{
			get { return _visibility; }
			set { SetField(ref _visibility, value); }
		}

		public ObservableCollection<MenuN1Sub> MenuN1SubList { get; set; }

		 // menu
		 //		menun1sublist
		 //			menun1item
		#endregion
		#region METHODS
		
		public MenuItens(string menuName = "Not implemented")
		{


			MenuN1Item MenuN1Item = new MenuN1Item
			{
				MenuN1ItemName = "Open Main View!",
				MenuN1ITags = {"example","tag", "main", "view" },
				MenuN1IToolTip = "Tooltip come here, and a lot of information cam be placed here.",
				Visibility = true,
				MenuN1ItemType = MenuN1Item.MenuN1ItemTypes.MainTabNewItem,
				MenuN1ItemParameter = MenuN1Item.MenuN1ItemParameters.MainViewModel
			};

			MenuN1Item MenuN1Item2 = new MenuN1Item
			{
				MenuN1ItemName = "Open Test View!",
				MenuN1ITags = { "test" },
				MenuN1IToolTip = "Another Tooltip come here, and a lot of information cam be placed here.",
				Visibility = true,
				MenuN1ItemType = MenuN1Item.MenuN1ItemTypes.MainTabNewItem,
				MenuN1ItemParameter = MenuN1Item.MenuN1ItemParameters.TestViewModel
			};
			
			this.MenuName = menuName;
			this.MenuN1SubList = new ObservableCollection<MenuN1Sub>();
			
			var MenuN1Sub = new MenuN1Sub();
			MenuN1Sub.MenuN1ItensList = new ObservableCollection<MenuN1Item>();
			MenuN1Sub.MenuN1Name = "Submenu 1 here";
			MenuN1Sub.Visibility = true;

			var MenuN1Sub2 = new MenuN1Sub();
			MenuN1Sub2.MenuN1ItensList = new ObservableCollection<MenuN1Item>();
			MenuN1Sub2.MenuN1Name = "Submenu 2 here";
			MenuN1Sub2.Visibility = true;
			
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub2.MenuN1ItensList.Add(MenuN1Item2);
		
			this.MenuN1SubList.Add(MenuN1Sub);
			this.MenuN1SubList.Add(MenuN1Sub2);
			
			
		
			//var MenuItens = new MenuItens();


		}
		#endregion


		#region FIRST CLASS MENU
		public class MenuN1Sub : BaseClass
		{

			private string _menuN1Name;
			public string MenuN1Name
			{
				get { return _menuN1Name; }
				set { SetField(ref _menuN1Name, value); }
			}


			private bool _visibility = false;
			public bool Visibility
			{
				get { return _visibility; }
				set { SetField(ref _visibility, value); }
			}



			public ObservableCollection<MenuN1Item> MenuN1ItensList { get; set; }

		}
		#endregion

		#region FIRST CLASS ITEMS
		public class MenuN1Item : BaseClass, IConvertible
		{
			
			#region IConvertible
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
			#endregion Interface implementation
			//Name that shows in menu
			private string _menuN1ItemName;
			public string MenuN1ItemName
			{
				get { return _menuN1ItemName; }
				set { SetField(ref _menuN1ItemName, value); }
			}

			public ObservableCollection<string> MenuN1ITags { get; set; }

			private string _menuN1IToolTip;
			public string MenuN1IToolTip
			{
				get { return _menuN1IToolTip; }
				set { SetField(ref _menuN1IToolTip, value); }
			}

			//VIsibility property in menu
			private bool _visibility = false;
			public bool Visibility
			{
				get { return _visibility; }
				set { SetField(ref _visibility, value); }
			}

			//Types of Items. It's applied as param in command that open the item
			public enum MenuN1ItemTypes
			{
				MainTabNewItem = 1
			}

			//Types of this item. It's applied as param in command that open the item
			public MenuN1ItemTypes MenuN1ItemType
			{
				get; set;
			}


			//Params about this item. It's applied as param in command that open the item
			public enum MenuN1ItemParameters
			{
				LoggedUserViewModel =0,
				TestViewModel = 1,
				MainViewModel = 2
			}
			//Param about this item. It's applied as param in command that open the item
			private MenuN1ItemParameters _menuN1ItemParameter;
			public MenuN1ItemParameters MenuN1ItemParameter
			{
				get { return _menuN1ItemParameter; }
				set { SetField(ref _menuN1ItemParameter, value); }
			}


			public MenuN1Item()
			{
				MenuN1ITags = new ObservableCollection<string>();
			}
		}
		#endregion

		#region MenuPermissionsToViewModel

		#endregion

	}
	#endregion


}
