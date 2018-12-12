using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using AppGestionCurriculums.ViewModels.OtrasActividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.OtrasActividades
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViOtrasActividadesItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmOtrasActividadesItem FicViewModel;

        public FicViOtrasActividadesItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmOtrasActividadesItem;
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmOtrasActividadesItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevaOtraActividad.Activo == 'S')
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevaOtraActividad.Borrado == 'S')
                switchBorrado.IsToggled = true;
        }

        private void OnToogleSwitchActivo(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaOtraActividad.Activo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevaOtraActividad.Activo = 'N';
            }

        }

        private void OnToogleSwitchBorrado(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevaOtraActividad.Borrado = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevaOtraActividad.Borrado = 'N';
            }

        }
    }
}