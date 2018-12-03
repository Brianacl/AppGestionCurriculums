using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.Navigation;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace AppGestionCurriculums.ViewModels.Competencias
{
    public class FicVmCompetenciasList: FicVmBase
    {

        public ObservableCollection<Eva_curriculo_competencias> _FicDataGrid_SourceCompetencias;
        public Eva_curriculo_competencias _FicDataGrid_SelectedCompetencias;
        private ICommand _FicAddCompetenciasCommand;
        private ICommand _FicEditCompetenciasCommand;
        private ICommand _FicDetailCompetenciasCommand;
        private ICommand _FicDeleteCompetenciasCommand;
        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCompetencias IFicLoSrvCompetencias;
        public FicVmCompetenciasList(IFicSrvNavigation IFicSrvNavigation, IFicSrvCompetencias IFicSrvCompetencias)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCompetencias = IFicSrvCompetencias;
            _FicDataGrid_SourceCompetencias = new ObservableCollection<Eva_curriculo_competencias>();
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
                    RaisePropertyChanged("_FicDataGrid_SourceCompetencias");
                }
            }
        }//Fin SourceIdiomas
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
        private async void FicMetDeleteCompetencias()
        {
            try
            {
                if (_FicDataGrid_SelectedCompetencias != null)
                {
                    await IFicLoSrvCompetencias.FicMetDeleteCompetencia(_FicDataGrid_SelectedCompetencias);
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
            IFicLoSrvNavigation.FicMetNavigateTo<FicVmCompetenciasItem>
                (new Eva_curriculo_competencias());
        }//Fin add
        private async void FicMetEditCompetencias()
        {
            if (_FicDataGrid_SelectedCompetencias != null)
                IFicLoSrvNavigation.FicMetNavigateTo<FicVmCompetenciasItem>
                    (_FicDataGrid_SelectedCompetencias);
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
        public async override void OnAppearing(object context)
        {
            try
            {
                SourceCompetencias.Clear();
                var source_local_inv = await IFicLoSrvCompetencias.FicMetGetListCompetencias();
                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_competencias competencias in source_local_inv)
                    {
                        SourceCompetencias.Add(competencias);
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
