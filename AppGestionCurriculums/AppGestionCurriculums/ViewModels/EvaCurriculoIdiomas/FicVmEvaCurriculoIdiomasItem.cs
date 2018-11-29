using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas
{
    public class FicVmEvaCurriculoIdiomasItem : FicViewModelBase
    {
        private Eva_curriculo_idiomas Fic_NuevoIdioma;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoIdiomas IFicSrvCurriculoIdiomas;

        public FicVmEvaCurriculoIdiomasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoIdiomas IFicSrvCurriculoIdiomas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoIdiomas = IFicSrvCurriculoIdiomas;
        }

        public Eva_curriculo_idiomas NuevoIdioma
        {
            get { return Fic_NuevoIdioma; }
            set
            {
                Fic_NuevoIdioma = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicIdiomaSeleccionado = FicPaNavigationContext as Eva_curriculo_idiomas;

                if (FicIdiomaSeleccionado != null)
                {
                    NuevoIdioma = FicIdiomaSeleccionado;
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
                await IFicSrvCurriculoIdiomas.FicMetInsertNewIdioma(NuevoIdioma);
                //IFicSrvNavigation.FicMetNavigateBack();
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
