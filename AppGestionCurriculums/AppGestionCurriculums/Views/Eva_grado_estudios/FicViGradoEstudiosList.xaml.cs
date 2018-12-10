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
	public partial class FicViGradoEstudiosList : ContentPage
	{
        private object FicLoParameter;

		public FicViGradoEstudiosList (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmGradoEstudiosList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmGradoEstudiosList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(FicLoParameter);
            }
        }
    }
}