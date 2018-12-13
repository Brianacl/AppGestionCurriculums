using AppGestionCurriculums.ViewModels.Curriculos;
using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Curriculos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCurriculosDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }
        public FicViCurriculosDetalle (object FicNavigationContext)
		{
			InitializeComponent ();

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCurriculosDetalle;
        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCurriculosDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
    }
}