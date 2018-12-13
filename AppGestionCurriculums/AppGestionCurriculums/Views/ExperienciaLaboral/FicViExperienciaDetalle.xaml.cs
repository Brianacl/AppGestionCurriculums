using AppGestionCurriculums.ViewModels.ExperienciaLaboral;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.ExperienciaLaboral
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViExperienciaDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViExperienciaDetalle (object FicNavigationContext)
		{
			InitializeComponent ();

            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmExperienciaDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmExperienciaDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar esta experiencia del curriculum, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmExperienciaDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}