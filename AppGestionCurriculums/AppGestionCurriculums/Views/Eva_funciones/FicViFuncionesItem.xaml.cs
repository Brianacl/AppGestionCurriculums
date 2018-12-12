using AppGestionCurriculums.ViewModels.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_funciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViFuncionesItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmFuncionesItem FicViewModel { get; set; }

        public FicViFuncionesItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmFuncionesItem;
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmFuncionesItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevaFuncion.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevaFuncion.Borrado == 'S')
                switchBorrado.IsToggled = true;
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaFuncion.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevaFuncion.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaFuncion.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevaFuncion.Borrado = 'N';
            }

        }
    }
}