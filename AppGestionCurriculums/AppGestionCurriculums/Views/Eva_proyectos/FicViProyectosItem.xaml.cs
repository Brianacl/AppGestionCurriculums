using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_proyectos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViProyectosItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmProyectosItem FicViewModel { get; set; }

        public FicViProyectosItem (object FicNavigationContext)
		{
			InitializeComponent ();

            btnGuardar.Clicked += (sender, e) =>
            {
                guardarDatos();
            };

            pickerEstatus.SelectedIndexChanged += (sender, args) =>
            {
                cambiarEstatus();
            };

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmProyectosItem;
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmProyectosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if(FicViewModel.NuevoProyecto.IdEstatus > 0)
                pickerEstatus.SelectedIndex = FicViewModel.NuevoProyecto.IdEstatus - 1;
            
            if (FicViewModel.NuevoProyecto.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevoProyecto.Borrado == 'S')
                switchBorrado.IsToggled = true;
        }

        public void cambiarEstatus()
        {
            var selectedItem = (Cat_estatus)pickerEstatus.SelectedItem;
            FicViewModel.NuevoProyecto.IdTipoEstatus = selectedItem.IdTipoEstatus;
            FicViewModel.NuevoProyecto.IdEstatus = selectedItem.IdEstatus;
        }

        private async void guardarDatos()
        {
            if (pickerIni.Date > pickerFin.Date)
            {
                await DisplayAlert("ATENCIÓN", "La fecha de inicio no puede ser mayor que la de fin", "OK");
            }
            else
            {
                FicViewModel.SaveCommandExecute();
            }
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoProyecto.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoProyecto.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoProyecto.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoProyecto.Borrado = 'N';
            }

        }
    }
}