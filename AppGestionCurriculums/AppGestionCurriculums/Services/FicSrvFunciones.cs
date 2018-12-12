using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppGestionCurriculums.Services
{
    public class FicSrvFunciones : IFicSrvFunciones
    {
        private readonly DBContext LoDBContext;

        public FicSrvFunciones()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_actividades_funciones>> FicMetGetListFunciones(Eva_experiencia_laboral experiencia)
        {
            return await (from funciones in LoDBContext.eva_actividades_funciones
                          where funciones.IdExperiencia == experiencia.IdExperiencia
                          select funciones).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewFuncion(Eva_actividades_funciones FicInsertFuncion)
        {
            try
            {
                var FicSourceFuncionExist = await (
                       from funciones in LoDBContext.eva_actividades_funciones
                       where funciones.IdFuncionAct == FicInsertFuncion.IdFuncionAct
                       select funciones
                        ).FirstOrDefaultAsync();

                if (FicSourceFuncionExist == null)
                {
                    var idFuncionAct = ultimaFuncion();
                    FicInsertFuncion.IdFuncionAct = (short)++idFuncionAct;
                    FicInsertFuncion.FechaReg = DateTime.Now;
                    FicInsertFuncion.FechaUltMod = DateTime.Now;
                    FicInsertFuncion.UsuarioReg = "Cristobal Vega";
                    FicInsertFuncion.UsuarioMod = "Cristobal Vega";
                    FicInsertFuncion.Activo = 'S';
                    FicInsertFuncion.Borrado = 'N';

                    await LoDBContext.AddAsync(FicInsertFuncion);

                }
                else
                {
                    FicInsertFuncion.IdFuncionAct = FicSourceFuncionExist.IdFuncionAct;
                    FicInsertFuncion.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceFuncionExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertFuncion);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteFuncion(Eva_actividades_funciones deleteFuncion)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistFuncion(deleteFuncion))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteFuncion).State = EntityState.Detached;
                    LoDBContext.Remove(deleteFuncion);
                    await LoDBContext.SaveChangesAsync();

                    transaction.Commit(); //CONFIRMA/GUARDA
                    return;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("ALERTA - SrvDelete", ex.Message.ToString(), "OK");
                }
            }//ENTRA EN CONTEXTO DE TRANSACIONES
        }//Fin delete

        private async Task<bool> ExistFuncion(Eva_actividades_funciones existFuncion)
        {
            return await (from funcion in LoDBContext.eva_actividades_funciones
                          where funcion.IdFuncionAct == existFuncion.IdFuncionAct
                          select funcion).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO

        private int ultimaFuncion()
        {
            if (LoDBContext.eva_actividades_funciones.Count() == 0)
            {
                return 0;
            }

            return LoDBContext.eva_actividades_funciones.Max(funcion => funcion.IdFuncionAct);
        }
    }//Fin clase
}
