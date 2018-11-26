using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Views.Navegacion;
using AppGestionCurriculums.ViewModels.Navegacion;
using AppGestionCurriculums.ViewModels;
using Xamarin.Forms;
using AppGestionCurriculums.Views.Experiencias;



namespace AppGestionCurriculums.Services.Navegacion
{
    public class FicSrvNavigationExperiencias : IFicSrvNavigationExperiencia
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(FicVmExperienciasList), typeof(FicViExperienciasList)},
            { typeof(FicVmExperienciasItem), typeof(FicViExperienciasItem)},
            { typeof(FicVmExperienciasDetalle), typeof(FicViExperienciasDetalle)},

            { typeof(FicVmReferenciasList), typeof(FicViReferenciasList)},
            { typeof(FicVmReferenciasItem), typeof(FicViReferenciasItem)},
            { typeof(FicVmReferenciasDetalle), typeof(FicViReferenciasDetalle)},

        };

        #region Metodos implementacion de la nterface -> 
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if(FicPage != null){
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushModalAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if(FicPage != null)
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
