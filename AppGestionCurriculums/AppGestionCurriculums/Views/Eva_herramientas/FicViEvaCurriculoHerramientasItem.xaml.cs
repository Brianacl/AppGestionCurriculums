using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_herramientas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoHerramientasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmEvaCurriculoHerramientasItem FicViewModel;

        public FicViEvaCurriculoHerramientasItem (object FicNavigationContext)
		{
			InitializeComponent ();

            pickerHerramienta.SelectedIndexChanged += (sender, args) =>
            {
                cambiarIdPickerSeleccionado();
            };


            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmHerramientasItem;
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmEvaCurriculoHerramientasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
            if (FicViewModel.NuevoHerramienta.IdGenHerramienta != 0)
            {
                pickerHerramienta.SelectedIndex = FicViewModel.NuevoHerramienta.IdGenHerramienta - 1;
            }

            if (FicViewModel.NuevoHerramienta.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevoHerramienta.Borrado == 'S')
                switchBorrado.IsToggled = true;
            
        }

        public void cambiarIdPickerSeleccionado()
        {
            var selectedItem = (Tipo_gen_herramienta)pickerHerramienta.SelectedItem;
            FicViewModel.NuevoHerramienta.IdGenHerramienta = selectedItem.IdGeneral;
            FicViewModel.NuevoHerramienta.IdGenTipo = selectedItem.IdTipoGeneral;
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoHerramienta.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoHerramienta.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoHerramienta.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoHerramienta.Borrado = 'N';
            }

        }
    }
}