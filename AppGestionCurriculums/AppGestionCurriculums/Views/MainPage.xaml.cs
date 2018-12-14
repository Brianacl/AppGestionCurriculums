using AppGestionCurriculums.Models;
using AppGestionCurriculums.Views.CurriculumsPersonas;
using AppGestionCurriculums.Views.Competencias;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppGestionCurriculums.Views.Eva_idiomas;
using AppGestionCurriculums.Views.Eva_grado_estudios;
using AppGestionCurriculums.Views.Eva_funciones;
using AppGestionCurriculums.Views.Eva_proyectos;
using AppGestionCurriculums.Views.Personas;

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

            MenuPages.Add((int)MenuItemType.Personas, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Personas:
                        MenuPages.Add(id, new NavigationPage(new FicViPersonasList(null)));
                        break;

                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
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