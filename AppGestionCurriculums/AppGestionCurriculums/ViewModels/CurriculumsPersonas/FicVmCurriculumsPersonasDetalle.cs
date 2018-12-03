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
    public class FicVmCurriculumsPersonasDetalle : FicVmBase
    {
        private Rh_cat_personas Fic_rh_cat_personas;

        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCurriculumsPersonas IFicLoSrvCurriculumsPersonas;

        public FicVmCurriculumsPersonasDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculumsPersonas IFicSrvCurriculumsPersonas)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCurriculumsPersonas = IFicSrvCurriculumsPersonas;

        }    

        public Rh_cat_personas DatosPersona
        {
            get { return Fic_rh_cat_personas; }
            set
            {
                Fic_rh_cat_personas = value;
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
                var FicCurriculumPersonaSeleccionado = navigationContext as Rh_cat_personas;

                if (FicCurriculumPersonaSeleccionado != null)
                {
                    DatosPersona = FicCurriculumPersonaSeleccionado;
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
