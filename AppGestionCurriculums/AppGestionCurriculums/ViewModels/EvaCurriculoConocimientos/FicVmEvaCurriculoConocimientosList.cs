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

namespace AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos
{
    public class FicVmEvaCurriculoConocimientosList : FicViewModelBase
    {
        public ObservableCollection<Eva_curriculo_conocimientos> _FicDataGrid_SourceConocimientos;
        public Eva_curriculo_conocimientos _FicDataGrid_SelectedConocimiento;
        private ICommand _FicAddConocimientoCommand;
        private ICommand _FicEditConocimientoCommand;
        private ICommand _FicDetalleConocimientoCommand;
        private ICommand _FicDeleteConocimientoCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos;

        public FicVmEvaCurriculoConocimientosList(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoConocimientos = IFicSrvCurriculoConocimientos;

            _FicDataGrid_SourceConocimientos = new ObservableCollection<Eva_curriculo_conocimientos>();
        }

        public ObservableCollection<Eva_curriculo_conocimientos> SourceConocimientos
        {
            get
            {
                return _FicDataGrid_SourceConocimientos;
            }

            set
            {
                if (_FicDataGrid_SourceConocimientos != value)
                {
                    _FicDataGrid_SourceConocimientos = value;
                    RaisePropertyChanged("SourceConocimientos");
                }
            }
        }//Fin SourceConocimientos

        public Eva_curriculo_conocimientos SelectedConocimiento
        {
            get
            {
                return _FicDataGrid_SelectedConocimiento;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedConocimiento = value;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddConocimientoICommand
        {
            get
            {
                return _FicAddConocimientoCommand = _FicAddConocimientoCommand ??
                    new FicVmDelegateCommand(FicMetAddConocimiento);
            }
        }

        public ICommand FicMetEditConocimientoICommand
        {
            get
            {
                return _FicEditConocimientoCommand = _FicEditConocimientoCommand ??
                    new FicVmDelegateCommand(FicMetEditConocimiento);
            }
        }

        public ICommand FicMetDetalleConocimientoICommand
        {
            get
            {
                return _FicDetalleConocimientoCommand = _FicDetalleConocimientoCommand ??
                    new FicVmDelegateCommand(FicMetDetalleConocimiento);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteConocimientoCommand = _FicDeleteConocimientoCommand ??
                    new FicVmDelegateCommand(FicMetDeleteConocimiento);
            }
        }

        private async void FicMetDeleteConocimiento()
        {
            try
            {
                if (_FicDataGrid_SelectedConocimiento != null)
                {
                    await IFicSrvCurriculoConocimientos.FicMetDeleteConocimiento(_FicDataGrid_SelectedConocimiento);
                    _FicDataGrid_SelectedConocimiento = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public void FicMetAddConocimiento()
        {
            IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoConocimientosItem>
                (new Eva_curriculo_conocimientos());
        }

        private async void FicMetEditConocimiento()
        {
            if (_FicDataGrid_SelectedConocimiento != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoConocimientosItem>
                    (_FicDataGrid_SelectedConocimiento);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar,  primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleConocimiento()
        {
            if (_FicDataGrid_SelectedConocimiento != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoConocimientosDetalle>
                    (_FicDataGrid_SelectedConocimiento);
            }
             else
                await new Page().DisplayAlert("ALERTA - editar", "Para ver los detalles,  primero seleccione un registro", "OK");
        }



        public async override void OnAppearing(object context)
        {
            try
            {
                SourceConocimientos.Clear();

                var source_local_inv = await IFicSrvCurriculoConocimientos.FicMetGetListConocimientos();

                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_conocimientos conocimiento in source_local_inv)
                    {
                        SourceConocimientos.Add(conocimiento);
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
