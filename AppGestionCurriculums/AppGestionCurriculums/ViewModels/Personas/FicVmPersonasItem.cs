using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Personas
{
    public class FicVmPersonasItem : FicViewModelBase
    {
        private Rh_cat_personas Fic_NuevoPersona;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvRhCatPersonas IFicSrvRhCatPersonas;

        public FicVmPersonasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvRhCatPersonas IFicSrvRhCatPersonas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvRhCatPersonas = IFicSrvRhCatPersonas;
        }

        public Rh_cat_personas NuevoPersona
        {
            get { return Fic_NuevoPersona; }
            set
            {
                Fic_NuevoPersona = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            System.Diagnostics.Debug.WriteLine("En el view model!");
            try
            {
                var FicPersonaSeleccionado = FicPaNavigationContext as Rh_cat_personas;

                if (FicPersonaSeleccionado != null)
                {
                    NuevoPersona = FicPersonaSeleccionado;
                }

                base.OnAppearing(FicPaNavigationContext);
                System.Diagnostics.Debug.WriteLine("Después del base");
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
                await IFicSrvRhCatPersonas.FicMetInsertNewPersona(NuevoPersona);
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
