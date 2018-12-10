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

        public FicViPersonasItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmPersonasItem;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPersonasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }
    }
}