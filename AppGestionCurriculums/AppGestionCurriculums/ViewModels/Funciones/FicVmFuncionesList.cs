using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Funciones
{
    public class FicVmFuncionesList : FicViewModelBase
    {
        public ObservableCollection<Eva_actividades_funciones> _FicDataGrid_SourceFunciones;
        public Eva_actividades_funciones _FicDataGrid_SelectedFuncion;
        private ICommand _FicAddFuncionCommand;
        private ICommand _FicEditFuncionCommand;
        private ICommand _FicDetalleFuncionCommand;
        private ICommand _FicDeleteFuncionCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvFunciones IFicSrvFunciones;

        public FicVmFuncionesList(IFicSrvNavigation IFicSrvNavigation, IFicSrvFunciones IFicSrvFunciones)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvFunciones = IFicSrvFunciones;

            _FicDataGrid_SourceFunciones = new ObservableCollection<Eva_actividades_funciones>();
        }

        public ObservableCollection<Eva_actividades_funciones> SourceFunciones
        {
            get
            {
                return _FicDataGrid_SourceFunciones;
            }

            set
            {
                if (_FicDataGrid_SourceFunciones != value)
                {
                    _FicDataGrid_SourceFunciones = value;
                    RaisePropertyChanged("_FicDataGrid_SourceFunciones");
                }
            }
        }//Fin SourceIdiomas

        public Eva_actividades_funciones SelectedFuncion
        {
            get
            {
                return _FicDataGrid_SelectedFuncion;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedFuncion = value;
                    RaisePropertyChanged("SelectedFuncion");
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddFuncionICommand
        {
            get
            {
                return _FicAddFuncionCommand = _FicAddFuncionCommand ??
                    new FicVmDelegateCommand(FicMetAddFuncion);
            }
        }

        public ICommand FicMetEditFuncionICommand
        {
            get
            {
                return _FicEditFuncionCommand = _FicEditFuncionCommand ??
                    new FicVmDelegateCommand(FicMetEditFuncion);
            }
        }

        public ICommand FicMetDetalleFuncionICommand
        {
            get
            {
                return _FicDetalleFuncionCommand = _FicDetalleFuncionCommand ??
                    new FicVmDelegateCommand(FicMetDetalleFuncion);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteFuncionCommand = _FicDeleteFuncionCommand ??
                    new FicVmDelegateCommand(FicMetDeleteFuncion);
            }
        }

        private async void FicMetDeleteFuncion()
        {
            try
            {
                if (_FicDataGrid_SelectedFuncion != null)
                {
                    await IFicSrvFunciones.FicMetDeleteFuncion(_FicDataGrid_SelectedFuncion);
                    _FicDataGrid_SelectedFuncion = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Fin delete

        public void FicMetAddFuncion()
        {
            IFicSrvNavigation.FicMetNavigateTo<FicVmFuncionesItem>
                (new Eva_actividades_funciones());
        }//Fin add

        private async void FicMetEditFuncion()
        {
            if (_FicDataGrid_SelectedFuncion != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmFuncionesItem>
                    (_FicDataGrid_SelectedFuncion);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleFuncion()
        {
            if (_FicDataGrid_SelectedFuncion != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmFuncionesDetalle>
                    (_FicDataGrid_SelectedFuncion);
            }
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para ver los detalles primero seleccione un registro", "OK");
        }


        public async override void OnAppearing(object context)
        {
            try
            {
                SourceFunciones.Clear();

                var source_local_inv = await IFicSrvFunciones.FicMetGetListFunciones();

                if (source_local_inv != null)
                {
                    foreach (Eva_actividades_funciones funciones in source_local_inv)
                    {
                        SourceFunciones.Add(funciones);
                    }
                }//No llena el grid, llena el observableCollection para poder hacer el binding
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW
    }
}
