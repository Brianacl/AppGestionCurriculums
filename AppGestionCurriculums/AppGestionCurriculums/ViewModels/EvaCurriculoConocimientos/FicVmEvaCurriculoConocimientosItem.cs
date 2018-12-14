using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos
{
    public class FicVmEvaCurriculoConocimientosItem : FicViewModelBase
    {
        private Eva_curriculo_conocimientos Fic_NuevoConocimiento;
        private ObservableCollection<Eva_cat_conocimientos> _SourceConocimiento;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos;

        public FicVmEvaCurriculoConocimientosItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoConocimientos = IFicSrvCurriculoConocimientos;

            _SourceConocimiento = new ObservableCollection<Eva_cat_conocimientos>();
        }

        public Eva_curriculo_conocimientos NuevoConocimiento
        {
            get { return Fic_NuevoConocimiento; }
            set
            {
                Fic_NuevoConocimiento = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoConocimiento

        public ObservableCollection<Eva_cat_conocimientos> SourceConocimiento
        {
            get { return _SourceConocimiento; }
            set
            {
                _SourceConocimiento = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicConocimientoSeleccionado = FicPaNavigationContext as Eva_curriculo_conocimientos;

                if (FicConocimientoSeleccionado != null)
                {
                    NuevoConocimiento = FicConocimientoSeleccionado;
                }


                var listaConocimiento = await IFicSrvCurriculoConocimientos.FicMetGetListConocimientos();

                if (listaConocimiento != null)
                {
                    foreach (Eva_cat_conocimientos conocimiento in listaConocimiento)
                    {
                        //System.Diagnostics.Debug.WriteLine(TiposGradoEstudios);
                        _SourceConocimiento.Add(conocimiento);
                    }
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
                await IFicSrvCurriculoConocimientos.FicMetInsertNewConocimiento(NuevoConocimiento);
                //IFicSrvNavigation.FicMetNavigateBack();
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
