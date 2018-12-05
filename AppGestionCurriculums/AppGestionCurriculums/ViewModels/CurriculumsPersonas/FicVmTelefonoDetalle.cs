using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
using AppGestionCurriculums.Interfaces.Navigation;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.CurriculumsPersonas
{
    public class FicVmTelefonoDetalle : FicVmBase
    {
        private Rh_cat_telefonos Fic_rh_cat_telefonos;

        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;      

        public FicVmTelefonoDetalle(IFicSrvNavigation IFicSrvNavigation)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
        }    

        public Rh_cat_telefonos DatosPersona
        {
            get { return Fic_rh_cat_telefonos; }
            set
            {
                Fic_rh_cat_telefonos = value;
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
                var FicTelefonoSeleccionado = navigationContext as Rh_cat_telefonos;

                if (FicTelefonoSeleccionado != null)
                {
                    DatosPersona = FicTelefonoSeleccionado;
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
