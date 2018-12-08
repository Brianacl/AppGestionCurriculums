using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Competencias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCompetenciasList : ContentPage
    {

        public FicViCompetenciasList(object navigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCompetenciasList;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCompetenciasList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
    }
}
