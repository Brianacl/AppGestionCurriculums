using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using Syncfusion.XForms.ComboBox;
using AppGestionCurriculums.Views.Competencias;
using AppGestionCurriculums.Data;

namespace AppGestionCurriculums.ViewModels.Competencias
{
    public class FicVmCompetenciasItem : FicViewModelBase
    {
        private Eva_curriculo_competencias Fic_Eva_curriculo_competencias_item;
        private string Fic_Eva_nombre_cat_competencias_item;
        private Eva_cat_tipo_competencias Fic_Eva_cat_tipo_competencias_item;
        public ObservableCollection<string> _FicDataGrid_SourceTiposCompetencias;
        public ObservableCollection<string> _FicDataGrid_SourceCatCompetencias;

        
        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCompetencias IFicLoSrvCompetencias;

        private DBContext DbLoContext;
        public Int16 indexSeleccionado;

        public FicVmCompetenciasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCompetencias IFicSrvCompetencias)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCompetencias = IFicSrvCompetencias;
            _FicDataGrid_SourceTiposCompetencias = new ObservableCollection<string>();
            _FicDataGrid_SourceCatCompetencias = new ObservableCollection<string>();
            indexSeleccionado = 0;
            //comboBox =  new SfComboBox();
            // comboBox.SelectionChanged += (object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e) =>
            // {
            //     Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Resolution", "Resolution was changed", "OK");
            // };
        }

        public FicVmCompetenciasItem()
        {
        }

        public Eva_curriculo_competencias NuevaCompetencias
        {
            get { return Fic_Eva_curriculo_competencias_item; }
            set
            {
                Fic_Eva_curriculo_competencias_item = value;
                RaisePropertyChanged();
            }
        }

        public string nombreCatCompetencias
        {
            get { return Fic_Eva_nombre_cat_competencias_item; }
            set
            {
                Fic_Eva_nombre_cat_competencias_item = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> SourceTipoCompetencias
        {
            get
            {
                return _FicDataGrid_SourceTiposCompetencias;
            }
            set
            {
                if (_FicDataGrid_SourceTiposCompetencias != value)
                {
                    _FicDataGrid_SourceTiposCompetencias = value;
                    RaisePropertyChanged("SourceTipoCompetencias");
                }
            }
        }//Fin SourceIdiomas

        public ObservableCollection<string> SourceCatCompetencias
        {
            get
            {
                return _FicDataGrid_SourceCatCompetencias;
            }
            set
            {
                if (_FicDataGrid_SourceCatCompetencias != value)
                {
                    _FicDataGrid_SourceCatCompetencias = value;
                    RaisePropertyChanged("SourceCatCompetencias");
                }
            }
        }//Fin SourceIdiomas

        public async void TraerCatCompetencias(Int16 id)
        {
            if (SourceCatCompetencias != null)
            {
                SourceCatCompetencias.Clear();
            }

                var source_local_inv = await IFicLoSrvCompetencias.FicMetGetListCatCompetenciasID(id);//FicMetGetListCurriculumsPersonas();
                if (source_local_inv != null)
                {
                    foreach (string Ccompetencias in source_local_inv)
                    {
                        SourceCatCompetencias.Add(Ccompetencias);
                    }
                }
            
        }
        public async override void OnAppearing(object navigationContext)
        {
            try
            {
                var FicCompetenciasSeleccionada = navigationContext as Eva_curriculo_competencias;
               
                if (FicCompetenciasSeleccionada != null)
                {
                    System.Diagnostics.Debug.WriteLine("Trae una competencia " + FicCompetenciasSeleccionada.IdCurriculo);
                    NuevaCompetencias = FicCompetenciasSeleccionada;
                }
                    base.OnAppearing(navigationContext);
                    SourceTipoCompetencias.Clear();
                
                var source_local_inv = await IFicLoSrvCompetencias.FicMetGetListTiposCompetencias();//FicMetGetListCurriculumsPersonas();
                if (source_local_inv != null)
                {
                    foreach (string Tcompetencias in source_local_inv)
                    {
                        SourceTipoCompetencias.Add(Tcompetencias);
                    }
                }
                //FicViCompetenciasItem nViCompItem = new FicViCompetenciasItem(navigationContext);
                //TraerCatCompetencias(nViCompItem.indexSeleccionado);
                if (SourceCatCompetencias != null)
                {
                    SourceCatCompetencias.Clear();
                }

                var source_local_inv2 = await IFicLoSrvCompetencias.FicMetGetListCatCompetencias();//FicMetGetListCurriculumsPersonas();
                if (source_local_inv2 != null)
                {
                    foreach (string Ccompetencias in source_local_inv2)
                    {
                        SourceCatCompetencias.Add(Ccompetencias);
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - OnAppearing", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetSaveCommand
        {
            get
            {
                return FicSaveCommand = FicSaveCommand ??
                  new FicVmDelegateCommand(SaveCommandExecute);
            }
        }

        private async void SaveCommandExecute()
        {
            try
            {
                Int16 idSig = Int16.Parse(IFicLoSrvCompetencias.contarCurriculoCompetencia());
                Eva_cat_competencias com = IFicLoSrvCompetencias.FicMetObtenerIdsCompetencias(nombreCatCompetencias).Result;
                NuevaCompetencias.IdCompetenciaCurriculum = idSig;
                NuevaCompetencias.IdCompetencia = com.IdCompetencia;
                await IFicLoSrvCompetencias.FicMetInsertCompetencias(NuevaCompetencias);
                IFicLoSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SaveCommand", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        private void CancelCommandExecute()
        {
            IFicLoSrvNavigation.FicMetNavigateBack();
        }

    }
}
