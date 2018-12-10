using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Services;
using AppGestionCurriculums.Services.Navegacion;
using AppGestionCurriculums.ViewModels.Proyectos;
using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using AppGestionCurriculums.ViewModels.Funciones;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using Autofac;
using System.Text;
using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using AppGestionCurriculums.Services.Competencias;
using AppGestionCurriculums.Services.CurriculumsPersonas;
using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
using AppGestionCurriculums.ViewModels.Personas;
using AppGestionCurriculums.ViewModels.Curriculos;
using AppGestionCurriculums.ViewModels.ExperienciaLaboral;
using AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas;
using AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos;

namespace AppGestionCurriculums.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            var FicContainerBuilder = new ContainerBuilder();

            //Brian
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoIdiomasList>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoIdiomasItem>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoIdiomasDetalle>();
            //FicContainerBuilder.RegisterType<FicVmCatEdificiosDetalle>();
            FicContainerBuilder.RegisterType<FicVmGradoEstudiosList>();
            FicContainerBuilder.RegisterType<FicVmGradoEstudiosItem>();
            FicContainerBuilder.RegisterType<FicVmGradoEstudiosDetalle>();
            //------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicVmFuncionesList>();
            FicContainerBuilder.RegisterType<FicVmFuncionesItem>();
            FicContainerBuilder.RegisterType<FicVmFuncionesDetalle>();
            //------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicVmProyectosList>();
            FicContainerBuilder.RegisterType<FicVmProyectosItem>();
            FicContainerBuilder.RegisterType<FicVmProyectosDetalle>();

            //Betsy
            FicContainerBuilder.RegisterType<FicVmCompetenciasList>();
            FicContainerBuilder.RegisterType<FicVmCompetenciasItem>();
            FicContainerBuilder.RegisterType<FicVmCompetenciasDetalle>();
            FicContainerBuilder.RegisterType<FicVmCurriculumsPersonasList>();
            FicContainerBuilder.RegisterType<FicVmCurriculumsPersonasDetalle>();
            FicContainerBuilder.RegisterType<FicVmDireccionWebDetalle>();
            FicContainerBuilder.RegisterType<FicVmDomicilioDetalle>();
            FicContainerBuilder.RegisterType<FicVmTelefonoDetalle>();
            FicContainerBuilder.RegisterType<FicVmCurriculumsPersonasItem>();
            //Personas
            FicContainerBuilder.RegisterType<FicVmPersonasList>();
            FicContainerBuilder.RegisterType<FicVmPersonasItem>();
            FicContainerBuilder.RegisterType<FicVmPersonasDetalle>();
            //Curriculos
            FicContainerBuilder.RegisterType<FicVmCurriculosItem>();
            FicContainerBuilder.RegisterType<FicVmCurriculosDetalle>();

            //Alegria
            FicContainerBuilder.RegisterType<FicVmExperienciaList>();
            FicContainerBuilder.RegisterType<FicVmExperienciaItem>();
            FicContainerBuilder.RegisterType<FicVmExperienciaDetalle>();

            //Peps
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoHerramientasList>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoHerramientasItem>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoHerramientasDetalle>();
            //-----------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoConocimientosList>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoConocimientosItem>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoConocimientosDetalle>();

            //Servicios
            FicContainerBuilder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
                //Brian
            FicContainerBuilder.RegisterType<FicSrvCurriculoIdiomas>().As<IFicSrvCurriculoIdiomas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvGradoEstudios>().As<IFicSrvGradoEstudios>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvFunciones>().As<IFicSrvFunciones>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvProyectos>().As<IFicSrvProyectos>().SingleInstance();

                //Betsy
            FicContainerBuilder.RegisterType<FicSrvCompetencias>().As<IFicSrvCompetencias>().SingleInstance();
            //FicContainerBuilder.RegisterType<FicSrvCurriculumsPersonas>().As<IFicSrvCurriculumsPersonas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvRhCatPersonas>().As<IFicSrvRhCatPersonas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoPersonas>().As<IFicSrvEvaCurriculoPersonas>().SingleInstance();

            //Alegria
            FicContainerBuilder.RegisterType<FicSrvExperienciaLaboral>().As<IFicSrvExperienciaLaboral>().SingleInstance();

            //jjesusmonroy
            FicContainerBuilder.RegisterType<FicSrvCurriculoHerrmaientas>().As<IFicSrvCurriculoHerramientas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoConocimientos>().As<IFicSrvCurriculoConocimientos>().SingleInstance();


            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }

        //Brian
        public FicVmEvaCurriculoIdiomasList FicVmIdiomasList
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoIdiomasList>(); }
        }

        public FicVmEvaCurriculoIdiomasItem FicVmIdiomasItem
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoIdiomasItem>(); }
        }

        public FicVmEvaCurriculoIdiomasDetalle FicVmIdiomasDetalle
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoIdiomasDetalle>(); }
        }

        public FicVmGradoEstudiosList FicVmGradoEstudiosList
        {
            get { return FicIContainer.Resolve<FicVmGradoEstudiosList>(); }
        }

        public FicVmGradoEstudiosItem FicVmGradoEstudiosItem
        {
            get { return FicIContainer.Resolve<FicVmGradoEstudiosItem>(); }
        }

        public FicVmGradoEstudiosDetalle FicVmGradoEstudiosDetalle
        {
            get { return FicIContainer.Resolve<FicVmGradoEstudiosDetalle>(); }
        }

        public FicVmFuncionesList FicVmFuncionesList
        {
            get { return FicIContainer.Resolve<FicVmFuncionesList>(); }
        }

        public FicVmFuncionesItem FicVmFuncionesItem
        {
            get { return FicIContainer.Resolve<FicVmFuncionesItem>(); }
        }

        public FicVmFuncionesDetalle FicVmFuncionesDetalle
        {
            get { return FicIContainer.Resolve<FicVmFuncionesDetalle>(); }
        }

        public FicVmProyectosList FicVmProyectosList
        {
            get { return FicIContainer.Resolve<FicVmProyectosList>(); }
        }

        public FicVmProyectosItem FicVmProyectosItem
        {
            get { return FicIContainer.Resolve<FicVmProyectosItem>(); }
        }

        public FicVmProyectosDetalle FicVmProyectosDetalle
        {
            get { return FicIContainer.Resolve<FicVmProyectosDetalle>(); }
        }

        //Betsy
        public FicVmCompetenciasList FicVmCompetenciasList
        {
            get { return FicIContainer.Resolve<FicVmCompetenciasList>(); }
        }

        public FicVmCompetenciasItem FicVmCompetenciasItem
        {
            get { return FicIContainer.Resolve<FicVmCompetenciasItem>(); }
        }

        public FicVmCompetenciasDetalle FicVmCompetenciasDetalle
        {
            get { return FicIContainer.Resolve<FicVmCompetenciasDetalle>(); }
        }

        public FicVmCurriculumsPersonasList FicVmCurriculumsPersonasList
        {
            get { return FicIContainer.Resolve<FicVmCurriculumsPersonasList>(); }
        }

        public FicVmCurriculumsPersonasDetalle FicVmCurriculumsPersonasDetalle
        {
            get { return FicIContainer.Resolve<FicVmCurriculumsPersonasDetalle>(); }
        }

        public FicVmCurriculumsPersonasItem FicVmCurriculumsPersonasItem
        {
            get { return FicIContainer.Resolve<FicVmCurriculumsPersonasItem>(); }
        }

        public FicVmDireccionWebDetalle FicVmDireccionWebDetalle
        {
            get { return FicIContainer.Resolve<FicVmDireccionWebDetalle>(); }
        }

        public FicVmDomicilioDetalle FicVmDomicilioDetalle
        {
            get { return FicIContainer.Resolve<FicVmDomicilioDetalle>(); }
        }

        public FicVmTelefonoDetalle FicVmTelefonoDetalle
        {
            get { return FicIContainer.Resolve<FicVmTelefonoDetalle>(); }
        }

        //Personas
        public FicVmPersonasList FicVmPersonasList
        {
            get { return FicIContainer.Resolve<FicVmPersonasList>(); }
        }

        public FicVmPersonasItem FicVmPersonasItem
        {
            get { return FicIContainer.Resolve<FicVmPersonasItem>(); }
        }

        public FicVmPersonasDetalle FicVmPersonasDetalle
        {
            get { return FicIContainer.Resolve<FicVmPersonasDetalle>(); }
        }

        //Curriculo
        public FicVmCurriculosItem FicVmCurriculosItem
        {
            get { return FicIContainer.Resolve<FicVmCurriculosItem>(); }
        }

        public FicVmCurriculosDetalle FicVmCurriculosDetalle
        {
            get { return FicIContainer.Resolve<FicVmCurriculosDetalle>(); }
        }

        //Alegria
        public FicVmExperienciaList FicVmExperienciaList
        {
            get { return FicIContainer.Resolve<FicVmExperienciaList>(); }
        }

        public FicVmExperienciaItem FicVmExperienciaItem
        {
            get { return FicIContainer.Resolve<FicVmExperienciaItem>(); }
        }

        public FicVmExperienciaDetalle FicVmExperienciaDetalle
        {
            get { return FicIContainer.Resolve<FicVmExperienciaDetalle>(); }
        }

        //jjesusmonroy

        public FicVmEvaCurriculoHerramientasList FicVmHerramientasList
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoHerramientasList>(); }
        }

        public FicVmEvaCurriculoHerramientasItem FicVmHerramientasItem
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoHerramientasItem>(); }
        }

        public FicVmEvaCurriculoHerramientasDetalle FicVmHerramientasDetalle
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoHerramientasDetalle>(); }
        }

        public FicVmEvaCurriculoConocimientosList FicVmConocimientosList
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoConocimientosList>(); }
        }

        public FicVmEvaCurriculoConocimientosItem FicVmConocimientosItem
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoConocimientosItem>(); }
        }

        public FicVmEvaCurriculoConocimientosDetalle FicVmConocimientosDetalle
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoConocimientosDetalle>(); }
        }
    }//Fin clase
}
