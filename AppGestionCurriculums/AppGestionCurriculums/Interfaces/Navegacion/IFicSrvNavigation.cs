using System;

namespace AppGestionCurriculums.Interfaces.Navegacion
{
    public interface IFicSrvNavigation
    {
        void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null);
        void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null);
        void FicMetNavigateBack();
    }
}
