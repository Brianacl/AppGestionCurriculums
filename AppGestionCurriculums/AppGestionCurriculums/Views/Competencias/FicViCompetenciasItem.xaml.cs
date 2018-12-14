using AppGestionCurriculums.ViewModels.Competencias;
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
    public partial class FicViCompetenciasItem : ContentPage
    {
        private object FicLoParameter { get; set; }
        private FicVmCompetenciasItem FicViewModel{ get; set; }

        public FicViCompetenciasItem (object navigationContext)
		{
			InitializeComponent ();
            FicLoParameter = navigationContext;
            BindingContext = App.FicVmLocator.FicVmCompetenciasItem;
            //autoComplete.Focus();
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmCompetenciasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevaCompetencias.Activo == "S")
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevaCompetencias.Borrado == "S")
                switchBorrado.IsToggled = true;
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaCompetencias.Activo = "S";
            }
            if (value == false)
            {
                FicViewModel.NuevaCompetencias.Activo = "N";
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaCompetencias.Borrado = "S";
            }
            if (value == false)
            {
                FicViewModel.NuevaCompetencias.Borrado = "N";
            }

        }
    }
}