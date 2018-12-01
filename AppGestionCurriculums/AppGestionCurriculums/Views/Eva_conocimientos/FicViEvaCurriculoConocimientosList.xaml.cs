using AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_conocimientos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoConocimientosList : ContentPage
	{
		public FicViEvaCurriculoConocimientosList (object FicNavigationContext)
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmConocimientosList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoConocimientosList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
    }
}