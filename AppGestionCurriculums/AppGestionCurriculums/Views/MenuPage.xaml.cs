using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.CurriculumsPersonas, Title="Curriculums Personas" },
                //new HomeMenuItem {Id = MenuItemType.Competencias, Title="Competencias" }
                new HomeMenuItem {Id = MenuItemType.ListaIdiomas, Title= "Lista idiomas"},
                new HomeMenuItem {Id = MenuItemType.GradoEstudios, Title="Lista grado de estudios"},
                new HomeMenuItem {Id = MenuItemType.Funciones, Title="Lista de funciones"},
                new HomeMenuItem {Id = MenuItemType.Proyectos, Title="Lista proyectos"}

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                try
                {
                    await RootPage.NavigateFromMenu(id);
                }
                catch(Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                    if (exception.InnerException != null)
                    {
                        System.Diagnostics.Debug.WriteLine("-->"+exception.InnerException);
                    }
                }
            };
        }
    }
}