using AppGestionCurriculums.ViewModels.ExperienciaLaboral;
using AppGestionCurriculums.ViewModels.GradoEstudios;
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
            pickerExperienciaLaboral.SelectedIndexChanged += (sender, args) =>
            {
                cambiarIdPickerSeleccionado();
            };

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmExperienciaItem;
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
             FicViewModel = BindingContext as FicVmExperienciaItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }

        public void cambiarIdPickerSeleccionado()
        {
            var selectedItem = (Tipo_gen_giro_experienciaLaboral)pickerExperienciaLaboral.SelectedItem;
            FicViewModel.NuevaExperiencia.IdGenTipo = selectedItem.IdGeneral;
            FicViewModel.NuevaExperiencia.IdGenExperienciaLaboral = selectedItem.IdTipoGeneral;
        }
    }
}