using DllModels.Models;
using WptfTest.Models;
using WptfTest.Models.BaseViewModels;

namespace WptfTest.ViewModels.MainView
{
	class TestViewModel : BaseViewModel
	{

		private string _test;
		public string Test
		{
			get { return _test; }
			set
			{
				SetField(ref _test, value);
			}
		}


		public PersonModel Person { get; set; }


		//private string _selectedMenuItem;
		//public string SelectedMenuItem
		//{
		//	get { return _selectedMenuItem; }
		//	set
		//	{
		//		SetField(ref _selectedMenuItem, value);
		//	}
		//}

		public TestViewModel(ViewModelPermissions viewModelPermissions = null, bool visibility = false)
		{
			SetViewModelPermissions(viewModelPermissions);
			this.Visibility = visibility;
			this.MenuN1ItemParameter = MenuItens.MenuN1Item.MenuN1ItemParameters.MainViewModel;
			
			//simple example how to use business logic layer
			//Person = new Person();
			//var bllCtx = new BusinessLogic.Methods();
			//var connection = bllCtx.ConnectDb();
			//var qResult = bllCtx.FindPersonByName("Leandro Prandini Gazabini");
			//Test = qResult.OficialName;
			//Person.OficialName = "Leandro";
		}




	}
}

