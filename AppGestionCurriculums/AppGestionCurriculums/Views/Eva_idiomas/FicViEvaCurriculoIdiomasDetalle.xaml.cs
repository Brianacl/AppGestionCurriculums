using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_idiomas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoIdiomasDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViEvaCurriculoIdiomasDetalle (object FicNavigationContext)
		{
			InitializeComponent ();

            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmIdiomasDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoIdiomasDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar este idioma del curriculum, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmEvaCurriculoIdiomasDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}