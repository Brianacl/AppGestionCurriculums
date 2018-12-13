using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using AppGestionCurriculums.Interfaces.CurriculumsPersonas;

namespace AppGestionCurriculums.ViewModels.CurriculumsPersonas
{
    public class FicVmCurriculumsPersonasItem : FicViewModelBase
    {
        private Rh_cat_personas Fic_Eva_curriculo_persona_item;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCurriculumsPersonas IFicLoSrvCurriculumsPersonas;



        public FicVmCurriculumsPersonasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculumsPersonas IFicSrvCurriculumsPersonas)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCurriculumsPersonas = IFicSrvCurriculumsPersonas;

        }

        public Rh_cat_personas NuevoCurriculo
        {
            get { return Fic_Eva_curriculo_persona_item; }
            set
            {
                Fic_Eva_curriculo_persona_item = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object navigationContext)
        {
            try
            {
                var FicPersonaSeleccionada = navigationContext as Rh_cat_personas;
                
                if (FicPersonaSeleccionada != null)
                {
                    NuevoCurriculo = FicPersonaSeleccionada;
                }


                base.OnAppearing(navigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - OnAppearing", e.Message.ToString(), "OK");
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
                await IFicLoSrvCurriculumsPersonas.FicMetInsertCurriculo(NuevoCurriculo);
                IFicLoSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SaveCommand", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        private void CancelCommandExecute()
        {
            IFicLoSrvNavigation.FicMetNavigateBack();
        }

    }
}
