using AppGestionCurriculums.ViewModels.GradoEstudios;
using AppGestionCurriculums.ViewModels.Personas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Personas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViPersonasDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViPersonasDetalle (object FicNavigationContext)
		{
			InitializeComponent ();

            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmPersonasDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPersonasDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar este idioma del curriculum, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmPersonasDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}