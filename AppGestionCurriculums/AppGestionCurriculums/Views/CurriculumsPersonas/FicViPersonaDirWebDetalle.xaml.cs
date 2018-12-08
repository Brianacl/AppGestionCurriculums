using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.CurriculumsPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViPersonaDirWebDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }
        public FicViPersonaDirWebDetalle(object FicNavigationContext)
		{
			InitializeComponent ();

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmDireccionWebDetalle;
        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmDireccionWebDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
    }
}