using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces.Competencias;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace AppGestionCurriculums.Services.Competencias
{
    public class FicSrvCompetencias : IFicSrvCompetencias
    {
        private readonly DBContext FicLoBDContext;
        public short idCurriculo;
        public FicSrvCompetencias()
        {
            FicLoBDContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_curriculo_competencias>> FicMetGetListCompetencias(Eva_curriculo_persona curriculo)
        {
            return await (from competencias in FicLoBDContext.eva_curriculo_competencias
                          where competencias.IdCurriculo == curriculo.IdCurriculo
                          select competencias).AsNoTracking().ToListAsync();
        }
        public async Task FicMetInsertCompetencias(Eva_curriculo_competencias FicInsertCompetencias)
        {
            try
            {
                var FicSourceCompetenciasExist = await (
                       from competencias in FicLoBDContext.eva_curriculo_competencias 
                       where competencias.IdCompetencia == FicInsertCompetencias.IdCompetencia
                       select competencias
                        ).FirstOrDefaultAsync();
                if (FicSourceCompetenciasExist == null)
                {
                    FicInsertCompetencias.FechaReg = DateTime.Now;
                    FicInsertCompetencias.FechaUltMod = DateTime.Now;
                    FicInsertCompetencias.UsuarioReg = "Beth";
                    FicInsertCompetencias.UsuarioMod = "Beth";
                    FicInsertCompetencias.Activo = "S";
                    FicInsertCompetencias.Borrado = "N";
                    await FicLoBDContext.AddAsync(FicInsertCompetencias);
                }
                else
                {
                    FicInsertCompetencias.IdCompetencia = FicSourceCompetenciasExist.IdCompetencia;
                    FicInsertCompetencias.FechaUltMod = DateTime.Now;
                    FicLoBDContext.Entry(FicSourceCompetenciasExist).State = EntityState.Detached;
                    FicLoBDContext.Update(FicInsertCompetencias);
                }
                await FicLoBDContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo
        public async Task FicMetDeleteCompetencias(Eva_curriculo_competencias deletecompetencias)
        {
            using (IDbContextTransaction transaction = FicLoBDContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistCompetencias(deletecompetencias))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO
                    FicLoBDContext.Entry(deletecompetencias).State = EntityState.Detached;
                    FicLoBDContext.Remove(deletecompetencias);
                    await FicLoBDContext.SaveChangesAsync();
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
        private async Task<bool> ExistCompetencias(Eva_curriculo_competencias existCompetencias)
        {
            return await (from competencias in FicLoBDContext.eva_curriculo_competencias
                          where competencias.IdCompetencia == existCompetencias.IdCompetencia
                          select competencias).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO

        private short ObtenerCurriculo(Rh_cat_personas obtId)
        {
             var s= (from competencias in FicLoBDContext.eva_curriculo_persona
                          where competencias.IdPersona == obtId.IdPersona
                          select competencias).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
            if (s == true)
            {
                var c = (from competencias in FicLoBDContext.eva_curriculo_persona
                         where competencias.IdPersona == obtId.IdPersona
                         select competencias).AsNoTracking().ToString();
                return Int16.Parse(c);
            }
            else
            {
                return 0;
            }
            
        }//BUSCA SI EXISTE UN REGISTRO

    }

    
}
