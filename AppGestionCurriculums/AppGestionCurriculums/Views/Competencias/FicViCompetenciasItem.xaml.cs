using AppGestionCurriculums.ViewModels.Competencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Competencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCompetenciasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        public FicViCompetenciasItem (object navigationContext)
		{
			InitializeComponent ();
            FicLoParameter = navigationContext;
            BindingContext = App.FicVmLocator.FicVmCompetenciasItem;
		}
        async void metodo_regresar(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCompetenciasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }
    }
}