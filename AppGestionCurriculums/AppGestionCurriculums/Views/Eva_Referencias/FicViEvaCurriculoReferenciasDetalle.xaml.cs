using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestionCurriculums.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_Referencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoReferenciasDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }
		public FicViEvaCurriculoReferenciasDetalle (object FicNavigationContext)
		{
			InitializeComponent ();
            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmReferenciasDetalle;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoReferenciasDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "se eliminará esta referencia", "si", "no");
            if (res)
            {
                var viewModel = BindingContext as FicVmEvaCurriculoReferenciasDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
	}
}