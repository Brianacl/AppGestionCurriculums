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
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.ListaIdiomas, Title= "Lista idiomas"},
                new HomeMenuItem {Id = MenuItemType.GradoEstudios, Title="Lista grado de estudios"},
                new HomeMenuItem {Id = MenuItemType.Funciones, Title="Lista de funciones"},
                new HomeMenuItem {Id = MenuItemType.Proyectos, Title="Lista proyectos"},
                new HomeMenuItem {Id = MenuItemType.Herramientas, Title="Lista herramientas"},
                new HomeMenuItem {Id = MenuItemType.Conocimientos, Title="Lista conocimientos"}
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}