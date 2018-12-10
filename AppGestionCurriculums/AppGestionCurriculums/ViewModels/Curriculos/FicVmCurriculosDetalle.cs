using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using AppGestionCurriculums.ViewModels.Competencias;
using AppGestionCurriculums.ViewModels.EvaCurriculoIdiomas;
using AppGestionCurriculums.ViewModels.ExperienciaLaboral;
using AppGestionCurriculums.ViewModels.GradoEstudios;
using AppGestionCurriculums.ViewModels.Referencias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Curriculos
{
    public class FicVmCurriculosDetalle : FicViewModelBase
    {
        public Eva_curriculo_persona FicCurriculoSeleccionado;

        private ICommand FicEditCurriculoCommand;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private ICommand FicCompetenciasCommand;
        private ICommand FicIdiomasCommand;
        private ICommand FicGradoEstudioCommand;
        private ICommand FicExperienciaCommand;
        private ICommand FicReferenciaCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvEvaCurriculoPersonas IFicSrvEvaCurriculoPersonas;

        public FicVmCurriculosDetalle(IFicSrvNavigation IFicSrvNavigation, IFicSrvEvaCurriculoPersonas IFicSrvEvaCurriculoPersonas)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvEvaCurriculoPersonas = IFicSrvEvaCurriculoPersonas;
        }

        public Eva_curriculo_persona FicDatosCurriculo
        {
            get { return FicCurriculoSeleccionado; }
            set
            {
                FicCurriculoSeleccionado = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicPersona = FicPaNavigationContext as Rh_cat_personas;

                var source_local_inv = await IFicSrvEvaCurriculoPersonas.FicMetGetCurriculo(FicPersona);

                if (source_local_inv != null)
                {
                    foreach (Eva_curriculo_persona curriculo in source_local_inv)
                    {
                        FicDatosCurriculo = curriculo;
                    }
                }//No llena el grid, llena el observableCollection para poder hacer el binding

                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA ITEM", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMetEditCurriculoICommand
        {
            get
            {
                return FicEditCurriculoCommand = FicEditCurriculoCommand ??
                    new FicVmDelegateCommand(FicMetEditCurriculo);
            }
        }

        private async void FicMetEditCurriculo()
        {
            if (FicDatosCurriculo != null)
                IFicSrvNavigation.FicMetNavigateTo<FicVmCurriculosItem>
                    (FicDatosCurriculo);
            else
                await new Page().DisplayAlert("ALERTA - editar", "Para editar primero seleccione un registro", "OK");
        }

        public ICommand FicMetDeleteCommand
        {
            get
            {
                return FicDeleteCommand = FicDeleteCommand ??
                  new FicVmDelegateCommand(DeleteCommandExecute);
            }
        }

        public async void DeleteCommandExecute()
        {
            try
            {
                await IFicSrvEvaCurriculoPersonas.FicMetDeleteCurriculo(FicDatosCurriculo);
                IFicSrvNavigation.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - Delete", e.Message.ToString(), "OK");
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

        public ICommand FicMetCompetenciasCommand
        {
            get
            {
                return FicCompetenciasCommand = FicCompetenciasCommand ??
                    new FicVmDelegateCommand(CompetenciasCommandExecute);
            }
        }

        private void CompetenciasCommandExecute()
        {
            if (FicDatosCurriculo != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmCompetenciasList>
                    (FicDatosCurriculo);
            }
        }

        public ICommand FicMetIdiomasCommand
        {
            get
            {
                return FicIdiomasCommand = FicIdiomasCommand ??
                    new FicVmDelegateCommand(IdiomasCommandExecute);
            }
        }

        private void IdiomasCommandExecute()
        {
            if (FicDatosCurriculo != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmEvaCurriculoIdiomasList>
                    (FicDatosCurriculo);
            }
        }

        public ICommand FicMetGradoEstudioCommand
        {
            get
            {
                return FicGradoEstudioCommand = FicGradoEstudioCommand ??
                    new FicVmDelegateCommand(GradoEstudioCommandExecute);
            }
        }

        private void GradoEstudioCommandExecute()
        {
            if (FicDatosCurriculo != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmGradoEstudiosList>
                    (FicDatosCurriculo);
            }
        }

        public ICommand FicMetExperienciaCommand
        {
            get
            {
                return FicExperienciaCommand = FicExperienciaCommand ??
                    new FicVmDelegateCommand(ExperienciaCommandExecute);
            }
        }

        private void ExperienciaCommandExecute()
        {
            if (FicDatosCurriculo != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmExperienciaList>
                    (FicDatosCurriculo);
            }
        }

        public ICommand FicMetReferenciasCommand
        {
            get
            {
                return FicReferenciaCommand = FicReferenciaCommand ??
                    new FicVmDelegateCommand(ReferenciaCommandExecute);
            }
        }

        private void ReferenciaCommandExecute()
        {
            if (FicDatosCurriculo != null)
            {
                IFicSrvNavigation.FicMetNavigateTo<FicVmReferenciasList>
                    (FicDatosCurriculo);
            }
        }
    }
}
