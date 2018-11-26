using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;


namespace AppGestionCurriculums.ViewModels
{
    public class FicVmEvaExperienciaLaboralItem : FicViewModelBase
    {
        private Eva_experiencia_laboral Fic_NuevoExperienciaLaboral;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;
        private IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia;
        private IFicSrvExperienciaList IFicSrvExperienciaList;

        public FicVmEvaExperienciaLaboralItem(IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia,IFicSrvExperienciaList IFicSrvExperienciaList)
        {
            this.IFicSrvNavigationExperiencia = IFicSrvNavigationExperiencia;
            this.IFicSrvExperienciaList = IFicSrvExperienciaList;

        }

        public Eva_experiencia_laboral NuevoExperienciaLaboral
        {
            get
            {
                return Fic_NuevoExperienciaLaboral;
            }
            set
            {
                Fic_NuevoExperienciaLaboral = value;
                RaisePropertyChanged();
            }
        }//nuevoexp

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicExperienciaLaboralSeleccionado = FicPaNavigationContext as Eva_experiencia_laboral;
                if(FicExperienciaLaboralSeleccionado != null)
                {
                    NuevoExperienciaLaboral = FicExperienciaLaboralSeleccionado;
                }
                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
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
                await IFicSrvExperienciaList.FicMetInsertNewExperiencia(NuevoExperienciaLaboral);
                IFicSrvNavigationExperiencia.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "");
            }
        }
        public ICommand FicMetCancelCommand
        {
            get
            {
                return FicCancelCommand = FicCancelCommand ?? new
                    FicVmDelegateCommand(CancelCommandExecute);
            }
        }

        private void CancelCommandExecute()
        {
            IFicSrvNavigationExperiencia.FicMetNavigateBack();
        }
    }
}
