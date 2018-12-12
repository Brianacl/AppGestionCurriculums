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
    public class FicSrvExperienciaLaboral : IFicSrvExperienciaLaboral
    {
        private readonly DBContext LoDBContext;

        public FicSrvExperienciaLaboral()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_experiencia_laboral>> FicMetGetListExperiencias(Eva_curriculo_persona curriculo)
        {
            return await (from experiencias in LoDBContext.eva_experiencia_laboral
                          where experiencias.IdCurriculo == curriculo.IdCurriculo
                          select experiencias).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Tipo_gen_giro_experienciaLaboral>> FicMetGetListTipoGiroExperienciaLaboral()
        {
            return await (from tipo_Gen_Giro_ExperienciaLaboral in LoDBContext.tipo_Gen_Giro_ExperienciaLaboral
                          select tipo_Gen_Giro_ExperienciaLaboral).AsNoTracking().ToListAsync();
        }

        

        public async Task FicMetInsertNewExperiencia(Eva_experiencia_laboral FicInsertExperiencia)
        {
            try
            {
                var FicSourceExperienciaExist = await (
                       from experiencia in LoDBContext.eva_experiencia_laboral
                       where experiencia.IdExperiencia == FicInsertExperiencia.IdExperiencia
                       select experiencia
                        ).FirstOrDefaultAsync();

                if (FicSourceExperienciaExist == null)
                {
                    var IdExperiencia = ultimaExperiencia();
                    FicInsertExperiencia.IdExperiencia = (short)++IdExperiencia;
                    FicInsertExperiencia.FechaReg = DateTime.Now;
                    FicInsertExperiencia.FechaUltMod = DateTime.Now;
                    FicInsertExperiencia.UsuarioReg = "Alegria";
                    FicInsertExperiencia.UsuarioMod = "Alegria";
                    FicInsertExperiencia.Activo = "S";
                    FicInsertExperiencia.Borrado = "N";

                    await LoDBContext.AddAsync(FicInsertExperiencia);

                }
                else
                {
                    FicInsertExperiencia.IdExperiencia = FicSourceExperienciaExist.IdExperiencia;
                    FicInsertExperiencia.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceExperienciaExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertExperiencia);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteExperiencia(Eva_experiencia_laboral deleteExperiencia)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistExperiencia(deleteExperiencia))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteExperiencia).State = EntityState.Detached;
                    LoDBContext.Remove(deleteExperiencia);
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

        private async Task<bool> ExistExperiencia(Eva_experiencia_laboral existExperiencia)
        {
            return await (from experiencia in LoDBContext.eva_experiencia_laboral
                          where experiencia.IdExperiencia == existExperiencia.IdExperiencia
                          select experiencia).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO

        private int ultimaExperiencia()
        {
            if(LoDBContext.eva_experiencia_laboral.Count() == 0)
            {
                return 0;
            }
            return LoDBContext.eva_experiencia_laboral.Max(experienciaLaboral => experienciaLaboral.IdExperiencia);
        }
    }//Clase
}
