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

namespace AppGestionCurriculums.ViewModels.ExperienciaLaboral
{
    public class FicVmExperienciaItem : FicViewModelBase
    {
        private Eva_experiencia_laboral Fic_NuevaExperiencia;
        private ObservableCollection<Tipo_gen_giro_experienciaLaboral> _SourceGenGiroExperienciaLaboral;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvExperienciaLaboral IFicSrvExperienciaLaboral;

        public FicVmExperienciaItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvExperienciaLaboral IFicSrvExperienciaLaboral)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvExperienciaLaboral = IFicSrvExperienciaLaboral;

            _SourceGenGiroExperienciaLaboral = new ObservableCollection<Tipo_gen_giro_experienciaLaboral>();
        }

        public ObservableCollection<Tipo_gen_giro_experienciaLaboral> SourceGenGiroExperienciaLaboral
        {
            get { return _SourceGenGiroExperienciaLaboral; }
            set
            {
                _SourceGenGiroExperienciaLaboral = value;
                RaisePropertyChanged();
            }
        }

        public Eva_experiencia_laboral NuevaExperiencia
        {
            get { return Fic_NuevaExperiencia; }
            set
            {
                Fic_NuevaExperiencia = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var listaExperienciaLaboral = await IFicSrvExperienciaLaboral.FicMetGetListTipoGiroExperienciaLaboral();

                if (listaExperienciaLaboral != null)
                {
                    foreach (Tipo_gen_giro_experienciaLaboral TiposExperienciaLaboral in listaExperienciaLaboral)
                    {
                        System.Diagnostics.Debug.WriteLine(TiposExperienciaLaboral.DesGeneral);
                        SourceGenGiroExperienciaLaboral.Add(TiposExperienciaLaboral);
                    }
                }
                //----------------------------
                var FicExperienciaSeleccionado = FicPaNavigationContext as Eva_experiencia_laboral;

                if (FicExperienciaSeleccionado != null)
                {
                    NuevaExperiencia = FicExperienciaSeleccionado;
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

        public async void SaveCommandExecute()
        {
            try
            {
                await IFicSrvExperienciaLaboral.FicMetInsertNewExperiencia(NuevaExperiencia);
                IFicSrvNavigation.FicMetNavigateBack();
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
