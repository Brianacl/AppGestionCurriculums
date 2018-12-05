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
    public class FicVmDireccionWebDetalle : FicVmBase
    {
        private Rh_cat_dir_web Fic_rh_cat_dirWeb;

        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;

        public FicVmDireccionWebDetalle(IFicSrvNavigation IFicSrvNavigation)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
        }    

        public Rh_cat_dir_web DatosPersona
        {
            get { return Fic_rh_cat_dirWeb; }
            set
            {
                Fic_rh_cat_dirWeb = value;
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
                var FicDirWebSeleccionado = navigationContext as Rh_cat_dir_web;

                if (FicDirWebSeleccionado != null)
                {
                    DatosPersona = FicDirWebSeleccionado;
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
