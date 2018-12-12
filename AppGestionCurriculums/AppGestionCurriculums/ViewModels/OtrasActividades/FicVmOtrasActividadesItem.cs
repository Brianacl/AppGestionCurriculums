using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.OtrasActividades
{
    public class FicVmOtrasActividadesItem : FicViewModelBase
    {
        private Eva_curriculo_otras_actividades Fic_NuevaOtraActividad;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvOtrasActividades IFicSrvOtrasActividades;

        public FicVmOtrasActividadesItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvOtrasActividades IFicSrvOtrasActividades)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvOtrasActividades = IFicSrvOtrasActividades;
        }

        public Eva_curriculo_otras_actividades NuevaOtraActividad
        {
            get { return Fic_NuevaOtraActividad; }
            set
            {
                Fic_NuevaOtraActividad = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicOtraActividadSeleccionado = FicPaNavigationContext as Eva_curriculo_otras_actividades;

                if (FicOtraActividadSeleccionado != null)
                {
                    NuevaOtraActividad = FicOtraActividadSeleccionado;
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
                await IFicSrvOtrasActividades.FicMetInsertNewOtraActividad(NuevaOtraActividad);
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
