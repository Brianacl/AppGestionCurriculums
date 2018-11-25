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

            FicContainerBuilder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculoIdiomas>().As<IFicSrvCurriculoIdiomas>().SingleInstance();
            //FicContainerBuilder.RegisterType<SrvExportarWebApi>().As<IFicSrvExportarWebApi>().SingleInstance();

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
    }//Fin clase
}
