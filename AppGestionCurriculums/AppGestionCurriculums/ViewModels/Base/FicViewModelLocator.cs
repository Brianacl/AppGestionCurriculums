﻿using AppGestionCurriculums.Interfaces;
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


            //Servicios
            FicContainerBuilder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
                //Brian
            FicContainerBuilder.RegisterType<FicSrvCurriculoIdiomas>().As<IFicSrvCurriculoIdiomas>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvGradoEstudios>().As<IFicSrvGradoEstudios>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvFunciones>().As<IFicSrvFunciones>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvProyectos>().As<IFicSrvProyectos>().SingleInstance();

                //Betsy
            FicContainerBuilder.RegisterType<FicSrvCompetencias>().As<IFicSrvCompetencias>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCurriculumsPersonas>().As<IFicSrvCurriculumsPersonas>().SingleInstance();

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
    }//Fin clase
}
