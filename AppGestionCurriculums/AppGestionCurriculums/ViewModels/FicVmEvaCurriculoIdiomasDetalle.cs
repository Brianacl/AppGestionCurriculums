using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System;

namespace AppGestionCurriculums.ViewModels
{
    public class FicVmEvaCurriculoIdiomasDetalle : FicViewModelBase
    {
        public Eva_curriculo_idiomas FicIdiomaSeleccionado;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoIdiomas IFicSrvCurriculoIdiomas;

        public FicVmEvaCurriculoIdiomasDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoIdiomas IFicSrvCurriculoIdiomas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoIdiomas = IFicSrvCurriculoIdiomas;
        }

        public Eva_curriculo_idiomas FicDatosIdioma
        {
            get {return FicIdiomaSeleccionado;}
            set
            {
                FicIdiomaSeleccionado = value;
                RaisePropertyChanged("FicIdiomaSeleccionado");
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicIdioma = FicPaNavigationContext as Eva_curriculo_idiomas;

                if (FicIdioma != null)
                {
                    FicDatosIdioma = FicIdioma;
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
                await IFicSrvCurriculoIdiomas.FicMetDeleteIdioma(FicDatosIdioma);
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
