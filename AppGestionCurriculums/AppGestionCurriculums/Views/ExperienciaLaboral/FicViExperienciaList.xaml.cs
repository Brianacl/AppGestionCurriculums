using AppGestionCurriculums.ViewModels.ExperienciaLaboral;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.ExperienciaLaboral
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViExperienciaList : ContentPage
	{
        private object FicLoParameter;

		public FicViExperienciaList (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmExperienciaList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmExperienciaList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(FicLoParameter);
            }
        }
    }
}