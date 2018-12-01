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
	public partial class FicViEvaCurriculoConocimientosItem : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViEvaCurriculoConocimientosItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmConocimientosItem;
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoConocimientosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }
    }
}