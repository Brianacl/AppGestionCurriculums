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

namespace AppGestionCurriculums.ViewModels.Competencias
{
    public class FicVmCompetenciasItem : FicViewModelBase
    {
        private Eva_curriculo_competencias Fic_Eva_curriculo_competencias_item;
        private string Fic_Eva_nombre_cat_competencias_item;
        public ObservableCollection<string> _FicDataGrid_SourceCatCompetencias;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicLoSrvNavigation;
        private IFicSrvCompetencias IFicLoSrvCompetencias;



        public FicVmCompetenciasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCompetencias IFicSrvCompetencias)
        {
            IFicLoSrvNavigation = IFicSrvNavigation;
            IFicLoSrvCompetencias = IFicSrvCompetencias;

            _FicDataGrid_SourceCatCompetencias = new ObservableCollection<string>();
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

        public string nombreCatCompetencias
        {
            get { return Fic_Eva_nombre_cat_competencias_item; }
            set
            {
                Fic_Eva_nombre_cat_competencias_item = value;
                RaisePropertyChanged();
            }
        }
        public async override void OnAppearing(object navigationContext)
        {
            try
            {
                var listaCatCompetencias = await IFicLoSrvCompetencias.FicMetGetListCatCompetencias();

                if (listaCatCompetencias != null)
                {
                    // System.Diagnostics.Debug.WriteLine("Trae datos");
                    foreach (string catCompetencias in listaCatCompetencias)
                    {
                        // System.Diagnostics.Debug.WriteLine(catCompetencias);
                        SourceCatCompetencias.Add(catCompetencias);
                    }
                }
                if (navigationContext != null)
                {
                    var FicCompetenciasSeleccionada = navigationContext as Eva_curriculo_competencias;

                    if (FicCompetenciasSeleccionada != null)
                    {
                        //System.Diagnostics.Debug.WriteLine("Trae una competencia " + FicCompetenciasSeleccionada.IdCurriculo);
                        NuevaCompetencias = FicCompetenciasSeleccionada;
                        Eva_cat_competencias ecc = new Eva_cat_competencias();
                        ecc = IFicLoSrvCompetencias.FicMetObtenerNombreCompetencias(NuevaCompetencias.IdCompetencia).Result;
                        if (ecc != null) { nombreCatCompetencias = ecc.DesCompetencia; }
                    }

                }
                base.OnAppearing(navigationContext);
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
                Eva_cat_competencias com = IFicLoSrvCompetencias.FicMetObtenerIdsCompetencias(nombreCatCompetencias).Result;
                if (com == null)
                {
                    await new Page().DisplayAlert("ALERTA - SaveCommand", "Ingrese un item valido en Cat Competencias", "OK");
                }
                else
                {
                    NuevaCompetencias.IdCompetencia = com.IdCompetencia;
                    await IFicLoSrvCompetencias.FicMetInsertCompetencias(NuevaCompetencias);
                    IFicLoSrvNavigation.FicMetNavigateBack();
                }

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
