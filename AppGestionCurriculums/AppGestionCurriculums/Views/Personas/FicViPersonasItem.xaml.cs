using AppGestionCurriculums.ViewModels.GradoEstudios;
using AppGestionCurriculums.ViewModels.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Personas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViPersonasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmPersonasItem FicViewModel;

        public FicViPersonasItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmPersonasItem;
        }
       
        private void OnToogleSwitch(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoPersona.Sexo = "F";               
                SalidaSwitch.Text = "F";               
            }
            if (value == false)
            {
                FicViewModel.NuevoPersona.Sexo = "H";
                SalidaSwitch.Text = "H";
            }

        }
        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmPersonasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevoPersona.Sexo == "F")
                SwitchGender.IsToggled = true;


        }
    }
}