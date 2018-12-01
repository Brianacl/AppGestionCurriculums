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
    public class FicVmGradoEstudiosDetalle : FicViewModelBase
    {
        public Eva_carrera_grado_estudios FicGradoEstudioSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvGradoEstudios IFicSrvGradoEstudios;

        public FicVmGradoEstudiosDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvGradoEstudios IFicSrvGradoEstudios)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvGradoEstudios = IFicSrvGradoEstudios;
        }

        public Eva_carrera_grado_estudios FicDatosGradoEstudio
        {
            get { return FicGradoEstudioSeleccionado; }
            set
            {
                FicGradoEstudioSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicGradoEstudio = FicPaNavigationContext as Eva_carrera_grado_estudios;

                if (FicGradoEstudio != null)
                {
                    FicDatosGradoEstudio = FicGradoEstudio;
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
                await IFicSrvGradoEstudios.FicMetDeleteGradoEstudios(FicDatosGradoEstudio);
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
