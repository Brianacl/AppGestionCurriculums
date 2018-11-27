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
    public class FicVmFuncionesItem : FicViewModelBase
    {
        private Eva_actividades_funciones Fic_NuevaFuncion;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvFunciones IFicSrvFunciones;

        public FicVmFuncionesItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvFunciones IFicSrvFunciones)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvFunciones = IFicSrvFunciones;
        }

        public Eva_actividades_funciones NuevaFuncion
        {
            get { return Fic_NuevaFuncion; }
            set
            {
                Fic_NuevaFuncion = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicFuncionSeleccionado = FicPaNavigationContext as Eva_actividades_funciones;

                if (FicFuncionSeleccionado != null)
                {
                    NuevaFuncion = FicFuncionSeleccionado;
                }


                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - OnAppearing", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetSaveCommand
        {
            get
            {
                return FicSaveCommand = FicSaveCommand ??
                  new FicVmDelegateCommand(SaveCommandExecute);
            }
        }

        private async void SaveCommandExecute()
        {
            try
            {
                await IFicSrvFunciones.FicMetInsertNewFuncion(NuevaFuncion);
                IFicSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SaveCommand", e.Message.ToString(), "OK");
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
