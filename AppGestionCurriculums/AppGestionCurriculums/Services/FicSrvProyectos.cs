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
    public class FicSrvProyectos : IFicSrvProyectos
    {
        private readonly DBContext LoDBContext;

        public FicSrvProyectos()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_proyectos>> FicMetGetListProyectos()
        {
            return await (from eva_proyectos in LoDBContext.eva_proyectos select eva_proyectos).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewProyecto(Eva_proyectos FicInsertProyecto)
        {
            try
            {
                var FicSourceProyectoExist = await (
                       from proyectos in LoDBContext.eva_proyectos
                       where proyectos.IdProyecto == FicInsertProyecto.IdProyecto
                       select proyectos
                        ).FirstOrDefaultAsync();

                if (FicSourceProyectoExist == null)
                {

                    FicInsertProyecto.FechaReg = DateTime.Now;
                    FicInsertProyecto.FechaUltMod = DateTime.Now;
                    FicInsertProyecto.UsuarioReg = "Cristobal Vega";
                    FicInsertProyecto.UsuarioMod = "Cristobal Vega";
                    FicInsertProyecto.Activo = true;
                    FicInsertProyecto.Borrado = false;

                    await LoDBContext.AddAsync(FicInsertProyecto);

                }
                else
                {
                    FicInsertProyecto.IdProyecto = FicSourceProyectoExist.IdProyecto;
                    FicInsertProyecto.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceProyectoExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertProyecto);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteProyecto(Eva_proyectos deleteProyecto)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistProyecto(deleteProyecto))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteProyecto).State = EntityState.Detached;
                    LoDBContext.Remove(deleteProyecto);
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

        private async Task<bool> ExistProyecto(Eva_proyectos existProyecto)
        {
            return await (from proyecto in LoDBContext.eva_proyectos
                          where proyecto.IdProyecto == existProyecto.IdProyecto
                          select proyecto).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO
    }
}
