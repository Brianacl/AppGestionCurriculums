using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using AppGestionCurriculums.ViewModels.OtrasActividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.OtrasActividades
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViOtrasActividadesList : ContentPage
	{
        private object FicLoParameter;

		public FicViOtrasActividadesList (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmOtrasActividadesList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmOtrasActividadesList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(FicLoParameter);
            }
        }
    }
}