using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Services;
using AppGestionCurriculums.Services.Navegacion;
using AppGestionCurriculums.ViewModels.Proyectos;
using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas;
using AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos;
using AppGestionCurriculums.ViewModels.Funciones;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using Autofac;
using System.Text;

namespace AppGestionCurriculums.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            var FicContainerBuilder = new ContainerBuilder();

            FicContainerBuilder.RegisterType<FicVmEvaCurriculoIdiomasList>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoIdiomasItem>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoIdiomasDetalle>();
            //-----------------------------------------------------------
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
            //-------------------------------------------------------
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoHerramientasList>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoHerramientasItem>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoHerramientasDetalle>();
            //-----------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoConocimientosList>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoConocimientosItem>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoConocimientosDetalle>();


            FicContainerBuilder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoIdiomas>().As<IFicSrvCurriculoIdiomas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvGradoEstudios>().As<IFicSrvGradoEstudios>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvFunciones>().As<IFicSrvFunciones>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvProyectos>().As<IFicSrvProyectos>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoHerrmaientas>().As<IFicSrvCurriculoHerramientas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoConocimientos>().As<IFicSrvCurriculoConocimientos>().SingleInstance();

            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }

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
