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
    public class FicVmTelefonoDetalle : FicViewModelBase
    {
        private Rh_cat_telefonos Fic_rh_cat_telefono;

        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;

        public FicVmTelefonoDetalle(IFicSrvNavigation IFicSrvNavigation)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
        }

        public Rh_cat_telefonos DatosTelefono
        {
            get { return Fic_rh_cat_telefono; }
            set
            {
                Fic_rh_cat_telefono = value;
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
                var FicTelefonoPersonaSeleccionado = navigationContext as Rh_cat_telefonos ;

                if (FicTelefonoPersonaSeleccionado != null)
                {
                    DatosTelefono = FicTelefonoPersonaSeleccionado;
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
