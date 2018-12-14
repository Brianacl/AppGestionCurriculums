using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_conocimientos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoConocimientosItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmEvaCurriculoConocimientosItem FicViewModel;
        public FicViEvaCurriculoConocimientosItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmConocimientosItem;

            pickerConocimiento.SelectedIndexChanged += (sender, args) =>
            {
                cambiarConocimiento();
            };
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
           
        }

        public void cambiarConocimiento()
        {
            var selectedItem = (Eva_cat_conocimientos)pickerConocimiento.SelectedItem;
            FicViewModel.NuevoConocimiento.IdConocimiento = selectedItem.IdConocimiento;
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmEvaCurriculoConocimientosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
            if (FicViewModel.NuevoConocimiento.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevoConocimiento.Borrado == 'S')
                switchBorrado.IsToggled = true;

            if (FicViewModel.NuevoConocimiento.IdConocimiento != 0)
            {
                pickerConocimiento.SelectedIndex = FicViewModel.NuevoConocimiento.IdConocimiento - 1;
            }
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoConocimiento.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoConocimiento.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoConocimiento.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoConocimiento.Borrado = 'N';
            }

        }
    }
}