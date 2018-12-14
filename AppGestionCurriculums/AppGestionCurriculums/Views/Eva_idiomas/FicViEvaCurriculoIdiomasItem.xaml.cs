using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_idiomas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoIdiomasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmEvaCurriculoIdiomasItem FicViewModel;

        public FicViEvaCurriculoIdiomasItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmIdiomasItem;
        }

        private void OnToogleSwitch(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoIdioma.Nativo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoIdioma.Nativo = 'N';
            }

        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmEvaCurriculoIdiomasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevoIdioma.Nativo == 'S')
                switchNativo.IsToggled = true;

            if (FicViewModel.NuevoIdioma.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevoIdioma.Borrado == 'S')
                switchBorrado.IsToggled = true;
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoIdioma.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoIdioma.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoIdioma.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoIdioma.Borrado = 'N';
            }

        }
    }
}