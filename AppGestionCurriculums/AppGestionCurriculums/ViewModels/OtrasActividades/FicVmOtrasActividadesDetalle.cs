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
    public class FicVmOtrasActividadesDetalle : FicViewModelBase
    {
        public Eva_curriculo_otras_actividades FicOtraActividadSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvOtrasActividades IFicSrvOtrasActividades;

        public FicVmOtrasActividadesDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvOtrasActividades IFicSrvOtrasActividades)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvOtrasActividades = IFicSrvOtrasActividades;
        }

        public Eva_curriculo_otras_actividades FicDatosOtraActividad
        {
            get { return FicOtraActividadSeleccionado; }
            set
            {
                FicOtraActividadSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicOtraActividad = FicPaNavigationContext as Eva_curriculo_otras_actividades;

                if (FicOtraActividad != null)
                {
                    FicDatosOtraActividad = FicOtraActividad;
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
                await IFicSrvOtrasActividades.FicMetDeleteOtraActividad(FicDatosOtraActividad);
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
