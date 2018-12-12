using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using AppGestionCurriculums.ViewModels.OtrasActividades;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.OtrasActividades
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViOtrasActividadesDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViOtrasActividadesDetalle (object FicNavigationContext)
		{
			InitializeComponent ();

            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmOtrasActividadesDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmOtrasActividadesDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar esta actividad  del curriculum, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmOtrasActividadesDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}