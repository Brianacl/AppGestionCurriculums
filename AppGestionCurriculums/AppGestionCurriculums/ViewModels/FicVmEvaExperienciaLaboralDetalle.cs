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
    public class FicVmEvaExperienciaLaboralDetalle : FicViewModelBase
    {

        public Eva_experiencia_laboral FicExperienciaLaboralSeleccionado;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia;
        private IFicSrvExperienciaList IFicSrvExperienciaList;

        public FicVmEvaExperienciaLaboralDetalle(IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia, IFicSrvExperienciaList IFicSrvExperienciaList)
        {
            this.IFicSrvNavigationExperiencia = IFicSrvNavigationExperiencia;
            this.IFicSrvExperienciaList = IFicSrvExperienciaList;
        }

        public Eva_experiencia_laboral FicDatosExperienciaLaboral
        {
            get
            {
                return FicExperienciaLaboralSeleccionado;
            }
            set
            {
                FicExperienciaLaboralSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicExperienciaLaboral = FicPaNavigationContext as Eva_experiencia_laboral;
                if(FicExperienciaLaboral != null)
                {
                    FicDatosExperienciaLaboral = FicExperienciaLaboral;
                }
                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
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
                await IFicSrvExperienciaList.FicMetDeleteExperiencia(FicDatosExperienciaLaboral);
                IFicSrvNavigationExperiencia.FicMetNavigateBack();
            }
            catch(Exception e){
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }
        public ICommand FicMetCancelCommand
        {
            get
            {
                return FicCancelCommand = FicCancelCommand ??
                    new FicVmDelegateCommand(CancelCommandExecute);

            }
        }
        private void CancelCommandExecute()
        {
            IFicSrvNavigationExperiencia.FicMetNavigateBack();
        }
    }
}
