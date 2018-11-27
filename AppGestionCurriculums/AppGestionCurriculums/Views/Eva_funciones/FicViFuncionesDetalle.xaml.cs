using AppGestionCurriculums.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_funciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViFuncionesDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViFuncionesDetalle (object FicNavigationContext)
		{
			InitializeComponent ();
            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmFuncionesDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmFuncionesDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar esta función, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmFuncionesDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}