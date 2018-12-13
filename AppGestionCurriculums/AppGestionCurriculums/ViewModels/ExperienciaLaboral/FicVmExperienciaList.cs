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

namespace AppGestionCurriculums.ViewModels.ExperienciaLaboral
{
    public class FicVmExperienciaList : FicViewModelBase
    {
        public ObservableCollection<Eva_experiencia_laboral> _FicDataGrid_SourceExperiencia;
        public Eva_experiencia_laboral _FicDataGrid_SelectedExperiencia;
        public Eva_curriculo_persona _FicCurriculo;

        private ICommand _FicAddExperienciaCommand;
        private ICommand _FicEditExperienciaCommand;
        private ICommand _FicDetalleExperienciaCommand;
        private ICommand _FicDeleteExperienciaCommand;

        private ICommand _FicProyectosCommand;
        private ICommand _FicFuncionesCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvExperienciaLaboral IFicSrvExperienciaLaboral;

        public FicVmExperienciaList(IFicSrvNavigation IFicSrvNavigation, IFicSrvExperienciaLaboral IFicSrvExperienciaLaboral)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvExperienciaLaboral = IFicSrvExperienciaLaboral;

            _FicDataGrid_SourceExperiencia = new ObservableCollection<Eva_experiencia_laboral>();
        }

        public ObservableCollection<Eva_experiencia_laboral> SourceExperiencia
        {
            get
            {
                return _FicDataGrid_SourceExperiencia;
            }

            set
            {
                if (_FicDataGrid_SourceExperiencia != value)
                {
                    _FicDataGrid_SourceExperiencia = value;
                    RaisePropertyChanged("SourceExperiencia");
                }
            }
        }//Fin SourceIdiomas

        public Eva_experiencia_laboral SelectedExperiencia
        {
            get
            {
                return _FicDataGrid_SelectedExperiencia;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedExperiencia = value;
                    RaisePropertyChanged("SelectedExperiencia");
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

        public ICommand FicMetAddExperienciaICommand
        {
            get
            {
                return _FicAddExperienciaCommand = _FicAddExperienciaCommand ??
                    new FicVmDelegateCommand(FicMetAddExperiencia);
            }
        }

        public ICommand FicMetEditExperienciaICommand
        {
            get
            {
                return _FicEditExperienciaCommand = _FicEditExperienciaCommand ??
                    new FicVmDelegateCommand(FicMetEditExperiencia);
            }
        }

        public ICommand FicMetDetalleExperienciaICommand
        {
            get
            {
                return _FicDetalleExperienciaCommand = _FicDetalleExperienciaCommand ??
                    new FicVmDelegateCommand(FicMetDetalleExperiencia);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteExperienciaCommand = _FicDeleteExperienciaCommand ??
                    new FicVmDelegateCommand(FicMetDeleteExperiencia);
            }
        }

        public ICommand FicMetProyectosCommand
        {
            get
            {
                return _FicProyectosCommand = _FicProyectosCommand ??
                    new FicVmDelegateCommand(FicMetProyectos);
            }
        }

        public ICommand FicMetFuncionesCommand
        {
            get
            {
                return _FicFuncionesCommand = _FicFuncionesCommand ??
                    new FicVmDelegateCommand(FicMetFunciones);
            }
        }

        private async void FicMetProyectos()
        {
            if (_FicDataGrid_SelectedExperiencia != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmProyectosList>
                    (_FicDataGrid_SelectedExperiencia);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para ir a proyectos primero seleccione un registro", "OK");
        }

        private async void FicMetFunciones()
        {
            if (_FicDataGrid_SelectedExperiencia != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmFuncionesList>
                    (_FicDataGrid_SelectedExperiencia);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para ir a funciones primero seleccione un registro", "OK");
        }

        private async void FicMetDeleteExperiencia()
        {
            try
            {
                if (_FicDataGrid_SelectedExperiencia != null)
                {
                    await IFicSrvExperienciaLaboral.FicMetDeleteExperiencia(_FicDataGrid_SelectedExperiencia);
                    _FicDataGrid_SelectedExperiencia = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Fin delete

        public void FicMetAddExperiencia()
        {
            var nuevaExperiencia = new Eva_experiencia_laboral();
            nuevaExperiencia.IdCurriculo = DatosCurriculo.IdCurriculo;
            IFicSrvNavigation.FicMetNavigateTo<FicVmExperienciaItem>
                (nuevaExperiencia);
        }//Fin add

        private async void FicMetEditExperiencia()
        {
            if (_FicDataGrid_SelectedExperiencia != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmExperienciaItem>
                    (_FicDataGrid_SelectedExperiencia);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleExperiencia()
        {
            if (_FicDataGrid_SelectedExperiencia != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmExperienciaDetalle>
                    (_FicDataGrid_SelectedExperiencia);
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

                SourceExperiencia.Clear();

                var source_local_inv = await IFicSrvExperienciaLaboral.FicMetGetListExperiencias(DatosCurriculo);

                if (source_local_inv != null)
                {
                    foreach (Eva_experiencia_laboral experiencia in source_local_inv)
                    {
                        SourceExperiencia.Add(experiencia);
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
