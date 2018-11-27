using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppGestionCurriculums.Views.Eva_idiomas;
using AppGestionCurriculums.Views.Eva_grado_estudios;
using AppGestionCurriculums.Views.Eva_funciones;

namespace AppGestionCurriculums.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.ListaIdiomas:
                        MenuPages.Add(id, new NavigationPage(new FicViEvaCurriculoIdiomasList(null)));
                        break;
                    case (int)MenuItemType.GradoEstudios:
                        MenuPages.Add(id, new NavigationPage(new FicViGradoEstudiosList(null)));
                        break;
                    case (int)MenuItemType.Funciones:
                        MenuPages.Add(id, new NavigationPage(new FicViFuncionesList(null)));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}