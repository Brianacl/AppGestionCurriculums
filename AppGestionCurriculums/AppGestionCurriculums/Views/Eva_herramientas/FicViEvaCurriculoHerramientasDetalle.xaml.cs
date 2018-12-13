using AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_herramientas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoHerramientasDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViEvaCurriculoHerramientasDetalle (object FicNavigationContext)
		{
			InitializeComponent ();

            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmHerramientasDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoHerramientasDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar este herramienta del curriculum, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmEvaCurriculoHerramientasDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}