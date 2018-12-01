using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.EvaCurriculoHerramientas
{
    public class FicVmEvaCurriculoHerramientasList : FicViewModelBase
    {
        public ObservableCollection<Eva_curriculo_herramientas> _FicDataGrid_SourceHerramientas;
        public Eva_curriculo_herramientas _FicDataGrid_SelectedHerramienta;
        private ICommand _FicAddHerramientaCommand;
        private ICommand _FicEditHerramientaCommand;
        private ICommand _FicDetalleHerramientaCommand;
        private ICommand _FicDeleteHerramientaCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoHerramientas IFicSrvCurriculoHerramientas;

        public FicVmEvaCurriculoHerramientasList(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoHerramientas IFicSrvCurriculoHerramientas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoHerramientas = IFicSrvCurriculoHerramientas;

            _FicDataGrid_SourceHerramientas = new ObservableCollection<Eva_curriculo_herramientas>();
        }

        public ObservableCollection<Eva_curriculo_herramientas> SourceHerramientas
        {
            get
            {
                return _FicDataGrid_SourceHerramientas;
            }

            set
            {
                if (_FicDataGrid_SourceHerramientas != value)
                {
                    _FicDataGrid_SourceHerramientas = value;
                    RaisePropertyChanged("SourceHerramientas");
                }
            }
        }//Fin SourceHerramientas

        public Eva_curriculo_herramientas SelectedHerramienta
        {
            get
            {
                return _FicDataGrid_SelectedHerramienta;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedHerramienta = value;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddHerramientaICommand
        {
            get
            {
                return _FicAddHerramientaCommand = _FicAddHerramientaCommand ??
                    new FicVmDelegateCommand(FicMetAddHerramienta);
            }
        }

        public ICommand FicMetEditHerramientaICommand
        {
            get
            {
                return _FicEditHerramientaCommand = _FicEditHerramientaCommand ??
                    new FicVmDelegateCommand(FicMetEditHerramienta);
            }
        }

        public ICommand FicMetDetalleHerramientaICommand
        {
            get
            {
                return _FicDetalleHerramientaCommand = _FicDetalleHerramientaCommand ??
                    new FicVmDelegateCommand(FicMetDetalleHerramienta);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteHerramientaCommand = _FicDeleteHerramientaCommand ??
                    new FicVmDelegateCommand(FicMetDeleteHerramienta);
            }
        }

        private async void FicMetDeleteHerramienta()
        {
            try
            {
                if (_FicDataGrid_SelectedHerramienta != null)
                {
                    await IFicSrvCurriculoHerramientas.FicMetDeleteHerramienta(_FicDataGrid_SelectedHerramienta);
                    _FicDataGrid_SelectedHerramienta = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public void FicMetAddHerramienta()
        {
            IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoHerramientasItem>
                (new Eva_curriculo_herramientas());
        }

        private async void FicMetEditHerramienta()
        {
            if (_FicDataGrid_SelectedHerramienta != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoHerramientasItem>
                    (_FicDataGrid_SelectedHerramienta);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar,  primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleHerramienta()
        {
            if (_FicDataGrid_SelectedHerramienta != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoHerramientasDetalle>
                    (_FicDataGrid_SelectedHerramienta);
            }
             else
                await new Page().DisplayAlert("ALERTA - editar", "Para ver los detalles,  primero seleccione un registro", "OK");
        }



        public async override void OnAppearing(object context)
        {
            try
            {
                SourceHerramientas.Clear();

                var source_local_inv = await IFicSrvCurriculoHerramientas.FicMetGetListHerramientas();

                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_herramientas herramienta in source_local_inv)
                    {
                        SourceHerramientas.Add(herramienta);
                    }
                }//No llena el grid, llena el observableCollection para poder hacer el binding
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW
    }//Fin clase
}
