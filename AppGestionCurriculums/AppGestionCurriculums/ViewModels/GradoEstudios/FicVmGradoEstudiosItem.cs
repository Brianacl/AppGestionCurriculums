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

namespace AppGestionCurriculums.ViewModels.GradoEstudios
{
    public class FicVmGradoEstudiosItem : FicViewModelBase
    {
        private Eva_carrera_grado_estudios Fic_NuevoGradoEstudio;
        private ObservableCollection<Tipo_gen_grado_estudio> _SourceGradosEstudio;
        private ObservableCollection<Estatus_grado_estudios> _SourceEstatusGradoEstudio;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvGradoEstudios IFicSrvGradoEstudios;

        public FicVmGradoEstudiosItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvGradoEstudios IFicSrvGradoEstudios)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvGradoEstudios = IFicSrvGradoEstudios;

            _SourceGradosEstudio = new ObservableCollection<Tipo_gen_grado_estudio>();
            _SourceEstatusGradoEstudio = new ObservableCollection<Estatus_grado_estudios>();
        }

        public ObservableCollection<Tipo_gen_grado_estudio> SourceGradosEstudio
        {
            get { return _SourceGradosEstudio; }
            set
            {
                _SourceGradosEstudio = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Estatus_grado_estudios> SourceEstatusGradoEstudio
        {
            get { return _SourceEstatusGradoEstudio; }
            set
            {
                _SourceEstatusGradoEstudio = value;
                RaisePropertyChanged();
            }
        }

        public Eva_carrera_grado_estudios NuevoGradoEstudio
        {
            get { return Fic_NuevoGradoEstudio; }
            set
            {
                Fic_NuevoGradoEstudio = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                //Grado estudios
                var listaGradosEstudio = await IFicSrvGradoEstudios.FicMetGetListTipoGradoEstudio();

                if (listaGradosEstudio != null)
                {
                    foreach (Tipo_gen_grado_estudio TiposGradoEstudios in listaGradosEstudio)
                    {
                        //System.Diagnostics.Debug.WriteLine(TiposGradoEstudios);
                        SourceGradosEstudio.Add(TiposGradoEstudios);
                    }
                }

                //Estatus
                var listaEstatus = await IFicSrvGradoEstudios.FicMetGetListEstatusGradoEstudio();

                if(listaEstatus != null)
                {
                    foreach (Estatus_grado_estudios estatus in listaEstatus)
                    {
                        //System.Diagnostics.Debug.WriteLine(TiposGradoEstudios);
                        SourceEstatusGradoEstudio.Add(estatus);
                    }
                }

                var FicGradoEstudioSeleccionado = FicPaNavigationContext as Eva_carrera_grado_estudios;

                if (FicGradoEstudioSeleccionado != null)
                {
                    NuevoGradoEstudio = FicGradoEstudioSeleccionado;
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
                await IFicSrvGradoEstudios.FicMetInsertNewGradoEstudios(NuevoGradoEstudio);
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
