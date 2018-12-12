using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.ViewModels.Funciones;
using AppGestionCurriculums.ViewModels.Proyectos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.OtrasActividades
{
    public class FicVmOtrasActividadesList : FicViewModelBase
    {
        public ObservableCollection<Eva_curriculo_otras_actividades> _FicDataGrid_SourceOtrasActividades;
        public Eva_curriculo_otras_actividades _FicDataGrid_SelectedOtraActividad;
        public Eva_curriculo_persona _FicCurriculo;

        private ICommand _FicAddOtraActividadCommand;
        private ICommand _FicEditOtraActividadCommand;
        private ICommand _FicDetalleOtraActividadCommand;
        private ICommand _FicDeleteOtraActividadCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvOtrasActividades IFicSrvOtrasActividades;

        public FicVmOtrasActividadesList(IFicSrvNavigation IFicSrvNavigation, IFicSrvOtrasActividades IFicSrvOtrasActividades)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvOtrasActividades = IFicSrvOtrasActividades;

            _FicDataGrid_SourceOtrasActividades = new ObservableCollection<Eva_curriculo_otras_actividades>();
        }

        public ObservableCollection<Eva_curriculo_otras_actividades> SourceOtrasActividades
        {
            get
            {
                return _FicDataGrid_SourceOtrasActividades;
            }

            set
            {
                if (_FicDataGrid_SourceOtrasActividades != value)
                {
                    _FicDataGrid_SourceOtrasActividades = value;
                    RaisePropertyChanged("SourceExperiencia");
                }
            }
        }//Fin SourceIdiomas

        public Eva_curriculo_otras_actividades SelectedOtraActividad
        {
            get
            {
                return _FicDataGrid_SelectedOtraActividad;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedOtraActividad = value;
                    RaisePropertyChanged("SelectedOtraActividad");
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public Eva_curriculo_persona DatosCurriculo
        {
            get
            {
                return _FicCurriculo;
            }
            set
            {
                if (value != null)
                {
                    _FicCurriculo = value;
                    RaisePropertyChanged("DatosCurriculo");
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddOtraActividadICommand
        {
            get
            {
                return _FicAddOtraActividadCommand = _FicAddOtraActividadCommand ??
                    new FicVmDelegateCommand(FicMetAddOtraActividad);
            }
        }

        public ICommand FicMetEditOtraActividadICommand
        {
            get
            {
                return _FicEditOtraActividadCommand = _FicEditOtraActividadCommand ??
                    new FicVmDelegateCommand(FicMetEditOtraActividad);
            }
        }

        public ICommand FicMetDetalleOtraActividadICommand
        {
            get
            {
                return _FicDetalleOtraActividadCommand = _FicDetalleOtraActividadCommand ??
                    new FicVmDelegateCommand(FicMetDetalleOtraActividad);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteOtraActividadCommand = _FicDeleteOtraActividadCommand ??
                    new FicVmDelegateCommand(FicMetDeleteOtraActividad);
            }
        }

        private async void FicMetDeleteOtraActividad()
        {
            try
            {
                if (_FicDataGrid_SelectedOtraActividad != null)
                {
                    await IFicSrvOtrasActividades.FicMetDeleteOtraActividad(_FicDataGrid_SelectedOtraActividad);
                    _FicDataGrid_SelectedOtraActividad = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Fin delete

        public void FicMetAddOtraActividad()
        {
            var nuevaOtraActividad = new Eva_curriculo_otras_actividades();
            nuevaOtraActividad.IdCurriculo = DatosCurriculo.IdCurriculo;
            IFicSrvNavigation.FicMetNavigateTo<FicVmOtrasActividadesItem>
                (nuevaOtraActividad);
        }//Fin add

        private async void FicMetEditOtraActividad()
        {
            if (_FicDataGrid_SelectedOtraActividad != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmOtrasActividadesItem>
                    (_FicDataGrid_SelectedOtraActividad);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleOtraActividad()
        {
            if (_FicDataGrid_SelectedOtraActividad != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmOtrasActividadesDetalle>
                    (_FicDataGrid_SelectedOtraActividad);
            }
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para ver los detalles primero seleccione un registro", "OK");
        }


        public async override void OnAppearing(object context)
        {
            try
            {
                var curriculo = context as Eva_curriculo_persona;

                if (curriculo != null)
                {
                    System.Diagnostics.Debug.WriteLine("Trae curriculo.");
                    DatosCurriculo = curriculo;
                }

                SourceOtrasActividades.Clear();

                var source_local_inv = await IFicSrvOtrasActividades.FicMetGetListOtrasActividades(DatosCurriculo);

                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_otras_actividades otraActividad in source_local_inv)
                    {
                        SourceOtrasActividades.Add(otraActividad);
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
