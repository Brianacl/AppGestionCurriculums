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
	public partial class FicViEvaCurriculoReferenciasList : ContentPage
	{
		public FicViEvaCurriculoReferenciasList (object FicNavigationContext)
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmReferenciasList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmEvaCurriculoReferenciasList;
            if(FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
	}
}