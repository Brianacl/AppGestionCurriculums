using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.GradoEstudios
{
    public class FicVmGradoEstudiosItem : FicViewModelBase
    {
        private Eva_carrera_grado_estudios Fic_NuevoGradoEstudio;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvGradoEstudios IFicSrvGradoEstudios;

        public FicVmGradoEstudiosItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvGradoEstudios IFicSrvGradoEstudios)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvGradoEstudios = IFicSrvGradoEstudios;
        }

        public Eva_carrera_grado_estudios NuevoGradoEstudio
        {
            get { return Fic_NuevoGradoEstudio; }
            set
            {
                Fic_NuevoGradoEstudio = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicGradoEstudioSeleccionado = FicPaNavigationContext as Eva_carrera_grado_estudios;

                if (FicGradoEstudioSeleccionado != null)
                {
                    NuevoGradoEstudio = FicGradoEstudioSeleccionado;
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
                await IFicSrvGradoEstudios.FicMetInsertNewGradoEstudios(NuevoGradoEstudio);
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
