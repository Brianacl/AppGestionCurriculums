using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Referencias
{
    public class FicVmReferenciasDetalle : FicViewModelBase
    {
        public Eva_curriculo_referencias FicReferenciaSeleccionado;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvReferencias IFicSrvReferencias;

        public FicVmReferenciasDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvReferencias IFicSrvReferencias)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvReferencias = IFicSrvReferencias;
        }

        public Eva_curriculo_referencias FicDatosReferencia
        {
            get
            {
                return FicReferenciaSeleccionado;
            }
            set
            {
                FicReferenciaSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicReferencia = FicPaNavigationContext as Eva_curriculo_referencias;
                if (FicReferencia != null)
                {
                    FicDatosReferencia = FicReferencia;
                }
                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
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
                await IFicSrvReferencias.FicMetDeleteReferencia(FicDatosReferencia);
                IFicSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "");
            }
        }

        public ICommand FicMetCancelCommand
        {
            get
            {
                return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute);
            }
        }

        private void CancelCommandExecute()
        {
            IFicSrvNavigation.FicMetNavigateBack();
        }
    }
}
