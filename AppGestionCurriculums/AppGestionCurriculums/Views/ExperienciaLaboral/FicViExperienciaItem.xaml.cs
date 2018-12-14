using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.ExperienciaLaboral;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.ExperienciaLaboral
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViExperienciaItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmExperienciaItem FicViewModel;

        public FicViExperienciaItem (object FicNavigationContext)
		{
			InitializeComponent ();

            btnGuardar.Clicked += (sender, e) =>
            {
                guardarDatos();
            };

            pickerExperienciaLaboral.SelectionChanged += (sender, args) =>
            {
                cambiarIdPickerSeleccionado();
            };

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmExperienciaItem;
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmExperienciaItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevaExperiencia.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevaExperiencia.Borrado == 'S')
                switchBorrado.IsToggled = true;
        }

        public void cambiarIdPickerSeleccionado()
        {
            var IdGeneral = pickerExperienciaLaboral.SelectedValue;
            System.Diagnostics.Debug.WriteLine(IdGeneral);
            if (IdGeneral != null)
            {
                FicViewModel.NuevaExperiencia.IdGenTipo = (short)IdGeneral;
                FicViewModel.NuevaExperiencia.IdGenExperienciaLaboral = 19;
            }
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaExperiencia.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevaExperiencia.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaExperiencia.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevaExperiencia.Borrado = 'N';
            }

        }

        private async void guardarDatos()
        {
            if (pickerIni.Date > pickerFin.Date)
            { 
                await DisplayAlert("ATENCIÓN","La fecha de inicio no puede ser mayor a la fecha final", "Ok");
            }
            else if (FicViewModel.NuevaExperiencia.IdGenTipo == 0)
            {
                await DisplayAlert("ATENCIÓN","Seleccione un giro para su experiencia laboral","Ok");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("guardadatos");
                FicViewModel.SaveCommandExecute();
            }
        }
    }
}