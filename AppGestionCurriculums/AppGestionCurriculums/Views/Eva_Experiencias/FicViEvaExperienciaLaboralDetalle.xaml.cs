using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestionCurriculums.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_Experiencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaExperienciaLaboralDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }
		public FicViEvaExperienciaLaboralDetalle (object FicNavigationContext)
		{
			InitializeComponent ();
            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmExperienciasDetalle;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaExperienciaLaboralDetalle;
            if(FicViewModel != null)
            {
                FicViewModel.OnAppearing(FicLoParameter);
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso: ", "se eliminará este registro, ¿Está seguro?", "Sí", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmEvaExperienciaLaboralDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
	}
}