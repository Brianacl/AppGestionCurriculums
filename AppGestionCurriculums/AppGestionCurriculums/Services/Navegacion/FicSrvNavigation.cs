using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.ViewModels.Proyectos;
using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using AppGestionCurriculums.ViewModels.Funciones;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using AppGestionCurriculums.Views.Eva_funciones;
using AppGestionCurriculums.Views.Eva_grado_estudios;
using AppGestionCurriculums.Views.Eva_idiomas;
using AppGestionCurriculums.Views.Eva_proyectos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using AppGestionCurriculums.Views.Competencias;
using AppGestionCurriculums.Views.CurriculumsPersonas;
using AppGestionCurriculums.Views.Personas;
using AppGestionCurriculums.ViewModels.Personas;
using AppGestionCurriculums.Views;
using AppGestionCurriculums.ViewModels.Curriculos;
using AppGestionCurriculums.Views.Curriculos;
using AppGestionCurriculums.ViewModels.ExperienciaLaboral;
using AppGestionCurriculums.Views.ExperienciaLaboral;

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
            { typeof(FicVmProyectosList),typeof(FicViProyectosList) },
            { typeof(FicVmProyectosItem),typeof(FicViProyectosItem) },
            { typeof(FicVmProyectosDetalle),typeof(FicViProyectosDetalle) },
            //Betsy
            { typeof(FicVmCompetenciasList),typeof(FicViCompetenciasList) },
            { typeof(FicVmCompetenciasItem), typeof(FicViCompetenciasItem) },
            { typeof(FicVmCompetenciasDetalle),typeof(FicViCompetenciasDetalle) },
            { typeof(FicVmCurriculumsPersonasList),typeof(FicViCurriculumsPersonasList) },
            { typeof(FicVmCurriculumsPersonasDetalle),typeof(FicViCurriculumsPersonasDetalle) },
            { typeof(FicVmDireccionWebDetalle),typeof(FicViPersonaDirWebDetalle) },
            { typeof(FicVmDomicilioDetalle),typeof(FicViPersonaDomicilioDetalle) },
            { typeof(FicVmTelefonoDetalle),typeof(FicViPersonaTelefonoDetalle) },
            { typeof(FicVmCurriculumsPersonasItem),typeof(FicViCurriculumsPersonasItem) },

            //Personas
            { typeof(FicVmPersonasList),typeof(FicViPersonasList) },
            { typeof(FicVmPersonasDetalle),typeof(FicViPersonasDetalle) },
            { typeof(FicVmPersonasItem),typeof(FicViPersonasItem) },
            //Curriculos
            { typeof(FicVmCurriculosDetalle),typeof(FicViCurriculosDetalle) },
            { typeof(FicVmCurriculosItem),typeof(FicViCurriculosItem) },

            //Alegria
            { typeof(FicVmExperienciaList),typeof(FicViExperienciaList) },
            { typeof(FicVmExperienciaDetalle),typeof(FicViExperienciaDetalle) },
            { typeof(FicVmExperienciaItem),typeof(FicViExperienciaItem) },
        };

        #region METODOS DE IMPLEMENTACION DE LA INTERFACE -> IFicSrvNavigationInventario
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            System.Diagnostics.Debug.WriteLine("En el NavigateTo");
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateBack()
        {
            var mdp = Application.Current.MainPage as MasterDetailPage;
            mdp.Detail.Navigation.PopAsync();
        }
        #endregion
    }
}
