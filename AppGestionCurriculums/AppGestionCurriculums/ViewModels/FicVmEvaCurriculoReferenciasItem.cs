using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using System.Windows.Input;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionCurriculums.ViewModels
{
    public class FicVmEvaCurriculoReferenciasItem : FicViewModelBase
    {
        private Eva_curriculo_referencias Fic_NuevoReferencia;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia;
        private IFicSrvReferencia IFicSrvReferencia;

        public FicVmEvaCurriculoReferenciasItem(IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia, IFicSrvReferencia IFicSrvReferencia)
        {
            this.IFicSrvNavigationExperiencia = IFicSrvNavigationExperiencia;
            this.IFicSrvReferencia = IFicSrvReferencia;

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
                if(FicReferenciaSeleccionado != null)
                {
                    NuevoReferencia = FicReferenciaSeleccionado;
                }
                base.OnAppearing(FicPaNavigationContext);
            }catch(Exception e)
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
                await IFicSrvReferencia.FicMetInsertNewReferencia(NuevoReferencia);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), ""); 

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
            IFicSrvNavigationExperiencia.FicMetNavigateBack();
        }
    }
}
