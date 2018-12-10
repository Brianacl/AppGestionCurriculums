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
	public partial class FicViPersonasList : ContentPage
	{
        public FicViPersonasList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmPersonasList;
        }

        public FicViPersonasList (object FicNavigationContext)
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmPersonasList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmPersonasList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
    }
}