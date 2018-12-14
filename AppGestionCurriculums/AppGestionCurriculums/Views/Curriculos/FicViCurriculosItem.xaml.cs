using AppGestionCurriculums.ViewModels.Curriculos;
using AppGestionCurriculums.ViewModels.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Curriculos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCurriculosItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        public FicViCurriculosItem (object FicNavigationContext)
		{
			InitializeComponent ();

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCurriculosItem;
        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCurriculosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            if (FicViewModel.NuevoCurriculo.Activo == "S")
                switchActivo.IsToggled = true;

            if (FicViewModel.NuevoCurriculo.Borrado == "S")
                switchBorrado.IsToggled = true;
        }

    }
}