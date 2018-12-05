using AppGestionCurriculums.Interfaces.Navigation;
using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using AppGestionCurriculums.Views.Competencias;
using AppGestionCurriculums.Views.CurriculumsPersonas;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppGestionCurriculums.Services.Navigation
{
    public class FicSrvNavigation : IFicSrvNavigation
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        { 
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            { typeof(FicVmCompetenciasList),typeof(FicViCompetenciasList) },
            { typeof(FicVmCompetenciasItem), typeof(FicViCompetenciasItem) },
            { typeof(FicVmCompetenciasDetalle),typeof(FicViCompetenciasDetalle) },
            { typeof(FicVmCurriculumsPersonasList),typeof(FicViCurriculumsPersonasList) },
            { typeof(FicVmCurriculumsPersonasDetalle),typeof(FicViCurriculumsPersonasDetalle) },
            { typeof(FicVmDireccionWebDetalle),typeof(FicViPersonaDirWebDetalle) },
            { typeof(FicVmDomicilioDetalle),typeof(FicViPersonaDirWebDetalle) },
            { typeof(FicVmTelefonoDetalle),typeof(FicViPersonaTelefonoDetalle) }
        };
        #region // METODOS DE IMPLEMENTACION DE LA INTERFACE -> IFicSrvNavigationInventario

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(page);
            }
        }




        public void FicMetNavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(page);
            }
        }
        /*public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null, bool show = true)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext, show) as Page;

            if (page != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(page);
            }
        }*/
        
        public void FicMetNavigateBack()
        {
            var mdp = Application.Current.MainPage as MasterDetailPage;
            mdp.Detail.Navigation.PopAsync();
        }

        #endregion
    }
}
