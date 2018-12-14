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

namespace AppGestionCurriculums.ViewModels.Referencias
{
    public class FicVmReferenciasList : FicViewModelBase
    {
        public ObservableCollection<Eva_curriculo_referencias> _FicDataGrid_SourceReferencias;
        public Eva_curriculo_referencias _FicDataGrid_SelectedReferencia;
        public Eva_curriculo_persona FicCurriculo;

        private ICommand _FicAddReferenciaCommand;
        private ICommand _FicEditReferenciaCommand;
        private ICommand _FicDetalleReferenciaCommand;
        private ICommand _FicDeleteReferenciaCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvReferencias IFicSrvReferencias;

        public FicVmReferenciasList(IFicSrvNavigation IFicSrvNavigation, IFicSrvReferencias IFicSrvReferencias)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvReferencias = IFicSrvReferencias;

            _FicDataGrid_SourceReferencias = new ObservableCollection<Eva_curriculo_referencias>();
        }

        public ObservableCollection<Eva_curriculo_referencias> SourceReferencias
        {
            get
            {
                return _FicDataGrid_SourceReferencias;
            }
            set
            {
                if (_FicDataGrid_SourceReferencias != null)
                {
                    _FicDataGrid_SourceReferencias = value;
                    RaisePropertyChanged("SourceReferencias");
                }
            }


        }


        public Eva_curriculo_referencias SelectedReferencia
        {
            get
            {
                return _FicDataGrid_SelectedReferencia;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedReferencia = value;
                    RaisePropertyChanged("SelectedReferencia");
                }
            }
        }

        public Eva_curriculo_persona DatosCurriculo
        {
            get
            {
                return FicCurriculo;
            }
            set
            {
                if (value != null)
                {
                    FicCurriculo = value;
                    RaisePropertyChanged("DatosCurriculo");
                }
            }
        }

        public ICommand FicMetAddReferenciaICommand
        {
            get
            {
                return _FicAddReferenciaCommand = _FicAddReferenciaCommand ??
                    new FicVmDelegateCommand(FicMetAddReferencia);
            }
        }
        public ICommand FicMetEditReferenciaICommand
        {
            get
            {
                return _FicEditReferenciaCommand = _FicEditReferenciaCommand ??
                    new FicVmDelegateCommand(FicMetEditReferencia);
            }
        }

        public ICommand FicMetDetalleReferenciaICommand
        {
            get
            {
                return _FicDetalleReferenciaCommand = _FicDetalleReferenciaCommand ??
                    new FicVmDelegateCommand(FicMetDetalleReferencia);
            }
        }
        public ICommand FicMetDeleteReferenciaICommand
        {
            get
            {
                return _FicDeleteReferenciaCommand = _FicDeleteReferenciaCommand ??
                    new FicVmDelegateCommand(FicMetDeleteReferencia);
            }
        }

        private async void FicMetDeleteReferencia()
        {
            try
            {
                if (_FicDataGrid_SelectedReferencia != null)
                {
                    await IFicSrvReferencias.FicMetDeleteReferencia(_FicDataGrid_SelectedReferencia);
                    _FicDataGrid_SelectedReferencia = null;
                }
                else
                {
                    await new Page().DisplayAlert("alerta", "Elija un registro", "ok");
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }

        public void FicMetAddReferencia()
        {
            var nuevaReferencia = new Eva_curriculo_referencias();
            nuevaReferencia.IdCurriculo = DatosCurriculo.IdCurriculo;
            IFicSrvNavigation.FicMetNavigateTo<FicVmReferenciasItem>
                (nuevaReferencia);

        }
        private async void FicMetEditReferencia()
        {
            if (_FicDataGrid_SelectedReferencia != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmReferenciasItem>
                    (_FicDataGrid_SelectedReferencia);

            }
            else
            {
                await new Page().DisplayAlert("ALERTA", "Seleccione un registro", "ok");
            }
        }
        private async void FicMetDetalleReferencia()
        {
            if (_FicDataGrid_SelectedReferencia != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmReferenciasDetalle>(_FicDataGrid_SelectedReferencia);
            }
            else
            {
                await new Page().DisplayAlert("ALERTA", "Seleccione para ver detalles", "ok");
            }
        }

        public async override void OnAppearing(object context)
        {
            try
            {
                var curriculo = context as Eva_curriculo_persona;

                if(curriculo != null)
                {
                    DatosCurriculo = curriculo;
                }

                SourceReferencias.Clear();

                var source_local_inv = await IFicSrvReferencias.FicMetGetListReferencias(DatosCurriculo);
                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_referencias referencia in source_local_inv)
                    {
                        SourceReferencias.Add(referencia);
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "ok");
            }
        }

    }
}
