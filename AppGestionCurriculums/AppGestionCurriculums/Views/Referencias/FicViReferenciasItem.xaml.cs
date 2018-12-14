using AppGestionCurriculums.ViewModels.Referencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Referencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViReferenciasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmReferenciasItem FicViewModel;

        public FicViReferenciasItem(object FicNavigationContext)
        {
            InitializeComponent();

            completeParentezco.SelectionChanged += (sender, args) =>
            {
                cambiarParentezcoSeleccionado();
            };

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmReferenciasItem;
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmReferenciasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevoReferencia.Sexo == "F")
                SwitchGender.IsToggled = true;

            if (FicViewModel.NuevoReferencia.Activo == "S")
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevoReferencia.Borrado == "S")
                switchBorrado.IsToggled = true;
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoReferencia.Activo = "S";
            }
            if (value == false)
            {
                FicViewModel.NuevoReferencia.Activo = "N";
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoReferencia.Borrado = "S";
            }
            if (value == false)
            {
                FicViewModel.NuevoReferencia.Borrado = "N";
            }

        }

        private void OnToogleSwitch(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoReferencia.Sexo = "F";
                SalidaSwitch.Text = "F";
            }
            if (value == false)
            {
                FicViewModel.NuevoReferencia.Sexo = "H";
                SalidaSwitch.Text = "H";
            }

        }

        public void cambiarParentezcoSeleccionado()
        {
            completeParentezco.SelectedValuePath = "IdGeneral";
            var IdTipoGeneral = completeParentezco.SelectedValue;
            if (IdTipoGeneral != null)
            {
                FicViewModel.NuevoReferencia.IdGenParentezco = (short)IdTipoGeneral;
            }
        }
    }
}