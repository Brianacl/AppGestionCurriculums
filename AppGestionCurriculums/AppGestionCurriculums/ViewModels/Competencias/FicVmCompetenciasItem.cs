using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.Navigation;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace AppGestionCurriculums.ViewModels.Competencias
{
    public class FicVmCompetenciasItem : FicVmBase
    {
        private Eva_curriculo_competencias Fic_Eva_curriculo_competencias_item;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCompetencias IFicLoSrvCompetencias;



        public FicVmCompetenciasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCompetencias IFicSrvCompetencias)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCompetencias = IFicSrvCompetencias;

        }

        public Eva_curriculo_competencias NuevaCompetencia
        {
            get { return Fic_Eva_curriculo_competencias_item; }
            set
            {
                Fic_Eva_curriculo_competencias_item = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object navigationContext)
        {
            try
            {
                var FicCompetenciaSeleccionada = navigationContext as Eva_curriculo_competencias;
                
                if (FicCompetenciaSeleccionada != null)
                {
                    NuevaCompetencia = FicCompetenciaSeleccionada;
                }


                base.OnAppearing(navigationContext);
                //Fic_Eva_curriculo_competencias_item = new Eva_curriculo_competencias();
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
                await IFicLoSrvCompetencias.FicMetInsertCompetencia(NuevaCompetencia);
                //IFicLoSrvNavigation.FicMetNavigateTo<FicVmCompetenciasList>(null);
                //await Application.Current.MainPage.DisplayAlert("ALERTA", "Registro exitoso", "OK");
                IFicLoSrvNavigation.FicMetNavigateBack();
                //NuevaCompetencia = new Eva_curriculo_competencias();
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
