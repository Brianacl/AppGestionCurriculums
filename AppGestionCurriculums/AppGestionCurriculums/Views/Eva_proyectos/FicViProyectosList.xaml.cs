using AppGestionCurriculums.ViewModels.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_proyectos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViProyectosList : ContentPage
	{
        private object FicLoParameter { get; set; }

		public FicViProyectosList (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmProyectosList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmProyectosList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(FicLoParameter);
            }
        }
    }
}