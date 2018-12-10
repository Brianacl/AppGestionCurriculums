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
    public class FicSrvCurriculoPersonas : IFicSrvEvaCurriculoPersonas
    {
        private readonly DBContext LoDBContext;

        public FicSrvCurriculoPersonas()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Eva_curriculo_persona>> FicMetGetCurriculo(Rh_cat_personas persona)
        {
            return await (from curriculo in LoDBContext.eva_curriculo_persona
                          where curriculo.IdPersona == persona.IdPersona
                          select curriculo
                          ).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewCurriculo(Eva_curriculo_persona FicInsertCurriculo)
        {
            try
            {
                var FicSourceCurriculoExist = await (
                       from curriculo in LoDBContext.eva_curriculo_persona
                       where curriculo.IdCurriculo == FicInsertCurriculo.IdCurriculo
                       select curriculo
                        ).FirstOrDefaultAsync();

                if (FicSourceCurriculoExist == null)
                {

                    FicInsertCurriculo.FechaReg = DateTime.Now;
                    FicInsertCurriculo.FechaUltMod = DateTime.Now;
                    FicInsertCurriculo.UsuarioReg = "Beth";
                    FicInsertCurriculo.UsuarioMod = "Beth";
                    FicInsertCurriculo.Activo = "S";
                    FicInsertCurriculo.Borrado = "N";

                    await LoDBContext.AddAsync(FicInsertCurriculo);

                }
                else
                {
                    FicInsertCurriculo.IdCurriculo = FicSourceCurriculoExist.IdCurriculo;
                    FicInsertCurriculo.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceCurriculoExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertCurriculo);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SRVINSERT", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeleteCurriculo(Eva_curriculo_persona deleteCurriculo)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistCurriculo(deleteCurriculo))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deleteCurriculo).State = EntityState.Detached;
                    LoDBContext.Remove(deleteCurriculo);
                    await LoDBContext.SaveChangesAsync();

                    transaction.Commit(); //CONFIRMA/GUARDA
                    return;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("ALERTA - SRVDELETE", ex.Message.ToString(), "OK");
                }
            }//ENTRA EN CONTEXTO DE TRANSACIONES
        }//Fin delete

        private async Task<bool> ExistCurriculo(Eva_curriculo_persona existCurriculo)
        {
            return await (from curriculo in LoDBContext.eva_curriculo_persona
                          where curriculo.IdCurriculo == existCurriculo.IdCurriculo
                          select curriculo).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO
    }
}
