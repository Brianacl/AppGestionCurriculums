using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_grado_estudios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViGradoEstudiosItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmGradoEstudiosItem FicViewModel;

        public FicViGradoEstudiosItem (object FicNavigationContext)
		{
			InitializeComponent ();

            btnGuardar.Clicked += (sender, e) =>
            {
                guardarDatos();
            };

            pickerGradoEstudio.SelectedIndexChanged += (sender, args) =>
            {
                cambiarIdPickerSeleccionado();
            };

            pickerEstatus.SelectedIndexChanged += (sender, args) =>
            {
                cambiarEstatus();
            };

            

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmGradoEstudiosItem;
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmGradoEstudiosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevoGradoEstudio.IdEstatus != 0)
            {
                pickerGradoEstudio.SelectedIndex = FicViewModel.NuevoGradoEstudio.IdGenGradoEstudio -1;
                pickerEstatus.SelectedIndex = FicViewModel.NuevoGradoEstudio.IdEstatus -1;
            }

            if (FicViewModel.NuevoGradoEstudio.UltimoGradoEstudio == 'S')
                switchGradoEstudio.IsToggled = true;

            if (FicViewModel.NuevoGradoEstudio.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevoGradoEstudio.Borrado == 'S')
                switchBorrado.IsToggled = true;

        }

        public void cambiarIdPickerSeleccionado()
        {
            var selectedItem = (Tipo_gen_grado_estudio)pickerGradoEstudio.SelectedItem;
            FicViewModel.NuevoGradoEstudio.IdGenTipo = selectedItem.IdGeneral;
            FicViewModel.NuevoGradoEstudio.IdGenGradoEstudio = selectedItem.IdTipoGeneral;
        }

        public void cambiarEstatus()
        {
            var selectedItem = (Estatus_grado_estudios)pickerEstatus.SelectedItem;
            FicViewModel.NuevoGradoEstudio.IdTipoEstatus = selectedItem.IdTipoEstatus;
            FicViewModel.NuevoGradoEstudio.IdEstatus = selectedItem.IdEstatus;
        }

        private void OnToogleSwitch(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoGradoEstudio.UltimoGradoEstudio = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoGradoEstudio.UltimoGradoEstudio = 'N';
            }

        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoGradoEstudio.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoGradoEstudio.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoGradoEstudio.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoGradoEstudio.Borrado = 'N';
            }

        }

        private async void guardarDatos()
        {
            System.Diagnostics.Debug.WriteLine("Guarda datos");
            if (pickerIni.Date > pickerFin.Date)
            {
                System.Diagnostics.Debug.WriteLine("Si es :v");
                await DisplayAlert("ATENCIÓN", "La fecha de inicio no puede ser mayor que la de fin", "OK");
            }
            else
            {
                FicViewModel.SaveCommandExecute();
            }
        }
    }
}