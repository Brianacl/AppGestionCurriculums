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
        private readonly FicDBContext FicLoBDContext;
        public FicSrvCompetencias()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor
        public async Task<IEnumerable<Eva_curriculo_competencias>> FicMetGetListCompetencias()
        {
            return await (from eva_curriculo_competencias in FicLoBDContext.eva_curriculo_competencias select eva_curriculo_competencias).AsNoTracking().ToListAsync();
        }
        public async Task FicMetInsertCompetencia(Eva_curriculo_competencias FicInsertCompetencias)
        {
            try
            {
                var FicSourceCompetenciaExist = await (
                       from competencias in FicLoBDContext.eva_curriculo_competencias 
                       where competencias.IdCompetencia == FicInsertCompetencias.IdCompetencia
                       select competencias
                        ).FirstOrDefaultAsync();
                if (FicSourceCompetenciaExist == null)
                {
                    FicInsertCompetencias.FechaReg = DateTime.Now;
                    FicInsertCompetencias.FechaUltMod = DateTime.Now;
                    FicInsertCompetencias.UsuarioReg = "Beth";
                    FicInsertCompetencias.UsuarioMod = "Beth";
                    FicInsertCompetencias.Activo = true;
                    FicInsertCompetencias.Borrado = false;
                    await FicLoBDContext.AddAsync(FicInsertCompetencias);
                }
                else
                {
                    FicInsertCompetencias.IdCompetencia = FicSourceCompetenciaExist.IdCompetencia;
                    FicInsertCompetencias.FechaUltMod = DateTime.Now;
                    FicLoBDContext.Entry(FicSourceCompetenciaExist).State = EntityState.Detached;
                    FicLoBDContext.Update(FicInsertCompetencias);
                }
                await FicLoBDContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo
        public async Task FicMetDeleteCompetencia(Eva_curriculo_competencias deleteCompetencia)
        {
            using (IDbContextTransaction transaction = FicLoBDContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistCompetencia(deleteCompetencia))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO
                    FicLoBDContext.Entry(deleteCompetencia).State = EntityState.Detached;
                    FicLoBDContext.Remove(deleteCompetencia);
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
        private async Task<bool> ExistCompetencia(Eva_curriculo_competencias existCompetencia)
        {
            return await (from competencia in FicLoBDContext.eva_curriculo_competencias
                          where competencia.IdCompetencia == existCompetencia.IdCompetencia
                          select competencia).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO
        /*
        public Task FicMetUpdateCompetencia(Eva_curriculo_competencias ficPa_Eva_curriculo_competencias)
        {
            throw new NotImplementedException();
        }*/
    }

    
}
