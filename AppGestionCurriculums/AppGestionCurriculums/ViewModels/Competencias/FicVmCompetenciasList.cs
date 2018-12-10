using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.Services.CurriculumsPersonas;
using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.CurriculumsPersonas;
using AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace AppGestionCurriculums.ViewModels.Competencias
{
    public class FicVmCompetenciasList: FicViewModelBase
    {

        public ObservableCollection<Eva_curriculo_competencias> _FicDataGrid_SourceCompetencias;
        public int IdPersona;
        private Eva_curriculo_persona Fic_curriculo;
        public Eva_curriculo_competencias _FicDataGrid_SelectedCompetencias;

        private ICommand _FicAddCompetenciasCommand;
        private ICommand _FicEditCompetenciasCommand;
        private ICommand _FicDetailCompetenciasCommand;
        private ICommand _FicDeleteCompetenciasCommand;
        private ICommand _FicConocimientosCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCompetencias IFicLoSrvCompetencias;

        public FicVmCompetenciasList(IFicSrvNavigation IFicSrvNavigation, IFicSrvCompetencias IFicSrvCompetencias)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCompetencias = IFicSrvCompetencias;
            _FicDataGrid_SourceCompetencias = new ObservableCollection<Eva_curriculo_competencias>();
            //IdPersona = vmPersonas.IdSeleccionadoPersona;
        }
        public ObservableCollection<Eva_curriculo_competencias> SourceCompetencias
        {
            get
            {
                return _FicDataGrid_SourceCompetencias;
            }
            set
            {
                if (_FicDataGrid_SourceCompetencias != value)
                {
                    _FicDataGrid_SourceCompetencias = value;
                    RaisePropertyChanged("SourceCompetencias");
                }
            }
        }//Fin SourceIdiomas

        public Eva_curriculo_persona DatosCurriculo
        {
            get { return Fic_curriculo; }
            set
            {
                Fic_curriculo = value;
                RaisePropertyChanged();
            }
        }
        public Eva_curriculo_competencias SelectedCompetencias
        {
            get
            {
                return _FicDataGrid_SelectedCompetencias;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedCompetencias = value;
                    RaisePropertyChanged("SelectedCompetencias");
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem
        public ICommand FicMetAddCompetenciasICommand
        {
            get
            {
                return _FicAddCompetenciasCommand = _FicAddCompetenciasCommand ??
                    new FicVmDelegateCommand(FicMetAddCompetencias);
            }
        }
        public ICommand FicMetEditCompetenciasICommand
        {
            get
            {
                return _FicEditCompetenciasCommand = _FicEditCompetenciasCommand ??
                    new FicVmDelegateCommand(FicMetEditCompetencias);
            }
        }
        //FicMetDetalleCompetenciasICommand
        public ICommand FicMetDetailCompetenciasICommand
        {
            get
            {
                return _FicDetailCompetenciasCommand = _FicDetailCompetenciasCommand ??
                    new FicVmDelegateCommand(FicMetDetalleCompetencias);
            }
        }
        public ICommand FicMetDeleteCompetenciasICommand
        {
            get
            {
                return _FicDeleteCompetenciasCommand = _FicDeleteCompetenciasCommand ??
                    new FicVmDelegateCommand(FicMetDeleteCompetencias);
            }
        }


        public ICommand FicMetConocimientosICommand
        {
            get
            {
                return _FicConocimientosCommand = _FicConocimientosCommand ??
                    new FicVmDelegateCommand(FicMetConocimientos);
            }
        }

        private async void FicMetConocimientos()
        {
            if (_FicDataGrid_SelectedCompetencias != null)
            {
                IFicLoSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoConocimientosList>
                    (_FicDataGrid_SelectedCompetencias);
            }
            else
                await new Page().DisplayAlert("ALERTA", "Para ir a conocimientos seleccione un registro", "OK");
        }

        private async void FicMetDeleteCompetencias()
        {
            try
            {
                if (_FicDataGrid_SelectedCompetencias != null)
                {
                    await IFicLoSrvCompetencias.FicMetDeleteCompetencias(_FicDataGrid_SelectedCompetencias);
                    _FicDataGrid_SelectedCompetencias = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Fin delete
        public void FicMetAddCompetencias()
        {
            var nuevaCompetencia = new Eva_curriculo_competencias();
            nuevaCompetencia.IdCurriculo = DatosCurriculo.IdCurriculo;

            IFicLoSrvNavigation.FicMetNavigateTo<FicVmCompetenciasItem>
                (nuevaCompetencia);
        }//Fin add

        private async void FicMetEditCompetencias()
        {
            if (_FicDataGrid_SelectedCompetencias != null)
            {
                IFicLoSrvNavigation.FicMetNavigateTo<FicVmCompetenciasItem>
                    (_FicDataGrid_SelectedCompetencias);
            }
            else
                await new Page().DisplayAlert("ALERTA", "Para editar primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleCompetencias()
        {
            if (_FicDataGrid_SelectedCompetencias != null)
            {
                IFicLoSrvNavigation.FicMetNavigateTo<FicVmCompetenciasDetalle>
                    (_FicDataGrid_SelectedCompetencias);
            }
            else
                await new Page().DisplayAlert("ALERTA", "Para ver los detalles primero seleccione un registro", "OK");
        }
        public async override void OnAppearing(object navigationContext)
        {
            try
            {
                var FicCurriculoSeleccionado = navigationContext as Eva_curriculo_persona;

                if (FicCurriculoSeleccionado != null)
                {
                    DatosCurriculo = FicCurriculoSeleccionado;
                    System.Diagnostics.Debug.WriteLine("Trae un curriculo " + DatosCurriculo.IdCurriculo);
                }
                    base.OnAppearing(navigationContext);
                
                SourceCompetencias.Clear();
                var source_local_inv = await IFicLoSrvCompetencias.FicMetGetListCompetencias(DatosCurriculo);//FicMetGetListCurriculumsPersonas();
                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_competencias competencias in source_local_inv)
                    {
                        SourceCompetencias.Add(competencias);
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW
    }
}
