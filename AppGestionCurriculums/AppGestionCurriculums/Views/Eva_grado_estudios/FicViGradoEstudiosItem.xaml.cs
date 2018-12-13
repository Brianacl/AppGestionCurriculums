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
            pickerGradoEstudio.SelectedIndexChanged += (sender, args) =>
            {
                cambiarIdPickerSeleccionado();
            };
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmGradoEstudiosItem;
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmGradoEstudiosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }

        public void cambiarIdPickerSeleccionado()
        {
            var selectedItem = (Tipo_gen_grado_estudio)pickerGradoEstudio.SelectedItem;
            FicViewModel.NuevoGradoEstudio.IdGenTipo = selectedItem.IdGeneral;
            FicViewModel.NuevoGradoEstudio.IdGenGradoEstudio = selectedItem.IdTipoGeneral;
        }
    }
}