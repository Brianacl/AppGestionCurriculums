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
        public short idCurriculo;
        public FicSrvCompetencias()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor
        public async Task<IEnumerable<Eva_curriculo_competencias>> FicMetGetListCompetencias(short id)
        {
            idCurriculo = id;
            return await (from Eva_curriculo_competencias in FicLoBDContext.eva_curriculo_competencias
                          where Eva_curriculo_competencias.IdCurriculo == id
                          select Eva_curriculo_competencias).AsNoTracking().ToListAsync();
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
                    FicInsertCompetencias.IdCurriculo = idCurriculo;
                    FicInsertCompetencias.FechaReg = DateTime.Today;
                    FicInsertCompetencias.FechaUltMod = DateTime.Today;
                    FicInsertCompetencias.UsuarioReg = "Beth";
                    FicInsertCompetencias.UsuarioMod = "Beth";
                    FicInsertCompetencias.Activo = true;
                    FicInsertCompetencias.Borrado = false;
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

    }

    
}
