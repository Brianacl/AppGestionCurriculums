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

namespace AppGestionCurriculums.ViewModels.GradoEstudios
{
    public class FicVmGradoEstudiosList : FicViewModelBase
    {
        public ObservableCollection<Eva_carrera_grado_estudios> _FicDataGrid_SourceGradoEstudios;
        public Eva_carrera_grado_estudios _FicDataGrid_SelectedGradoEstudio;
        private ICommand _FicAddGradoEstudioCommand;
        private ICommand _FicEditGradoEstudioCommand;
        private ICommand _FicDetalleGradoEstudioCommand;
        private ICommand _FicDeleteGradoEstudioCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvGradoEstudios IFicSrvGradoEstudios;

        public FicVmGradoEstudiosList(IFicSrvNavigation IFicSrvNavigation, IFicSrvGradoEstudios IFicSrvGradoEstudios)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvGradoEstudios = IFicSrvGradoEstudios;

            _FicDataGrid_SourceGradoEstudios = new ObservableCollection<Eva_carrera_grado_estudios>();
        }

        public ObservableCollection<Eva_carrera_grado_estudios> SourceGradoEstudios
        {
            get
            {
                return _FicDataGrid_SourceGradoEstudios;
            }

            set
            {
                if (_FicDataGrid_SourceGradoEstudios != value)
                {
                    _FicDataGrid_SourceGradoEstudios = value;
                    RaisePropertyChanged("SourceGradoEstudios");
                }
            }
        }//Fin SourceIdiomas

        public Eva_carrera_grado_estudios SelectedGradoEstudio
        {
            get
            {
                return _FicDataGrid_SelectedGradoEstudio;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedGradoEstudio = value;
                    RaisePropertyChanged("SelectedGradoEstudio");
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddGradoEstudiosICommand
        {
            get
            {
                return _FicAddGradoEstudioCommand = _FicAddGradoEstudioCommand ??
                    new FicVmDelegateCommand(FicMetAddGradoEstudio);
            }
        }

        public ICommand FicMetEditGradoEstudioICommand
        {
            get
            {
                return _FicEditGradoEstudioCommand = _FicEditGradoEstudioCommand ??
                    new FicVmDelegateCommand(FicMetEditGradoEstudio);
            }
        }

        public ICommand FicMetDetalleGradoEstudioICommand
        {
            get
            {
                return _FicDetalleGradoEstudioCommand = _FicDetalleGradoEstudioCommand ??
                    new FicVmDelegateCommand(FicMetDetalleGradoEstudio);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteGradoEstudioCommand = _FicDeleteGradoEstudioCommand ??
                    new FicVmDelegateCommand(FicMetDeleteGradoEstudio);
            }
        }

        private async void FicMetDeleteGradoEstudio()
        {
            try
            {
                if (_FicDataGrid_SelectedGradoEstudio != null)
                {
                    await IFicSrvGradoEstudios.FicMetDeleteGradoEstudios(_FicDataGrid_SelectedGradoEstudio);
                    _FicDataGrid_SelectedGradoEstudio = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Fin delete

        public void FicMetAddGradoEstudio()
        {
            IFicSrvNavigation.FicMetNavigateTo<FicVmGradoEstudiosItem>
                (new Eva_carrera_grado_estudios());
        }//Fin add

        private async void FicMetEditGradoEstudio()
        {
            if (_FicDataGrid_SelectedGradoEstudio != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmGradoEstudiosItem>
                    (_FicDataGrid_SelectedGradoEstudio);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleGradoEstudio()
        {
            if (_FicDataGrid_SelectedGradoEstudio != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmGradoEstudiosDetalle>
                    (_FicDataGrid_SelectedGradoEstudio);
            }
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para ver los detalles primero seleccione un registro", "OK");
        }


        public async override void OnAppearing(object context)
        {
            try
            {
                SourceGradoEstudios.Clear();

                var source_local_inv = await IFicSrvGradoEstudios.FicMetGetListGradoEstudios();

                if (source_local_inv != null)
                {
                    foreach (Eva_carrera_grado_estudios gradoEstudios in source_local_inv)
                    {
                        SourceGradoEstudios.Add(gradoEstudios);
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
