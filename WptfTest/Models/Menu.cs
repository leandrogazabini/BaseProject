using DllModels.Models.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WptfTest.Models
{
	public class MenuItens : BaseClass
	{

		private string _menuName;
		public  string MenuName
		{
			get { return _menuName; }
			set { SetField(ref _menuName, value); }
		}


		public ObservableCollection <MenuN1Sub> MenuN1SubList { get; set; }



		public MenuItens CreateMenu(string menuName = "sem nome de menu")
		{
			MenuN1Item MenuN1Item = new MenuN1Item { MenuN1ItemName = "nome do item do menu 1" };
			var MenuN1ItensList = new ObservableCollection<MenuN1Item>();
			var MenuN1Sub = new MenuN1Sub();
			MenuN1Sub.MenuN1Name = "Name do menu 1";
			MenuN1Sub.MenuN1ItensList = new ObservableCollection<MenuN1Item>();
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
			MenuN1Sub.MenuN1ItensList.Add(MenuN1Item);
			var MenuN1SubList = new ObservableCollection<MenuN1Sub>();
			var MenuItens = new MenuItens();
			MenuItens.MenuName = menuName;
			MenuItens.MenuN1SubList = new ObservableCollection<MenuN1Sub>();
			MenuItens.MenuN1SubList.Add(MenuN1Sub);
			MenuItens.MenuN1SubList.Add(MenuN1Sub);
			MenuItens.MenuN1SubList.Add(MenuN1Sub);

			return MenuItens;
		}


		
	}

	public class MenuN1Sub : BaseClass
	{

		private string _menuN1Name;
		public string MenuN1Name
		{
			get { return _menuN1Name; }
			set { SetField(ref _menuN1Name, value); }
		}


		
		public ObservableCollection<MenuN1Item> MenuN1ItensList { get; set; }

	}

	public class MenuN1Item : BaseClass
	{

		private string _menuN1ItemName;
		public string MenuN1ItemName
		{
			get { return _menuN1ItemName; }
			set { SetField(ref _menuN1ItemName, value); }
		}
	}

	
}
