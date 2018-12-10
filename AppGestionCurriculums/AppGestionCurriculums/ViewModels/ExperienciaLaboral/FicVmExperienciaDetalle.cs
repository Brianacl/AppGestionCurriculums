using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.ExperienciaLaboral
{
    public class FicVmExperienciaDetalle : FicViewModelBase
    {
        public Eva_experiencia_laboral FicExperienciaSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvExperienciaLaboral IFicSrvExperienciaLaboral;

        public FicVmExperienciaDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvExperienciaLaboral IFicSrvExperienciaLaboral)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvExperienciaLaboral = IFicSrvExperienciaLaboral;
        }

        public Eva_experiencia_laboral FicDatosExperiencia
        {
            get { return FicExperienciaSeleccionado; }
            set
            {
                FicExperienciaSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicExperiencia = FicPaNavigationContext as Eva_experiencia_laboral;

                if (FicExperiencia != null)
                {
                    FicDatosExperiencia = FicExperiencia;
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
                await IFicSrvExperienciaLaboral.FicMetDeleteExperiencia(FicDatosExperiencia);
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
