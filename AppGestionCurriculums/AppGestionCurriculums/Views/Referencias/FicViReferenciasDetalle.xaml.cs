using AppGestionCurriculums.ViewModels.Referencias;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Referencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViReferenciasDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViReferenciasDetalle(object FicNavigationContext)
        {
            InitializeComponent();
            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmReferenciasDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmReferenciasDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se eliminará esta referencia", "si", "no");
            if (res)
            {
                var viewModel = BindingContext as FicVmReferenciasDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}