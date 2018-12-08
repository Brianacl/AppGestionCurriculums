using AppGestionCurriculums.Services.Competencias;
using AppGestionCurriculums.Services.CurriculumsPersonas;
using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
using AppGestionCurriculums.Services.Navigation;
using AppGestionCurriculums.Interfaces.Navigation;

namespace AppGestionCurriculums.ViewModels.Base
{
    public class FicVmLocator
    {
        private static IContainer FicContainer;

        public FicVmLocator()
        {
            //FIC: ContainerBuilder es una clase de la libreria de Autofac para poder ejecutar la interfaz en las diferentes plataformas 
            var FicContainerBuilder = new ContainerBuilder();

            //-------------------------------- VIEW MODELS ------------------------------------------------------
            //FIC: se procede a registrar las ViewModels para que se puedan mandar llamar en cualquier plataforma
            //---------------------------------------------------------------------------------------------------

            FicContainerBuilder.RegisterType<FicVmCompetenciasList>();
            FicContainerBuilder.RegisterType<FicVmCompetenciasItem>();
            FicContainerBuilder.RegisterType<FicVmCompetenciasDetalle>();
            FicContainerBuilder.RegisterType<FicVmCurriculumsPersonasList>();
            FicContainerBuilder.RegisterType<FicVmCurriculumsPersonasDetalle>();
            FicContainerBuilder.RegisterType<FicVmDireccionWebDetalle>();
            FicContainerBuilder.RegisterType<FicVmDomicilioDetalle>();
            FicContainerBuilder.RegisterType<FicVmTelefonoDetalle>();
            FicContainerBuilder.RegisterType<FicVmCurriculumsPersonasItem>();
            //------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------
            //FIC: se procede a registrar la interface con la que se comunican las ViewModels con los Servicios 
            //para poder ejecutar las tareas (metodos o funciones, etc) del servicio en cuestion.
            //---------------------------------------------------------------------------------------------------

            FicContainerBuilder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCompetencias>().As<IFicSrvCompetencias>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculumsPersonas>().As<IFicSrvCurriculumsPersonas>().SingleInstance();

            //FIC: se asigna o se libera el contenedor
            //-------------------------------------------
            if (FicContainer != null)
            {
                FicContainer.Dispose();
            }

            FicContainer = FicContainerBuilder.Build();
        }//CONSTRUCTOR0

        //-------------------- CONTROL DE INVENTARIOS ------------------------
        //FIC: se manda llamar desde el backend de la View de List
        public FicVmCompetenciasList FicVmCompetenciasList
        {
            get { return FicContainer.Resolve<FicVmCompetenciasList>(); }
        }

        public FicVmCompetenciasItem FicVmCompetenciasItem
        {
            get { return FicContainer.Resolve<FicVmCompetenciasItem>(); }
        }

        public FicVmCompetenciasDetalle FicVmCompetenciasDetalle
        {
            get { return FicContainer.Resolve<FicVmCompetenciasDetalle>(); }
        }

        public FicVmCurriculumsPersonasList FicVmCurriculumsPersonasList
        {
            get { return FicContainer.Resolve<FicVmCurriculumsPersonasList>(); }
        }

        public FicVmCurriculumsPersonasDetalle FicVmCurriculumsPersonasDetalle
        {
            get { return FicContainer.Resolve<FicVmCurriculumsPersonasDetalle>(); }
        }

        public FicVmCurriculumsPersonasItem FicVmCurriculumsPersonasItem
        {
            get { return FicContainer.Resolve<FicVmCurriculumsPersonasItem>(); }
        }

        public FicVmDireccionWebDetalle FicVmDireccionWebDetalle
        {
            get { return FicContainer.Resolve<FicVmDireccionWebDetalle>(); }
        }

        public FicVmDomicilioDetalle FicVmDomicilioDetalle
        {
            get { return FicContainer.Resolve<FicVmDomicilioDetalle>(); }
        }

        public FicVmTelefonoDetalle FicVmTelefonoDetalle
        {
            get { return FicContainer.Resolve<FicVmTelefonoDetalle>(); }
        }

    }//CLASS
}
