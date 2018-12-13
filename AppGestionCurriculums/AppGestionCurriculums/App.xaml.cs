using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppGestionCurriculums.Views;
using AppGestionCurriculums.ViewModels.Base;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppGestionCurriculums
{
    public partial class App : Application
    {
        private static FicViewModelLocator FicLocalVmLocator;

        public static FicViewModelLocator FicVmLocator
        {
            get { return FicLocalVmLocator = FicLocalVmLocator ?? new FicViewModelLocator(); }
        }

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
