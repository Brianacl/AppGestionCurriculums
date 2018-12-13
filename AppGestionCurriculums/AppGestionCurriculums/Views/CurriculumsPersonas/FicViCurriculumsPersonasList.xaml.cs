using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.CurriculumsPersonas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCurriculumsPersonasList : ContentPage
	{

        public FicViCurriculumsPersonasList(object navigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCurriculumsPersonasList;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCurriculumsPersonasList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
    }
}