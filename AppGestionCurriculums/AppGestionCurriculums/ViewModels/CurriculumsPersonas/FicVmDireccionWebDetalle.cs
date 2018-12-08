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
    public class FicVmDireccionWebDetalle : FicViewModelBase
    {
        private Rh_cat_dir_web Fic_rh_cat_dir_web;

        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;

        public FicVmDireccionWebDetalle(IFicSrvNavigation IFicSrvNavigation)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
        }

        public Rh_cat_dir_web DatosDirWeb
        {
            get { return Fic_rh_cat_dir_web; }
            set
            {
                Fic_rh_cat_dir_web = value;
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
                var FicDirWebPersonaSeleccionado = navigationContext as Rh_cat_dir_web;

                if (FicDirWebPersonaSeleccionado != null)
                {
                    DatosDirWeb = FicDirWebPersonaSeleccionado;
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
