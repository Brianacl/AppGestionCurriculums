using AppGestionCurriculums.ViewModels.GradoEstudios;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_grado_estudios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViGradoEstudiosDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViGradoEstudiosDetalle (object FicNavigationContext)
		{
			InitializeComponent ();

            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmGradoEstudiosDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmGradoEstudiosDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar este idioma del curriculum, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmGradoEstudiosDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}