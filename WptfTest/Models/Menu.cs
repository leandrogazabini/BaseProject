using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		#endregion

		#region METHODS
		//public MenuItens CreateMenu(string menuName = "sem nome de menu")
		//{
		//	MenuN1Item MenuN1Item = new MenuN1Item { MenuN1ItemName = "nome do item do menu 1" };
		//	var MenuN1ItensList = new ObservableCollection<MenuN1Item>();
		//	var MenuN1Sub = new MenuN1Sub();
		//	MenuN1Sub.MenuN1Name = "Name do menu 1";
		//	MenuN1Sub.MenuN1ItensList = new ObservableCollection<MenuN1Item>();
		//	MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
		//	MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
		//	MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
		//	MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
		//	var MenuN1SubList = new ObservableCollection<MenuN1Sub>();
		//	var MenuItens = new MenuItens();
		//	MenuItens.MenuName = menuName;
		//	MenuItens.MenuN1SubList = new ObservableCollection<MenuN1Sub>();
		//	MenuItens.MenuN1SubList.Add(MenuN1Sub);
		//	MenuItens.MenuN1SubList.Add(MenuN1Sub);
		//	MenuItens.MenuN1SubList.Add(MenuN1Sub);

		//	return MenuItens;
		//}
		public MenuItens(string menuName = "sem nome de menu")
		{
			var MenuN1Sub = new MenuN1Sub();

			var MenuN1ItensList = new ObservableCollection<MenuN1Item>();
			MenuN1Item MenuN1Item = new MenuN1Item { MenuN1ItemName = "nome do item do menu 1", Visibility = true, MenuN1ItemType = MenuN1Item.MenuN1ItemTypes.MainTabNewItem, MenuN1ItemParameter = MenuN1Item.MenuN1ItemParameters.MainViewModel };
			MenuN1Item MenuN1Item2 = new MenuN1Item { MenuN1ItemName = "Vibibility false", Visibility = false };
			MenuN1Sub.MenuN1Name = "Item 1 name here";
			MenuN1Sub.Visibility = true;
			MenuN1Sub.MenuN1ItensList = new ObservableCollection<MenuN1Item>();
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item2);
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item2);
			var MenuN1SubList = new ObservableCollection<MenuN1Sub>();
			//var MenuItens = new MenuItens();
			this.MenuName = menuName;
			this.MenuN1SubList = new ObservableCollection<MenuN1Sub>();
			this.MenuN1SubList.Add(MenuN1Sub);

			var MenuN1Sub2 = new MenuN1Sub();
			MenuN1Sub2.MenuN1Name = "Item 2 name here";
			MenuN1Sub2.Visibility = false;
			MenuN1Sub2.MenuN1ItensList = new ObservableCollection<MenuN1Item>();
			MenuN1Sub2.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub2.MenuN1ItensList.Add(MenuN1Item2);
			MenuN1Sub2.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub2.MenuN1ItensList.Add(MenuN1Item2);
			var MenuN1SubList2 = new ObservableCollection<MenuN1Sub>();
			//var MenuItens = new MenuItens();
			this.MenuName = menuName;

			this.MenuN1SubList.Add(MenuN1Sub2);

			this.MenuN1SubList.Add(MenuN1Sub);



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

		}
		#endregion

		#region MenuPermissionsToViewModel
			
		#endregion

	}
	#endregion


}
