﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using DllModels;
using MahApps.Metro.Controls.Dialogs;
using BusinessLogic;
using DllModels.Models;
using DllModels.Models.ModelsValidators;
using System.Collections.ObjectModel;
using DllModels.Models.Bases;
using WptfTestWptfTest.Models;
using System.Windows.Controls;
using System.Windows;
using WptfTest.Models.BaseViewModels;
using WptfTest.Models;

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

