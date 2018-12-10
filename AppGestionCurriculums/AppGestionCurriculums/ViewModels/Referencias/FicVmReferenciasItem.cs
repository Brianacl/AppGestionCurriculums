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
    public class FicVmReferenciasItem : FicViewModelBase
    {
        private Eva_curriculo_referencias Fic_NuevoReferencia;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvReferencias IFicSrvReferencias;

        public FicVmReferenciasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvReferencias IFicSrvReferencias)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvReferencias = IFicSrvReferencias;

        }

        public Eva_curriculo_referencias NuevoReferencia
        {
            get
            {
                return Fic_NuevoReferencia;
            }
            set
            {
                Fic_NuevoReferencia = value;
                RaisePropertyChanged();
            }
        }


        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicReferenciaSeleccionado = FicPaNavigationContext as Eva_curriculo_referencias;
                if (FicReferenciaSeleccionado != null)
                {
                    NuevoReferencia = FicReferenciaSeleccionado;
                }
                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "o");
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
                await IFicSrvReferencias.FicMetInsertNewReferencia(NuevoReferencia);
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
                return FicCancelCommand = FicCancelCommand ??
                    new FicVmDelegateCommand(CancelCommandExecute);
            }
        }
        private void CancelCommandExecute()
        {
            IFicSrvNavigation.FicMetNavigateBack();
        }
    }
}
