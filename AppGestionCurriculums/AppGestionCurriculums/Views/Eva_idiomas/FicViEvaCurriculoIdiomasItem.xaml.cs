using AppGestionCurriculums.ViewModels;
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
	public partial class FicViEvaCurriculoIdiomasItem : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViEvaCurriculoIdiomasItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmIdiomasItem;
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoIdiomasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }
    }
}