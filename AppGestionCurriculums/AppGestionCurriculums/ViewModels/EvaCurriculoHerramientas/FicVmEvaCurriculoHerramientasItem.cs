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

namespace AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas
{
    public class FicVmEvaCurriculoHerramientasItem : FicViewModelBase
    {
        private Eva_curriculo_herramientas Fic_NuevoHerramienta;
        private ObservableCollection<Tipo_gen_herramienta> _SourceGenHerramienta;
        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoHerramientas IFicSrvCurriculoHerramientas;

        public FicVmEvaCurriculoHerramientasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoHerramientas IFicSrvCurriculoHerramientas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoHerramientas = IFicSrvCurriculoHerramientas;
            _SourceGenHerramienta = new ObservableCollection<Tipo_gen_herramienta>();

        }

        public ObservableCollection<Tipo_gen_herramienta> SourceGenHerramienta
        {
            get { return _SourceGenHerramienta; }
            set
            {
                _SourceGenHerramienta = value;
                RaisePropertyChanged();
            }
        }

        public Eva_curriculo_herramientas NuevoHerramienta
        {
            get { return Fic_NuevoHerramienta; }
            set
            {
                Fic_NuevoHerramienta = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoHerramienta

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            { 
                var listaGenHerramientas = await IFicSrvCurriculoHerramientas.FicMetGetListTipoHerramienta();

                if (listaGenHerramientas != null)
                {
                    foreach (Tipo_gen_herramienta tiposGenHerramienta in listaGenHerramientas)
                    {
                        //System.Diagnostics.Debug.WriteLine(TiposGradoEstudios);
                        SourceGenHerramienta.Add(tiposGenHerramienta);
                    }
                }

                var FicHerramientaSeleccionado = FicPaNavigationContext as Eva_curriculo_herramientas;

                if (FicHerramientaSeleccionado != null)
                {
                    NuevoHerramienta = FicHerramientaSeleccionado;
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
                await IFicSrvCurriculoHerramientas.FicMetInsertNewHerramienta(NuevoHerramienta);
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
