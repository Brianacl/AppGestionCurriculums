using AppGestionCurriculums.ViewModels;
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
	public partial class FicViGradoEstudiosItem : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViGradoEstudiosItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmGradoEstudiosItem;
        }

        async void metodo_regresar(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmGradoEstudiosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

        }
    }
}