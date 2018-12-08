using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
using AppGestionCurriculums.Interfaces.Navigation;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.Interfaces.Competencias;

namespace AppGestionCurriculums.ViewModels.CurriculumsPersonas
{
    public class FicVmCurriculumsPersonasList : FicVmBase
    {
        
        public ObservableCollection<Rh_cat_personas> _FicDataGrid_SourceCurriculumsPersonas;
        public ObservableCollection<Rh_cat_personas> _FicDataGrid_SourcePersonas;
        public Rh_cat_personas _FicDataGrid_SelectedCurriculumsPersonas;
        public Rh_cat_personas _FicDataGrid_SelectedPersonas;
        private ICommand _FicDetalleCurriculumsPersonasCommand;
        private ICommand _FicAsignarCurriculumsPersonasCommand;
        private ICommand _FicListCompetenciasCommand;
        private ICommand _FicDomicilioPersonasCommand;
        private Int16 IdDetallePersona;
        private IFicSrvNavigation IFicSrvLoNavigation;
        private IFicSrvCurriculumsPersonas IFicSrvLoCurriculumsPersonas;
        private IFicSrvCompetencias IFicLoSrvCompetencias;
        public FicVmCurriculumsPersonasList(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculumsPersonas IFicSrvCurriculumsPersonas)
        {
            IFicSrvLoNavigation = IFicSrvNavigation;
            IFicSrvLoCurriculumsPersonas = IFicSrvCurriculumsPersonas;

            _FicDataGrid_SourceCurriculumsPersonas = new ObservableCollection<Rh_cat_personas>();
            _FicDataGrid_SourcePersonas = new ObservableCollection<Rh_cat_personas>();
            IdDetallePersona = 0;
        }
        public ObservableCollection<Rh_cat_personas> SourceCurriculumsPersonas
        {
            get
            {
                return _FicDataGrid_SourceCurriculumsPersonas;
            }
            set
            {
                if (_FicDataGrid_SourceCurriculumsPersonas != value)
                {
                    _FicDataGrid_SourceCurriculumsPersonas = value;
                    RaisePropertyChanged("SourceCurriculumsPersonas");
                }
            }
        }//Fin SourceCurriculoPersonas
        /*
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
                    RaisePropertyChanged("SourcePersonas");
                }
            }
        }//Fin SourceCurriculoPersonas
        */
        public Rh_cat_personas SelectedCurriculumsPersonas
        {
            get
            {              
                return _FicDataGrid_SelectedCurriculumsPersonas;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedCurriculumsPersonas = value;
                    IdDetallePersona = _FicDataGrid_SelectedCurriculumsPersonas.IdPersona;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem
        /// <summary>
        /// DOMICILIO PERSONA
        /// </summary>
        

        public ICommand FicMetDetalleCurriculumsPersonasICommand
        {
            get
            {
                return _FicDetalleCurriculumsPersonasCommand = _FicDetalleCurriculumsPersonasCommand ??
                    new FicVmDelegateCommand(FicMetDetalleCurriculumsPersonas);
            }
        }

        private async void FicMetDetalleCurriculumsPersonas()
        {
            if (_FicDataGrid_SelectedCurriculumsPersonas != null)
            {
                IFicSrvLoNavigation.FicMetNavigateTo<FicVmCurriculumsPersonasDetalle>
                    (_FicDataGrid_SelectedCurriculumsPersonas);
            }
            else
                await new Page().DisplayAlert("ALERTA - detalle", "Para ver los detalles primero seleccione un registro", "OK");
        }

        public ICommand FicMetAsignarCurriculumsPersonasICommand
        {
            get
            {
                return _FicAsignarCurriculumsPersonasCommand = _FicAsignarCurriculumsPersonasCommand ??
                    new FicVmDelegateCommand(FicMetAsignarCurriculumsPersonas);
            }
        }

        private async void FicMetAsignarCurriculumsPersonas()
        {
            if (_FicDataGrid_SelectedCurriculumsPersonas != null)
            {
                IFicSrvLoNavigation.FicMetNavigateTo<FicVmCurriculumsPersonasItem>
                    (_FicDataGrid_SelectedCurriculumsPersonas);
            }
            else
                await new Page().DisplayAlert("ALERTA - asignar", "Para asignar un curriculo primero seleccione un registro", "OK");
        }

        public ICommand FicListCompetenciasICommand
        {
            get
            {
                return _FicListCompetenciasCommand = _FicListCompetenciasCommand ??
                    new FicVmDelegateCommand(FicMetListCompetencias);
            }
        }

        private async void FicMetListCompetencias()
        {
            if (_FicDataGrid_SelectedCurriculumsPersonas != null)
            {
                //Rh_cat_personas persona = new Rh_cat_personas();
               // persona = _FicDataGrid_SelectedCurriculumsPersonas;
                //IEnumerable<Eva_curriculo_competencias> dom = IFicLoSrvCompetencias.FicMetGetListCompetencias(_FicDataGrid_SelectedCurriculumsPersonas).Result;
                IFicSrvLoNavigation.FicMetNavigateTo<FicVmCompetenciasList>
                    (_FicDataGrid_SelectedCurriculumsPersonas);
            }
            else
                await new Page().DisplayAlert("ALERTA - competencias", "Para ir a competencias primero seleccione un registro", "OK");
        }
       
        public async override void OnAppearing(object navigationContext)
        {
            try
            {
                SourceCurriculumsPersonas.Clear();
                var source_local_inv = await IFicSrvLoCurriculumsPersonas.FicMetGetListCurriculumsPersonas();
                if (source_local_inv != null)
                {
                    foreach (Rh_cat_personas curriculo in source_local_inv)
                    {
                        SourceCurriculumsPersonas.Add(curriculo);
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
