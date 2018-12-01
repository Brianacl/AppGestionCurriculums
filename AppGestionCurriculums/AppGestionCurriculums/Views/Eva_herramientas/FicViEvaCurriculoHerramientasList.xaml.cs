using AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_herramientas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoHerramientasList : ContentPage
	{
		public FicViEvaCurriculoHerramientasList (object FicNavigationContext)
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmHerramientasList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoHerramientasList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
    }
}