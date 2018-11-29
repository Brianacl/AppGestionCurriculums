using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Proyectos
{
    public class FicVmProyectosDetalle : FicViewModelBase
    {
        public Eva_proyectos FicProyectoSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvProyectos IFicSrvProyectos;

        public FicVmProyectosDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvProyectos IFicSrvProyectos)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvProyectos = IFicSrvProyectos;
        }

        public Eva_proyectos FicDatosProyecto
        {
            get { return FicProyectoSeleccionado; }
            set
            {
                FicProyectoSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicProyectos = FicPaNavigationContext as Eva_proyectos;

                if (FicProyectos != null)
                {
                    FicDatosProyecto = FicProyectos;
                }

                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA ITEM", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetDeleteCommand
        {
            get
            {
                return FicDeleteCommand = FicDeleteCommand ??
                  new FicVmDelegateCommand(DeleteCommandExecute);
            }
        }

        public async void DeleteCommandExecute()
        {
            try
            {
                await IFicSrvProyectos.FicMetDeleteProyecto(FicDatosProyecto);
                IFicSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - Delete", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        private void CancelCommandExecute()
        {
            IFicSrvNavigation.FicMetNavigateBack();
        }
    }
}
