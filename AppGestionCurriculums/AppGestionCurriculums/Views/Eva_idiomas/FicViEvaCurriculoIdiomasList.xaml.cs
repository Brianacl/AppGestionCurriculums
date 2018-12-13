using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_idiomas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoIdiomasList : ContentPage
	{
        private object FicLoParameter;

		public FicViEvaCurriculoIdiomasList (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmIdiomasList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoIdiomasList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(FicLoParameter);
            }
        }
    }
}