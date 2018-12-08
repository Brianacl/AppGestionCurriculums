using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.CurriculumsPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViPersonaDomicilioDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }
        public FicViPersonaDomicilioDetalle(object FicNavigationContext)
		{
			InitializeComponent ();

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmDomicilioDetalle;
        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmDomicilioDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
    }
}