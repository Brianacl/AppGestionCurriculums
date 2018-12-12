using AppGestionCurriculums.ViewModels.Referencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Referencias;


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
            pickerReferencias.SelectedIndexChanged += (sender, args) =>
            {
                cambiarIdPickerSeleccionado();
            };
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmReferenciasItem;
        }

        private void OnToogleSwitch(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if(value == true)
            {
                FicViewModel.NuevoReferencia.Sexo = "H";
            }
            if(value == false)
            {
                FicViewModel.NuevoReferencia.Sexo = "M";
            }

        }

        async void metodo_regresar(object sender, EventArgs e)
        {

        }
        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmReferenciasItem;            
             if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        public void cambiarIdPickerSeleccionado()
        {
            var selectedItem = (Tipo_gen_parentezco_referencias)pickerReferencias.SelectedItem;
            FicViewModel.NuevoReferencia.IdGenTipo = selectedItem.IdGeneral;
            FicViewModel.NuevoReferencia.IdGenParentezco = selectedItem.IdTipoGeneral;
        }
    }
}