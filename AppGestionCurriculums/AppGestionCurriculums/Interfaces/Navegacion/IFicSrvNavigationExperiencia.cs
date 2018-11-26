using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionCurriculums.Interfaces.Navegacion
{
    public interface IFicSrvNavigationExperiencia
    {
        void FicMetNavigateTo<FicDestinationViewModel>(object FicNavigationContext = null);
        void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null);
        void FicMetNavigateBack();
    }
}
