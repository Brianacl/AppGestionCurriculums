using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.ViewModels.Curriculos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Personas
{
    public class FicVmPersonasList : FicViewModelBase
    {
        public ObservableCollection<Rh_cat_personas> _FicDataGrid_SourcePersonas;
        public Rh_cat_personas _FicDataGrid_SelectedPersona;
        private ICommand _FicAddPersonaCommand;
        private ICommand _FicEditPersonaCommand;
        private ICommand _FicDetallePersonaCommand;
        private ICommand _FicDeletePersonaCommand;

        private ICommand _FicDetalleCurriculoCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvRhCatPersonas IFicSrvRhCatPersonas;

        public FicVmPersonasList(IFicSrvNavigation IFicSrvNavigation, IFicSrvRhCatPersonas IFicSrvRhCatPersonas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvRhCatPersonas = IFicSrvRhCatPersonas;

            _FicDataGrid_SourcePersonas = new ObservableCollection<Rh_cat_personas>();
        }

        public ObservableCollection<Rh_cat_personas> SourcePersonas
        {
            get
            {
                return _FicDataGrid_SourcePersonas;
            }

            set
            {
                if (_FicDataGrid_SourcePersonas != value)
                {
                    _FicDataGrid_SourcePersonas = value;
                    RaisePropertyChanged();
                }
            }
        }//Fin SourceIdiomas

        public Rh_cat_personas SelectedPersona
        {
            get
            {
                return _FicDataGrid_SelectedPersona;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedPersona = value;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddPersonaICommand
        {
            get
            {
                return _FicAddPersonaCommand = _FicAddPersonaCommand ??
                    new FicVmDelegateCommand(FicMetAddPersona);
            }
        }

        public ICommand FicMetEditPersonaICommand
        {
            get
            {
                return _FicEditPersonaCommand = _FicEditPersonaCommand ??
                    new FicVmDelegateCommand(FicMetEditPersona);
            }
        }

        public ICommand FicMetDetallePersonaICommand
        {
            get
            {
                return _FicDetallePersonaCommand = _FicDetallePersonaCommand ??
                    new FicVmDelegateCommand(FicMetDetallePersona);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeletePersonaCommand = _FicDeletePersonaCommand ??
                    new FicVmDelegateCommand(FicMetDeletePersona);
            }
        }

        public ICommand FicMetDetalleCurriculoICommand
        {
            get
            {
                return _FicDetalleCurriculoCommand = _FicDetalleCurriculoCommand ??
                    new FicVmDelegateCommand(FicMetDetalleCurriculo);
            }
        }

        private async void FicMetDeletePersona()
        {
            try
            {
                if (_FicDataGrid_SelectedPersona != null)
                {
                    await IFicSrvRhCatPersonas.FicMetDeletePersona(_FicDataGrid_SelectedPersona);
                    _FicDataGrid_SelectedPersona = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Fin delete

        public void FicMetAddPersona()
        {
            System.Diagnostics.Debug.WriteLine("Antes de NavigateTo");
            IFicSrvNavigation.FicMetNavigateTo<FicVmPersonasItem>
                (new Rh_cat_personas());
        }//Fin add

        private async void FicMetEditPersona()
        {
            if (_FicDataGrid_SelectedPersona != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmPersonasItem>
                    (_FicDataGrid_SelectedPersona);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleCurriculo()
        {
            if (_FicDataGrid_SelectedPersona != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmCurriculosDetalle>
                    (_FicDataGrid_SelectedPersona);
            else
                await new Page().DisplayAlert("ALERTA - detalle", "Para ver detalle primero seleccione un registro", "OK");
        }

        private async void FicMetDetallePersona()
        {
            if (_FicDataGrid_SelectedPersona != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmPersonasDetalle>
                    (_FicDataGrid_SelectedPersona);
            }
            else
                await new Page().DisplayAlert("ALERTA - detalle", "Para ver los detalles primero seleccione un registro", "OK");
        }


        public async override void OnAppearing(object context)
        {
            try
            {
                SourcePersonas.Clear();

                var source_local_inv = await IFicSrvRhCatPersonas.FicMetGetListPersonas();

                if (source_local_inv != null)
                {
                    foreach (Rh_cat_personas personas in source_local_inv)
                    {
                        SourcePersonas.Add(personas);
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
