using AppGestionCurriculums.ViewModels.ExperienciaLaboral;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.ExperienciaLaboral;

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

            pickerExperienciaLaboral.SelectedIndexChanged += (sender, args) =>
            {
                cambiarIdPickerSeleccionado();
            };

            

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmExperienciaItem;
        }

        

        protected override void OnAppearing()
        {
            if(FicViewModel.NuevaExperiencia.IdExperiencia != 0)
            {
                pickerExperienciaLaboral.SelectedIndex = FicViewModel.NuevaExperiencia.IdGenExperienciaLaboral - 1;
            }

             FicViewModel = BindingContext as FicVmExperienciaItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }

        public void cambiarIdPickerSeleccionado()
        {
            var selectedItem = (Tipo_gen_giro_experienciaLaboral)pickerExperienciaLaboral.SelectedItem;
            FicViewModel.NuevaExperiencia.IdGenTipo = selectedItem.IdGeneral;
            FicViewModel.NuevaExperiencia.IdGenExperienciaLaboral = selectedItem.IdTipoGeneral;
        }

        private async void guardarDatos()
        {
            System.Diagnostics.Debug.WriteLine("guardadatos");
            if(pickerIni.Date > pickerFin.Date)
            {
                await DisplayAlert("Atención, la fecha de inicio no puede ser mayor a la fecha final", "ok");
            }
            else
            {
                FicViewModel.FicMetSaveCommand();
            }
        }
    }
}