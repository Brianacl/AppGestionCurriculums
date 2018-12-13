using AppGestionCurriculums.ViewModels.Referencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Referencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViReferenciasItem : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViReferenciasItem(object FicNavigationContext)
        {
            InitializeComponent();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmReferenciasItem;
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmReferenciasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
    }
}