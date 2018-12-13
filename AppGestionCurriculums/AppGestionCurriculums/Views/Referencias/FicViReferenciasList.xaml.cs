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
	public partial class FicViReferenciasList : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViReferenciasList(object FicNavigationContext)
        {
            InitializeComponent();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmReferenciasList;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmReferenciasList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(FicLoParameter);
            }
        }
    }
}