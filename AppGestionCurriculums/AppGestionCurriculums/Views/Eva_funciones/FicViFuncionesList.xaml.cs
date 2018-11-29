using AppGestionCurriculums.ViewModels.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_funciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViFuncionesList : ContentPage
	{
		public FicViFuncionesList (object FicNavigationContext)
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmFuncionesList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmFuncionesList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
    }
}