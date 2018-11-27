using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.ViewModels;
using AppGestionCurriculums.Views.Eva_funciones;
using AppGestionCurriculums.Views.Eva_grado_estudios;
using AppGestionCurriculums.Views.Eva_idiomas;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppGestionCurriculums.Services.Navegacion
{
    public class FicSrvNavigation : IFicSrvNavigation
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        { 
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            { typeof(FicVmEvaCurriculoIdiomasList),typeof(FicViEvaCurriculoIdiomasList) },
            { typeof(FicVmEvaCurriculoIdiomasItem),typeof(FicViEvaCurriculoIdiomasItem) },
            { typeof(FicVmEvaCurriculoIdiomasDetalle),typeof(FicViEvaCurriculoIdiomasDetalle) },
            { typeof(FicVmGradoEstudiosList),typeof(FicViGradoEstudiosList) },
            { typeof(FicVmGradoEstudiosItem),typeof(FicViGradoEstudiosItem) },
            { typeof(FicVmGradoEstudiosDetalle),typeof(FicViGradoEstudiosDetalle) },
            { typeof(FicVmFuncionesList),typeof(FicViFuncionesList) },
            { typeof(FicVmFuncionesItem),typeof(FicViFuncionesItem) },
            { typeof(FicVmFuncionesDetalle),typeof(FicViFuncionesDetalle) },
            /*{ typeof(FicVmExportarWebApi),typeof(ViExportarWebApi) },
            { typeof(FicVmImportarWebApi),typeof(ViImportarWebApi) },*/
        };

        #region METODOS DE IMPLEMENTACION DE LA INTERFACE -> IFicSrvNavigationInventario
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushModalAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushModalAsync(FicPage);
            }
        }

        public void FicMetNavigateBack()
        {
            var mdp = Application.Current.MainPage as MasterDetailPage;
            mdp.Detail.Navigation.PopModalAsync();
        }
        #endregion
    }
}
