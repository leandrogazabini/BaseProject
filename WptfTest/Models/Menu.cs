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
			MenuN1Item MenuN1Item = new MenuN1Item { MenuN1ItemName = "nome do item do menu 1", Visibility = true };
			MenuN1Item MenuN1Item2 = new MenuN1Item { MenuN1ItemName = "Vibibility false", Visibility = false};
			MenuN1Sub.MenuN1Name = "Name do menu 1";
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
			MenuN1Sub2.MenuN1Name = "Name do menu 2";
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
		public class MenuN1Item : BaseClass
		{

			private string _menuN1ItemName;
			public string MenuN1ItemName
			{
				get { return _menuN1ItemName; }
				set { SetField(ref _menuN1ItemName, value); }
			}


			private bool _visibility = false;
			public bool Visibility
			{
				get { return _visibility; }
				set { SetField(ref _visibility, value); }
			}

			private string _viewName = "Undefined";
			public string ViewName
			{
				get { return _viewName; }
				set { SetField(ref _viewName, value); }
			}
		}
		#endregion

	}
	#endregion


}
