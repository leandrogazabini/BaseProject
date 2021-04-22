﻿using DllModels.Models;
using WptfTest.Models;
using WptfTest.Models.BaseViewModels;

namespace WptfTest.ViewModels.MainView
{
	class MainViewModel : BaseViewModel
	{

		private string _test = "Test string.";
		public string Test
		{
			get { return _test; }
			set
			{
				SetField(ref _test, value);
			}
		}


		public Person Person { get; set; }


		private string _selectedMenuItem;
		public string SelectedMenuItem
		{
			get { return _selectedMenuItem; }
			set
			{
				SetField(ref _selectedMenuItem, value);
			}
		}

		public MainViewModel(ViewModelPermissions viewModelPermissions = null, bool visibility = false)
		{			
			SetViewModelPermissions(viewModelPermissions);
			this.Visibility = visibility;
			this.MenuN1ItemParameter = MenuItens.MenuN1Item.MenuN1ItemParameters.MainViewModel;
		}


	}
}

