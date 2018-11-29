using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Interfaces;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas
{
    public class FicVmEvaCurriculoIdiomasList : FicViewModelBase
    {
        public ObservableCollection<Eva_curriculo_idiomas> _FicDataGrid_SourceIdiomas;
        public Eva_curriculo_idiomas _FicDataGrid_SelectedIdioma;
        private ICommand _FicAddIdiomaCommand;
        private ICommand _FicEditIdiomaCommand;
        private ICommand _FicDetalleIdiomaCommand;
        private ICommand _FicDeleteIdiomaCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoIdiomas IFicSrvCurriculoIdiomas;

        public FicVmEvaCurriculoIdiomasList(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoIdiomas IFicSrvCurriculoIdiomas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoIdiomas = IFicSrvCurriculoIdiomas;

            _FicDataGrid_SourceIdiomas = new ObservableCollection<Eva_curriculo_idiomas>();
        }

        public ObservableCollection<Eva_curriculo_idiomas> SourceIdiomas
        {
            get
            {
                return _FicDataGrid_SourceIdiomas;
            }

            set
            {
                if (_FicDataGrid_SourceIdiomas != value)
                {
                    _FicDataGrid_SourceIdiomas = value;
                    RaisePropertyChanged("SourceIdiomas");
                }
            }
        }//Fin SourceIdiomas

        public Eva_curriculo_idiomas SelectedIdioma
        {
            get
            {
                return _FicDataGrid_SelectedIdioma;
            }
            set
            {
                if (value != null)
                {
                    _FicDataGrid_SelectedIdioma = value;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }//Fin de SelectedItem

        public ICommand FicMetAddIdiomaICommand
        {
            get
            {
                return _FicAddIdiomaCommand = _FicAddIdiomaCommand ??
                    new FicVmDelegateCommand(FicMetAddIdioma);
            }
        }

        public ICommand FicMetEditIdiomaICommand
        {
            get
            {
                return _FicEditIdiomaCommand = _FicEditIdiomaCommand ??
                    new FicVmDelegateCommand(FicMetEditIdioma);
            }
        }

        public ICommand FicMetDetalleIdiomaICommand
        {
            get
            {
                return _FicDetalleIdiomaCommand = _FicDetalleIdiomaCommand ??
                    new FicVmDelegateCommand(FicMetDetalleIdioma);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicDeleteIdiomaCommand = _FicDeleteIdiomaCommand ??
                    new FicVmDelegateCommand(FicMetDeleteIdioma);
            }
        }

        private async void FicMetDeleteIdioma()
        {
            try
            {
                if (_FicDataGrid_SelectedIdioma != null)
                {
                    await IFicSrvCurriculoIdiomas.FicMetDeleteIdioma(_FicDataGrid_SelectedIdioma);
                    _FicDataGrid_SelectedIdioma = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public void FicMetAddIdioma()
        {
            IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoIdiomasItem>
                (new Eva_curriculo_idiomas());
        }

        private async void FicMetEditIdioma()
        {
            if (_FicDataGrid_SelectedIdioma != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoIdiomasItem>
                    (_FicDataGrid_SelectedIdioma);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar,  primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleIdioma()
        {
            if (_FicDataGrid_SelectedIdioma != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoIdiomasDetalle>
                    (_FicDataGrid_SelectedIdioma);
            }
             else
                await new Page().DisplayAlert("ALERTA - editar", "Para ver los detalles,  primero seleccione un registro", "OK");
        }



        public async override void OnAppearing(object context)
        {
            try
            {
                SourceIdiomas.Clear();

                var source_local_inv = await IFicSrvCurriculoIdiomas.FicMetGetListIdiomas();

                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_idiomas idioma in source_local_inv)
                    {
                        SourceIdiomas.Add(idioma);
                    }
                }//No llena el grid, llena el observableCollection para poder hacer el binding
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW
    }//Fin clase
}
