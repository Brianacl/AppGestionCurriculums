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
	public partial class FicViCurriculumsPersonasDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }
        public FicViCurriculumsPersonasDetalle (object FicNavigationContext)
		{
			InitializeComponent ();
            //btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCurriculumsPersonasDetalle;
        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCurriculumsPersonasDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
        /*
        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar esta función, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmCurriculumsPersonasDetalle;
                viewModel.DeleteCommandExecute();
            }
        }*/
    }
}