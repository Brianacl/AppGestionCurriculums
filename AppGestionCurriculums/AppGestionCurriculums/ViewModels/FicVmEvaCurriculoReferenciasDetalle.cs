using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionCurriculums.ViewModels
{
    public class FicVmEvaCurriculoReferenciasDetalle : FicViewModelBase
    {
        public Eva_curriculo_referencias FicReferenciaSeleccionado;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia;
        private IFicSrvReferencia IFicSrvReferencia;

        public FicVmEvaCurriculoReferenciasDetalle(IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia, IFicSrvReferencia IFicSrvReferencia)
        {
            this.IFicSrvNavigationExperiencia = IFicSrvNavigationExperiencia;
            this.IFicSrvReferencia = IFicSrvReferencia;
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
                RaisePropertyChanged("FicReferenciaSeleccionado");
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicReferencia = FicPaNavigationContext as Eva_curriculo_referencias;
                if(FicReferencia != null)
                {
                    FicDatosReferencia = FicReferencia;
                }
                base.OnAppearing(FicPaNavigationContext);
            }catch(Exception e)
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
                await IFicSrvReferencia.FicMetDeleteReferencia(FicDatosReferencia);
                IFicSrvNavigationExperiencia.FicMetNavigateBack();
            }catch(Exception e)
            {
                await new Page().DisplayAlert("", e.Message.ToString(), "");
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
            IFicSrvNavigationExperiencia.FicMetNavigateBack();
        }
    }
}
