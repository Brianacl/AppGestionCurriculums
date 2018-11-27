using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Services;
using AppGestionCurriculums.Services.Navegacion;
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

            FicContainerBuilder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoIdiomas>().As<IFicSrvCurriculoIdiomas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvGradoEstudios>().As<IFicSrvGradoEstudios>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvFunciones>().As<IFicSrvFunciones>().SingleInstance();

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
    }//Fin clase
}
