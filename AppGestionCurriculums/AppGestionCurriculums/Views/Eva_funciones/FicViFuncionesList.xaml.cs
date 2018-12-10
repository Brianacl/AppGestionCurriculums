﻿using AppGestionCurriculums.ViewModels.Funciones;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Eva_funciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViFuncionesList : ContentPage
	{
		public FicViFuncionesList (object FicNavigationContext)
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmFuncionesList;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmFuncionesList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing(null);
            }
        }
    }
}