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

namespace WptfTest.ViewModels.MainView
{
	class MainViewModel : DllModels.Models.Bases.BaseClass
	{

		private string _test = "Isso é um teste";
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

		public MainViewModel()
		{
			Person = new Person();


			var bllCtx = new BusinessLogic.Methods();

			var connection = bllCtx.ConnectDb();
			var qResult = bllCtx.FindPersonByName("Leandro Prandini Gazabini");
			Test = qResult.OficialName;
			Person.OficialName = "Leandro";
		}
	

	}
}

