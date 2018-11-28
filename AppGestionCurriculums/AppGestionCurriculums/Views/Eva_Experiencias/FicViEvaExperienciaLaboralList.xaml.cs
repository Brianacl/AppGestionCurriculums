using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppGestionCurriculums.ViewModels;


namespace AppGestionCurriculums.Views.Eva_Experiencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaExperienciaLaboralList : ContentPage
	{
		public FicViEvaExperienciaLaboralList (object FicNavigationContext)
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmExperienciasList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaExperienciaLaboralList;
            if(FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
	}
}