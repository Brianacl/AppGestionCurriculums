using AppGestionCurriculums.ViewModels.Proyectos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_proyectos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViProyectosDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViProyectosDetalle (object FicNavigationContext)
		{
			InitializeComponent ();
            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmProyectosDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmProyectosDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar esta función, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmProyectosDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}