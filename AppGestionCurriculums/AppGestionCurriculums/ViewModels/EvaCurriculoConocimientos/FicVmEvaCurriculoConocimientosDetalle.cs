using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System;

namespace AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos
{
    public class FicVmEvaCurriculoConocimientosDetalle : FicViewModelBase
    {
        public Eva_curriculo_conocimientos FicConocimientoSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos;

        public FicVmEvaCurriculoConocimientosDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoConocimientos = IFicSrvCurriculoConocimientos;
        }

        public Eva_curriculo_conocimientos FicDatosConocimiento
        {
            get {return FicConocimientoSeleccionado;}
            set
            {
                FicConocimientoSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicConocimiento = FicPaNavigationContext as Eva_curriculo_conocimientos;

                if (FicConocimiento != null)
                {
                    FicDatosConocimiento = FicConocimiento;
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
                await IFicSrvCurriculoConocimientos.FicMetDeleteConocimiento(FicDatosConocimiento);
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
