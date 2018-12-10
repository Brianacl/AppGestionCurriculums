using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System;

namespace AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas
{
    public class FicVmEvaCurriculoHerramientasDetalle : FicViewModelBase
    {
        public Eva_curriculo_herramientas FicHerramientaSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoHerramientas IFicSrvCurriculoHerramientas;

        public FicVmEvaCurriculoHerramientasDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoHerramientas IFicSrvCurriculoHerramientas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoHerramientas = IFicSrvCurriculoHerramientas;
        }

        public Eva_curriculo_herramientas FicDatosHerramienta
        {
            get {return FicHerramientaSeleccionado;}
            set
            {
                FicHerramientaSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicHerramienta = FicPaNavigationContext as Eva_curriculo_herramientas;

                if (FicHerramienta != null)
                {
                    FicDatosHerramienta = FicHerramienta;
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
                await IFicSrvCurriculoHerramientas.FicMetDeleteHerramienta(FicDatosHerramienta);
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
