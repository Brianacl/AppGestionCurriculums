using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels
{
    public class FicVmFuncionesDetalle : FicViewModelBase
    {
        public Eva_actividades_funciones FicFuncionSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvFunciones IFicSrvFunciones;

        public FicVmFuncionesDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvFunciones IFicSrvFunciones)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvFunciones = IFicSrvFunciones;
        }

        public Eva_actividades_funciones FicDatosFuncion
        {
            get { return FicFuncionSeleccionado; }
            set
            {
                FicFuncionSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicFunciones = FicPaNavigationContext as Eva_actividades_funciones;

                if (FicFunciones != null)
                {
                    FicDatosFuncion = FicFunciones;
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
                await IFicSrvFunciones.FicMetDeleteFuncion(FicDatosFuncion);
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
