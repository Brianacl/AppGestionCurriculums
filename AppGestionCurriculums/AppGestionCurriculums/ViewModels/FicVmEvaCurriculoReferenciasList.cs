using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using Xamarin.Forms;


namespace AppGestionCurriculums.ViewModels
{
    public class FicVmEvaCurriculoReferenciasList : FicViewModelBase
    {
        public ObservableCollection<Eva_curriculo_referencias> _FicDataGrid_SourceReferencias;
        public Eva_curriculo_referencias _FicDataGrid_SelectedReferencia;
        private ICommand _FicAddReferenciaCommand;
        private ICommand _FicEditReferenciaCommand;
        private ICommand _FicDetalleReferenciaCommand;
        private ICommand _FicDeleteReferenciaCommand;

        private IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia;
        private IFicSrvReferencia IFicSrvReferencia;

        public FicVmEvaCurriculoReferenciasList(IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia, IFicSrvReferencia IFicSrvReferencia)
        {
            this.IFicSrvNavigationExperiencia = IFicSrvNavigationExperiencia;
            this.IFicSrvReferencia = IFicSrvReferencia;

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
                if(_FicDataGrid_SourceReferencias != null)
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
                if(value != null)
                {
                    _FicDataGrid_SelectedReferencia = value;
                    RaisePropertyChanged("SelectedReferencia");
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
        public ICommand FicMetDeleteReferenciasICommand
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
                if(_FicDataGrid_SelectedReferencia != null)
                {
                    await IFicSrvReferencia.FicMetDeleteReferencia(_FicDataGrid_SelectedReferencia);
                    _FicDataGrid_SelectedReferencia = null;
                }
                else
                {
                    await new Page().DisplayAlert("alerta", "elegir un registro", "ok");
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }

        public void FicMetAddReferencia()
        {
            IFicSrvNavigationExperiencia.FicMetNavigateTo<FicVmEvaCurriculoReferenciasItem>(new Eva_curriculo_referencias());

        }
        private async void FicMetEditReferencia()
        {
            if(_FicDataGrid_SelectedReferencia != null)
            {
                IFicSrvNavigationExperiencia.FicMetNavigateTo<FicVmEvaCurriculoReferenciasItem>
                    (_FicDataGrid_SelectedReferencia);
                
            }
            else
            {
                await new Page().DisplayAlert("alerta", "seleccione un registro", "ok");
            }
        }
        private async void FicMetDetalleReferencia()
        {
            if(_FicDataGrid_SelectedReferencia != null)
            {
                IFicSrvNavigationExperiencia.FicMetNavigateTo<FicVmEvaCurriculoReferenciasDetalle>(_FicDataGrid_SelectedReferencia);
            }
            else
            {
                await new Page().DisplayAlert("alerta", "seleccione para ver detalles", "ok");
            }
        }

        public async override void OnAppearing(object context)
        {
            try
            {
                SourceReferencias.Clear();

                var source_local_inv = await IFicSrvReferencia.FicMetGetListReferencias();
                if(source_local_inv != null)
                {
                    foreach (Eva_curriculo_referencias referencia in source_local_inv)
                    {
                        SourceReferencias.Add(referencia);
                    }
                }
            }catch(Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }

    }
}
