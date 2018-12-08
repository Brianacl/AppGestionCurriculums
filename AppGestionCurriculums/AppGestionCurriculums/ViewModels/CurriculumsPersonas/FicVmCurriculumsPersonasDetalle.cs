using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
using AppGestionCurriculums.Interfaces.Navigation;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.CurriculumsPersonas
{
    public class FicVmCurriculumsPersonasDetalle : FicVmBase
    {
        private Rh_cat_personas Fic_rh_cat_personas;

        private ICommand FicCancelCommand;
        private ICommand _FicDomicilioPersonasCommand;
        private ICommand _FicDirWebPersonasCommand;
        private ICommand _FicTelefonoPersonasCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCurriculumsPersonas IFicLoSrvCurriculumsPersonas;

        public FicVmCurriculumsPersonasDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculumsPersonas IFicSrvCurriculumsPersonas)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCurriculumsPersonas = IFicSrvCurriculumsPersonas;

        }

        public ICommand FicMetDomicilioPersonasICommand
        {
            get
            {
                return _FicDomicilioPersonasCommand = _FicDomicilioPersonasCommand ??
                    new FicVmDelegateCommand(FicMetDomicilioPersonas);
            }
        }

        private void FicMetDomicilioPersonas()
        {
            Rh_cat_domicilios dom = IFicLoSrvCurriculumsPersonas.FicMetObtenerDomicilio(DatosPersona).Result;
            IFicLoSrvNavigation.FicMetNavigateTo<FicVmDomicilioDetalle>
               (dom);
        }

        public ICommand FicMetDirWebPersonasICommand
        {
            get
            {
                return _FicDirWebPersonasCommand = _FicDirWebPersonasCommand ??
                    new FicVmDelegateCommand(FicMetDirWebPersonas);
            }
        }
        private void FicMetDirWebPersonas()
        {
            Rh_cat_dir_web dirWeb = IFicLoSrvCurriculumsPersonas.FicMetObtenerDirWeb(DatosPersona).Result;
            IFicLoSrvNavigation.FicMetNavigateTo<FicVmDireccionWebDetalle>
               (dirWeb);
        }

        public ICommand FicMetTelefonoPersonasICommand
        {
            get
            {
                return _FicTelefonoPersonasCommand = _FicTelefonoPersonasCommand ??
                    new FicVmDelegateCommand(FicMetTelefonoPersonas);
            }
        }

        private void FicMetTelefonoPersonas()
        {
            Rh_cat_telefonos tel = IFicLoSrvCurriculumsPersonas.FicMetObtenerTelefono(DatosPersona).Result;
            IFicLoSrvNavigation.FicMetNavigateTo<FicVmTelefonoDetalle>
               (tel);
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
