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

namespace AppGestionCurriculums.ViewModels.Competencias
{
    public class FicVmCompetenciasItem : FicViewModelBase
    {
        private Eva_curriculo_competencias Fic_Eva_curriculo_competencias_item;
        private Eva_cat_tipo_competencias Fic_Eva_cat_tipo_competencias_item;
        public ObservableCollection<string> _FicDataGrid_SourceTiposCompetencias;
        public ObservableCollection<string> _FicDataGrid_SourceCatCompetencias;

        SfComboBox comboBox;
        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCompetencias IFicLoSrvCompetencias;



        public FicVmCompetenciasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCompetencias IFicSrvCompetencias)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCompetencias = IFicSrvCompetencias;
            _FicDataGrid_SourceTiposCompetencias = new ObservableCollection<string>();
            _FicDataGrid_SourceCatCompetencias = new ObservableCollection<string>();
            comboBox =  new SfComboBox();
            comboBox.SelectionChanged += (object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e) =>
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Resolution", "Resolution was changed", "OK");
            };
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
                if (SourceTipoCompetencias != null)
                {
                    SourceTipoCompetencias.Clear();
                }
                var source_local_inv = await IFicLoSrvCompetencias.FicMetGetListTiposCompetencias();//FicMetGetListCurriculumsPersonas();
                if (source_local_inv != null)
                {
                    foreach (string Tcompetencias in source_local_inv)
                    {
                        SourceTipoCompetencias.Add(Tcompetencias);
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
