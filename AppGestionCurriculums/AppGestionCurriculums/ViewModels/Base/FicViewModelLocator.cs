using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Services;
using AppGestionCurriculums.Services.Navegacion;
using Autofac;
namespace AppGestionCurriculums.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            var FicContainerBuilder = new ContainerBuilder();

            FicContainerBuilder.RegisterType<FicVmEvaExperienciaLaboralList>();
            FicContainerBuilder.RegisterType<FicVmEvaExperienciaLaboralItem>();
            FicContainerBuilder.RegisterType<FicVmEvaExperienciaLaboralDetalle>();

            FicContainerBuilder.RegisterType<FicVmEvaCurriculoReferenciasList>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoReferenciasItem>();
            FicContainerBuilder.RegisterType<FicVmEvaCurriculoReferenciasDetalle>();



            FicContainerBuilder.RegisterType<FicSrvNavigationExperiencias>().As<IFicSrvNavigationExperiencia>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvExperienciaLaboral>().As<IFicSrvExperienciaList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvReferencia>().As<IFicSrvReferencia>().SingleInstance();

            if(FicIContainer != null)
            {
                FicIContainer.Dispose();
            }
            FicIContainer = FicContainerBuilder.Build();
            
        }

        public FicVmEvaExperienciaLaboralList FicVmExperienciasList
        {
            get { return FicIContainer.Resolve<FicVmEvaExperienciaLaboralList>(); }
        }

        public FicVmEvaExperienciaLaboralItem FicVmExperienciasItem
        {
            get { return FicIContainer.Resolve<FicVmEvaExperienciaLaboralItem>(); }
        }

        public FicVmEvaExperienciaLaboralDetalle FicVmExperienciasDetalle
        {
            get { return FicIContainer.Resolve<FicVmEvaExperienciaLaboralDetalle>(); }
        }

        //
        public FicVmEvaCurriculoReferenciasList FicVmReferenciasList
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoReferenciasList>(); }
        }

        public FicVmEvaCurriculoReferenciasItem FicVmReferenciasItem
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoReferenciasItem>(); }
        }

        public FicVmEvaCurriculoReferenciasDetalle FicVmReferenciasDetalle
        {
            get { return FicIContainer.Resolve<FicVmEvaCurriculoReferenciasDetalle>(); }
        }
    }
}
