using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace AppGestionCurriculums.ViewModels.EvaCurriculoConocimientos
{
    public class FicVmEvaCurriculoConocimientosItem : FicViewModelBase
    {
        private Eva_curriculo_conocimientos Fic_NuevoConocimiento;
        private string Fic_Eva_nombre_cat_conocimientos_item;
        public ObservableCollection<string> _FicDataGrid_SourceCatConocimientos;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos;

        public FicVmEvaCurriculoConocimientosItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvCurriculoConocimientos IFicSrvCurriculoConocimientos)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvCurriculoConocimientos = IFicSrvCurriculoConocimientos;

            _FicDataGrid_SourceCatConocimientos = new ObservableCollection<string>();
        }

        public Eva_curriculo_conocimientos NuevoConocimiento
        {
            get { return Fic_NuevoConocimiento; }
            set
            {
                Fic_NuevoConocimiento = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoConocimiento

         public ObservableCollection<string> SourceCatConocimientos
        {
            get
            {
                return _FicDataGrid_SourceCatConocimientos;
            }
            set
            {
                if (_FicDataGrid_SourceCatConocimientos != value)
                {
                    _FicDataGrid_SourceCatConocimientos = value;
                    RaisePropertyChanged("SourceCatCompetencias");
                }
            }
         }
        public string nombreCatConocimientos
        {
            get { return Fic_Eva_nombre_cat_conocimientos_item; }
            set
            {
                Fic_Eva_nombre_cat_conocimientos_item = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var listaCatConocimientos = await IFicSrvCurriculoConocimientos.FicMetGetListCatConocimientos();

                if (listaCatConocimientos != null)
                {
                    // System.Diagnostics.Debug.WriteLine("Trae datos");
                    foreach (string catConocimientos in listaCatConocimientos)
                    {
                        // System.Diagnostics.Debug.WriteLine(catCompetencias);
                        SourceCatConocimientos.Add(catConocimientos);
                    }
                }

                var FicConocimientoSeleccionado = FicPaNavigationContext as Eva_curriculo_conocimientos;

                if (FicConocimientoSeleccionado != null)
                {
                    NuevoConocimiento = FicConocimientoSeleccionado;

                    Eva_cat_conocimientos ecc = new Eva_cat_conocimientos();
                    ecc = IFicSrvCurriculoConocimientos.FicMetObtenerNombreConocimientos(NuevoConocimiento.IdConocimiento).Result;
                    if (ecc != null) { nombreCatConocimientos = ecc.DesConocimiento; }
                }
                


                base.OnAppearing(FicPaNavigationContext);
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
                Eva_cat_conocimientos com = IFicSrvCurriculoConocimientos.FicMetObtenerIdsConocimientos(nombreCatConocimientos).Result;
                if (com == null)
                {
                    await new Page().DisplayAlert("ALERTA - SaveCommand", "Ingrese un item valido en Cat Competencias", "OK");
                }
                else
                {
                    NuevoConocimiento.IdConocimiento = com.IdConocimiento;
                    await IFicSrvCurriculoConocimientos.FicMetInsertNewConocimiento(NuevoConocimiento);
                    IFicSrvNavigation.FicMetNavigateBack();
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
            IFicSrvNavigation.FicMetNavigateBack();
        }
    }
}
