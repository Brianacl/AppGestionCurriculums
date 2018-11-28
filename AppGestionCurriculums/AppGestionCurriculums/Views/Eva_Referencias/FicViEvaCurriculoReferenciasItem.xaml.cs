using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestionCurriculums.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_Referencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaCurriculoReferenciasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
		public FicViEvaCurriculoReferenciasItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmReferenciasItem;
		}

        async void metodo_regresar(object sender, EventArgs e)
        {

        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoReferenciasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
    }
}