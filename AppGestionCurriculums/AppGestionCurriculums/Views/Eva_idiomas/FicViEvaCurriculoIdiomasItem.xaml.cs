using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
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
        private FicVmEvaCurriculoIdiomasItem FicViewModel;

        public FicViEvaCurriculoIdiomasItem (object FicNavigationContext)
		{
			InitializeComponent ();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmIdiomasItem;
        }

        private void OnToogleSwitch(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                FicViewModel.NuevoIdioma.Nativo = 'S';
            }
            if (value == false)
            {
                FicViewModel.NuevoIdioma.Nativo = 'N';
            }

        }

        protected override void OnAppearing()
        {
            FicViewModel = BindingContext as FicVmEvaCurriculoIdiomasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);


        }
    }
}