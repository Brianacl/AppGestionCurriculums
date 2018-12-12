﻿using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.Navegacion;
using AppGestionCurriculums.Models;
using AppGestionCurriculums.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionCurriculums.ViewModels.Proyectos
{
    public class FicVmProyectosItem : FicViewModelBase
    {
        private Eva_proyectos Fic_NuevoProyecto;
        private ObservableCollection<Cat_estatus> _SourceEstatus;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigation IFicSrvNavigation;
        private IFicSrvProyectos IFicSrvProyectos;

        public FicVmProyectosItem(IFicSrvNavigation IFicSrvNavigation, IFicSrvProyectos IFicSrvProyectos)
        {
            this.IFicSrvNavigation = IFicSrvNavigation;
            this.IFicSrvProyectos = IFicSrvProyectos;

            _SourceEstatus = new ObservableCollection<Cat_estatus>();
        }

        public Eva_proyectos NuevoProyecto
        {
            get { return Fic_NuevoProyecto; }
            set
            {
                Fic_NuevoProyecto = value;
                RaisePropertyChanged();
            }
        }//Fin NuevoIdioma

        public ObservableCollection<Cat_estatus> SourceEstatus
        {
            get { return _SourceEstatus; }
            set
            {
                _SourceEstatus = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var estatus = await IFicSrvProyectos.FicMetGetListEstatus();

                if(estatus != null)
                {
                    foreach(Cat_estatus _estatus in estatus)
                    {
                        SourceEstatus.Add(_estatus);
                    }
                }

                var FicProyectoSeleccionado = FicPaNavigationContext as Eva_proyectos;

                if (FicProyectoSeleccionado != null)
                {
                    NuevoProyecto = FicProyectoSeleccionado;
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
                await IFicSrvProyectos.FicMetInsertNewProyecto(NuevoProyecto);
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
