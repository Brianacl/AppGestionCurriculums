using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.CurriculumsPersonas
{
    public class FicVmDomicilioDetalle : FicViewModelBase
    {
        private Rh_cat_domicilios Fic_rh_cat_domicilio;

        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;

        public FicVmDomicilioDetalle(IFicSrvNavigation IFicSrvNavigation)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
        }    
       
        public Rh_cat_domicilios DatosDomicilio
        {
            get { return Fic_rh_cat_domicilio; }
            set
            {
                Fic_rh_cat_domicilio = value;
                RaisePropertyChanged();
            }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }
  

        public async override void OnAppearing(object navigationContext)
        {
            try
            {
                var FicDomicilioPersonaSeleccionado = navigationContext as Rh_cat_domicilios;

                if (FicDomicilioPersonaSeleccionado != null)
                {
                    DatosDomicilio = FicDomicilioPersonaSeleccionado;
                }

                base.OnAppearing(navigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        private void CancelCommandExecute()
        {
            IFicLoSrvNavigation.FicMetNavigateBack();
        }
    }
}
