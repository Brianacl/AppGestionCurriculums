using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppGestionCurriculums.Services
{
    public class FicSrvOtrasActividades : IFicSrvOtrasActividades
    {
        private readonly DBContext LoDBContext;

        public FicSrvOtrasActividades()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_curriculo_otras_actividades>> FicMetGetListOtrasActividades(Eva_curriculo_persona curriculo)
        {
            return await (from otraActividad in LoDBContext.eva_otras_actividades
                          where otraActividad.IdCurriculo == curriculo.IdCurriculo
                          select otraActividad).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewOtraActividad(Eva_curriculo_otras_actividades FicInsertOtraActividad)
        {
            try
            {
                var FicSourceOtraActividadExist = await (
                       from otraActividad in LoDBContext.eva_otras_actividades
                       where otraActividad.IdActividad == FicInsertOtraActividad.IdActividad
                       select otraActividad
                        ).FirstOrDefaultAsync();

                if (FicSourceOtraActividadExist == null)
                {
                    var idActividad = ultimaActividad();
                    FicInsertOtraActividad.IdActividad = (short)++idActividad;
                    FicInsertOtraActividad.FechaReg = DateTime.Now;
                    FicInsertOtraActividad.FechaUltMod = DateTime.Now;
                    FicInsertOtraActividad.UsuarioReg = "Brian Casas";
                    FicInsertOtraActividad.UsuarioMod = "Brian Casas";
                    FicInsertOtraActividad.Activo = 'S';
                    FicInsertOtraActividad.Borrado = 'N';

                    await LoDBContext.AddAsync(FicInsertOtraActividad);

                }
                else
                {
                    FicInsertOtraActividad.IdActividad = FicSourceOtraActividadExist.IdActividad;
                    FicInsertOtraActividad.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceOtraActividadExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertOtraActividad);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
                if (e.InnerException != null)
                    System.Diagnostics.Debug.WriteLine("----> " + e.InnerException);
            }
        }//Insertar nuevo

        public async Task FicMetDeleteOtraActividad(Eva_curriculo_otras_actividades deleteOtraActividad)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistOtraActividad(deleteOtraActividad))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteOtraActividad).State = EntityState.Detached;
                    LoDBContext.Remove(deleteOtraActividad);
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

        private int ultimaActividad()
        {
            if (LoDBContext.eva_otras_actividades.Count() == 0)
            {
                return 0;
            }

            return LoDBContext.eva_otras_actividades.Max(otraActividad => otraActividad.IdActividad);
        }

        private async Task<bool> ExistOtraActividad(Eva_curriculo_otras_actividades existOtraActividad)
        {
            return await (from otraActividad in LoDBContext.eva_otras_actividades
                          where otraActividad.IdActividad == existOtraActividad.IdActividad
                          select otraActividad).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO
    }
}
