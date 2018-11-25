using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppGestionCurriculums.Services
{
    public class FicSrvCurriculoIdiomas : IFicSrvCurriculoIdiomas
    {
        private readonly DBContext LoDBContext;

        public FicSrvCurriculoIdiomas()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_curriculo_idiomas>> FicMetGetListIdiomas()
        {
            return await (from eva_curriculo_idiomas in LoDBContext.eva_curriculo_idiomas select eva_curriculo_idiomas).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewIdioma(Eva_curriculo_idiomas FicInsertIdioma)
        {
            try
            {
                var FicSourceIdiomaExist = await (
                       from idiomas in LoDBContext.eva_curriculo_idiomas
                       where idiomas.IdIdioma == FicInsertIdioma.IdIdioma
                       select idiomas
                        ).FirstOrDefaultAsync();

                if (FicSourceIdiomaExist == null)
                {

                    FicInsertIdioma.FechaReg = DateTime.Today;
                    FicInsertIdioma.FechaUltMod = DateTime.Today;
                    FicInsertIdioma.UsuarioReg = "Brian Casas";
                    FicInsertIdioma.UsuarioMod = "Brian Casas";
                    FicInsertIdioma.Activo = true;
                    FicInsertIdioma.Borrado = false;

                    await LoDBContext.AddAsync(FicInsertIdioma);

                }
                else
                {
                    FicInsertIdioma.IdIdioma = FicSourceIdiomaExist.IdIdioma;
                    FicInsertIdioma.FechaUltMod = DateTime.Today;
                    LoDBContext.Entry(FicSourceIdiomaExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertIdioma);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteIdioma(Eva_curriculo_idiomas deleteIdioma)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistIdioma(deleteIdioma))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteIdioma).State = EntityState.Detached;
                    LoDBContext.Remove(deleteIdioma);
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

        private async Task<bool> ExistIdioma(Eva_curriculo_idiomas existIdioma)
        {
            return await (from idioma in LoDBContext.eva_curriculo_idiomas
                          where idioma.IdIdioma == existIdioma.IdIdioma
                          select idioma).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO
    }
}
