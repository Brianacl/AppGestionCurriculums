using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels
{
    public class FicVmEvaExperienciaLaboralList : FicViewModelBase
    {
        public ObservableCollection<Eva_experiencia_laboral> _FicDataGrid_SourceExperienciaLaboral;
        public Eva_experiencia_laboral _FicDataGrid_SelectedExperienciaLaboral;
        private ICommand _FicAddExperienciaLaboralCommand;
        private ICommand _FicEditExperienciaLaboralCommand;
        private ICommand _FicDetalleExperienciaLaboralCommand;
        private ICommand _FicDeleteExperienciaLaboralCommand;

        private IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia;
        private IFicSrvExperienciaList IFicSrvExperienciaList;

        public FicVmEvaExperienciaLaboralList(IFicSrvNavigationExperiencia IFicSrvNavigationExperiencia, IFicSrvExperienciaList IFicSrvExperienciaList)
        {
            this.IFicSrvNavigationExperiencia = IFicSrvNavigationExperiencia;
            this.IFicSrvExperienciaList = IFicSrvExperienciaList;

            _FicDataGrid_SourceExperienciaLaboral = new ObservableCollection<Eva_experiencia_laboral>();
        }

        public ObservableCollection<Eva_experiencia_laboral> SourceExperienciaLaboral
        {
            get
            {
                return _FicDataGrid_SourceExperienciaLaboral;
            }
            set
            {
                if(_FicDataGrid_SourceExperienciaLaboral != value)
                {
                    _FicDataGrid_SourceExperienciaLaboral = value;
                    RaisePropertyChanged("SourceExperienciaLaboral");
                }
            }
        }

        public Eva_experiencia_laboral SelectedExperienciaLaboral
        {
            get
            {
                return _FicDataGrid_SelectedExperienciaLaboral;
            }
            set
            {
                if(value != null)
                {
                    _FicDataGrid_SelectedExperienciaLaboral = value;
                    RaisePropertyChanged("SelectedExperienciaLaboral");
                }
            }
        }

        public ICommand FicMetAddExperienciaLaboralICommand
        {
            get
            {
                return _FicAddExperienciaLaboralCommand = _FicAddExperienciaLaboralCommand ??
                    new FicVmDelegateCommand(FicMetAddExperienciaLaboral);
            }
        }
        public ICommand FicMetEditExperienciaLaboralICommand
        {
            get
            {
                return _FicEditExperienciaLaboralCommand = _FicEditExperienciaLaboralCommand ??
                    new FicVmDelegateCommand(FicMetEditExperienciaLaboral);
            }
        }
        public ICommand FicMetDetalleExperienciaLaboralICommand
        {
            get
            {
                return _FicDetalleExperienciaLaboralCommand = _FicDetalleExperienciaLaboralCommand ??
                    new FicVmDelegateCommand(FicMetDetalleExperienciaLaboral);
            }
        }

        public ICommand FicMetDeleteExperienciaLaboralICommand
        {
            get
            {
                return _FicDeleteExperienciaLaboralCommand = _FicDeleteExperienciaLaboralCommand ??
                    new FicVmDelegateCommand(FicMetDeleteExperienciaLaboral);
            }

        }

        private async void FicMetDeleteExperienciaLaboral()
        {
            try
            {
                if(_FicDataGrid_SelectedExperienciaLaboral != null)
                {
                    await IFicSrvExperienciaList.FicMetDeleteExperiencia(_FicDataGrid_SelectedExperienciaLaboral);
                    _FicDataGrid_SelectedExperienciaLaboral = null;
                }
                else
                {
                    await new Page().DisplayAlert("alerta", "seleccione el registro a eliminar", "ok");
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }//deledte

        public void FicMetAddExperienciaLaboral()
        {
            IFicSrvNavigationExperiencia.FicMetNavigateTo<FicVmEvaExperienciaLaboralItem>(new Eva_experiencia_laboral());
        }//add

        private async void FicMetEditExperienciaLaboral()
        {
            if (_FicDataGrid_SelectedExperienciaLaboral != null)
                IFicSrvNavigationExperiencia.FicMetNavigateTo<FicVmEvaExperienciaLaboralItem>(_FicDataGrid_SelectedExperienciaLaboral);
            else
                await new Page().DisplayAlert("alerta - editar", "seleccione registro a editar","ok");
        }
        private async void FicMetDetalleExperienciaLaboral()
        {
            if(_FicDataGrid_SelectedExperienciaLaboral != null)
            {
                IFicSrvNavigationExperiencia.FicMetNavigateTo<FicVmEvaExperienciaLaboralDetalle>(_FicDataGrid_SelectedExperienciaLaboral);
            }
            else
            {
                await new Page().DisplayAlert("alerta", "para ver detalle seleccione item", "ok");

            }
        }

        public async override void OnAppearing(object context)
        {
            try
            {
                SourceExperienciaLaboral.Clear();
                var source_local_inv = await IFicSrvExperienciaList.FicMetGetListExperiencia();
                if(source_local_inv != null)
                {
                    foreach(Eva_experiencia_laboral experiencia in source_local_inv)
                    {
                        SourceExperienciaLaboral.Add(experiencia);
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }



            
    }
}
