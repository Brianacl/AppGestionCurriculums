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

            FicContainerBuilder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoIdiomas>().As<IFicSrvCurriculoIdiomas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvGradoEstudios>().As<IFicSrvGradoEstudios>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvFunciones>().As<IFicSrvFunciones>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvProyectos>().As<IFicSrvProyectos>().SingleInstance();

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
    }//Fin clase
}
