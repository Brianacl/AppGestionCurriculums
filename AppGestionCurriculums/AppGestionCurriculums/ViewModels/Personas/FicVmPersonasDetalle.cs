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
    public class FicVmPersonasDetalle : FicViewModelBase
    {
        public Rh_cat_personas FicPersonaSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvRhCatPersonas IFicSrvRhCatPersonas;

        public FicVmPersonasDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvRhCatPersonas IFicSrvRhCatPersonas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvRhCatPersonas = IFicSrvRhCatPersonas;
        }

        public Rh_cat_personas FicDatosPersona
        {
            get { return FicPersonaSeleccionado; }
            set
            {
                FicPersonaSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicPersona = FicPaNavigationContext as Rh_cat_personas;

                if (FicPersona != null)
                {
                    FicDatosPersona = FicPersona;
                }

                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA ITEM", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetDeleteCommand
        {
            get
            {
                return FicDeleteCommand = FicDeleteCommand ??
                  new FicVmDelegateCommand(DeleteCommandExecute);
            }
        }

        public async void DeleteCommandExecute()
        {
            try
            {
                await IFicSrvRhCatPersonas.FicMetDeletePersona(FicDatosPersona);
                IFicSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - Delete", e.Message.ToString(), "OK");
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
