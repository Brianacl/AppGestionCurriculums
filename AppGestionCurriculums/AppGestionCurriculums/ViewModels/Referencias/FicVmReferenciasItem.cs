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
    public class FicVmReferenciasItem : FicViewModelBase
    {
        private Eva_curriculo_referencias Fic_NuevoReferencia;
        private ObservableCollection<Tipo_gen_parentezco_referencias> _SourceReferencias;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvReferencias IFicSrvReferencias;

        public FicVmReferenciasItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvReferencias IFicSrvReferencias)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvReferencias = IFicSrvReferencias;

            _SourceReferencias = new ObservableCollection<Tipo_gen_parentezco_referencias>();
        }

        public ObservableCollection<Tipo_gen_parentezco_referencias> SourceReferencias
        {
            get
            {
                return _SourceReferencias;
            }
            set
            {
                _SourceReferencias = value;
                RaisePropertyChanged();
            }
        }

        public Eva_curriculo_referencias NuevoReferencia
        {
            get
            {
                return Fic_NuevoReferencia;
            }
            set
            {
                Fic_NuevoReferencia = value;
                RaisePropertyChanged();
            }
        }


        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var listaReferencia = await IFicSrvReferencias.FicMetGetListTipoParentezcoReferencias();

                if (listaReferencia != null)
                {
                    System.Diagnostics.Debug.WriteLine("traedatos");
                    foreach (Tipo_gen_parentezco_referencias TiposReferencias in listaReferencia)
                    {
                        SourceReferencias.Add(TiposReferencias);
                    }
                }

                //--------------------------------------
                var FicReferenciaSeleccionado = FicPaNavigationContext as Eva_curriculo_referencias;
                if (FicReferenciaSeleccionado != null)
                {
                    NuevoReferencia = FicReferenciaSeleccionado;
                }
                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "o");
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
                await IFicSrvReferencias.FicMetInsertNewReferencia(NuevoReferencia);
                IFicSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "");

            }
        }

        public ICommand FicMetCancelCommand
        {
            get
            {
                return FicCancelCommand = FicCancelCommand ??
                    new FicVmDelegateCommand(CancelCommandExecute);
            }
        }
        private void CancelCommandExecute()
        {
            IFicSrvNavigation.FicMetNavigateBack();
        }
    }
}
