using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Competencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCompetenciasDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViCompetenciasDetalle (object navigationContext)
		{
			InitializeComponent ();
            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = navigationContext;
            BindingContext = App.FicVmLocator.FicVmCompetenciasDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCompetenciasDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar esta competencia, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmCompetenciasDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}