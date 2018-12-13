using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Curriculos
{
    public class FicVmCurriculosItem : FicViewModelBase
    {
        private Eva_curriculo_persona Fic_NuevoCurriculo;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvEvaCurriculoPersonas IFicSrvEvaCurriculoPersonas;

        public FicVmCurriculosItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvEvaCurriculoPersonas IFicSrvEvaCurriculoPersonas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvEvaCurriculoPersonas = IFicSrvEvaCurriculoPersonas;
        }

        public Eva_curriculo_persona NuevoCurriculo
        {
            get { return Fic_NuevoCurriculo; }
            set
            {
                Fic_NuevoCurriculo = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicCurriculoSeleccionado = FicPaNavigationContext as Eva_curriculo_persona;

                if (FicCurriculoSeleccionado != null)
                {
                    NuevoCurriculo = FicCurriculoSeleccionado;
                }


                base.OnAppearing(FicPaNavigationContext);
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
                await IFicSrvEvaCurriculoPersonas.FicMetInsertNewCurriculo(NuevoCurriculo);
                IFicSrvNavigation.FicMetNavigateBack();
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
            IFicSrvNavigation.FicMetNavigateBack();
        }
    }
}
