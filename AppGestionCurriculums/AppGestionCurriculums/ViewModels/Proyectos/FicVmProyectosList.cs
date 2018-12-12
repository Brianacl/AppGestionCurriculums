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

namespace AppGestionCurriculums.ViewModels.Proyectos
{
    public class FicVmProyectosList : FicViewModelBase
    {
        public ObservableCollection<Eva_proyectos> _FicDataGrid_SourceProyectos;
        public Eva_proyectos _FicDataGrid_SelectedProyecto;
        public Eva_experiencia_laboral FicExperiencia;

        private ICommand _FicAddProyectoCommand;
        private ICommand _FicEditProyectoCommand;
        private ICommand _FicDetalleProyectoCommand;
        private ICommand _FicDeleteProyectoCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvProyectos IFicSrvProyectos;

        public FicVmProyectosList(IFicSrvNavigation IFicSrvNavigation, IFicSrvProyectos IFicSrvProyectos)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvProyectos = IFicSrvProyectos;

            _FicDataGrid_SourceProyectos = new ObservableCollection<Eva_proyectos>();
        }

        public ObservableCollection<Eva_proyectos> SourceProyectos
        {
            get
            {
                return _FicDataGrid_SourceProyectos;
            }

            set
            {
                if (_FicDataGrid_SourceProyectos != value)
                {
                    _FicDataGrid_SourceProyectos = value;
                    RaisePropertyChanged();
                }
            }
        }//Fin SourceIdiomas

        public Eva_proyectos SelectedProyecto
        {
            get
            {
                return _FicDataGrid_SelectedProyecto;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedProyecto = value;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public Eva_experiencia_laboral DatosExperiencia
        {
            get
            {
                return FicExperiencia;
            }
            set
            {
                if (value != null)
                {
                    FicExperiencia = value;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddProyectoICommand
        {
            get
            {
                return _FicAddProyectoCommand = _FicAddProyectoCommand ??
                    new FicVmDelegateCommand(FicMetAddProyecto);
            }
        }

        public ICommand FicMetEditProyectoICommand
        {
            get
            {
                return _FicEditProyectoCommand = _FicEditProyectoCommand ??
                    new FicVmDelegateCommand(FicMetEditProyecto);
            }
        }

        public ICommand FicMetDetalleProyectoICommand
        {
            get
            {
                return _FicDetalleProyectoCommand = _FicDetalleProyectoCommand ??
                    new FicVmDelegateCommand(FicMetDetalleProyecto);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteProyectoCommand = _FicDeleteProyectoCommand ??
                    new FicVmDelegateCommand(FicMetDeleteProyecto);
            }
        }

        private async void FicMetDeleteProyecto()
        {
            try
            {
                if (_FicDataGrid_SelectedProyecto != null)
                {
                    await IFicSrvProyectos.FicMetDeleteProyecto(_FicDataGrid_SelectedProyecto);
                    _FicDataGrid_SelectedProyecto = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Fin delete

        public void FicMetAddProyecto()
        {
            var nuevoProyecto = new Eva_proyectos();
            nuevoProyecto.IdExperiencia = DatosExperiencia.IdExperiencia;
            nuevoProyecto.IdCurriculo = DatosExperiencia.IdCurriculo;
            IFicSrvNavigation.FicMetNavigateTo<FicVmProyectosItem>
                (nuevoProyecto);
        }//Fin add

        private async void FicMetEditProyecto()
        {
            if (_FicDataGrid_SelectedProyecto != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmProyectosItem>
                    (_FicDataGrid_SelectedProyecto);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleProyecto()
        {
            if (_FicDataGrid_SelectedProyecto != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmProyectosDetalle>
                    (_FicDataGrid_SelectedProyecto);
            }
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para ver los detalles primero seleccione un registro", "OK");
        }


        public async override void OnAppearing(object context)
        {
            try
            {
                var experiencia = context as Eva_experiencia_laboral;

                if(experiencia != null)
                {
                    System.Diagnostics.Debug.WriteLine("Trae experiencia");
                    DatosExperiencia = experiencia;
                }

                SourceProyectos.Clear();

                var source_local_inv = await IFicSrvProyectos.FicMetGetListProyectos(DatosExperiencia);

                if (source_local_inv != null)
                {
                    foreach (Eva_proyectos proyectos in source_local_inv)
                    {
                        SourceProyectos.Add(proyectos);
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
