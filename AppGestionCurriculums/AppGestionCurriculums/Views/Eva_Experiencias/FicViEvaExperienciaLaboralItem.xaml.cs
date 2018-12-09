using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestionCurriculums.ViewModels;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_Experiencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViEvaExperienciaLaboralItem : ContentPage
	{
        private object FicLoParameter { get; set; }
		public FicViEvaExperienciaLaboralItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmExperienciasItem;
		}
        async void metodo_regresar(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaExperienciaLaboralItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
    }
}