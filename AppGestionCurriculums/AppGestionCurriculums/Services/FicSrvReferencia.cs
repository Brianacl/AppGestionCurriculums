using System;
using System.Collections.Generic;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Data;
using AppGestionCurriculums.Models;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppGestionCurriculums.Interfaces.SQLite;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace AppGestionCurriculums.Services
{
    class FicSrvReferencia : IFicSrvReferencia
    {
        private readonly FicDBContext LoDBContext;

        public FicSrvReferencia()
        {
            LoDBContext = new FicDBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
        }

        public async Task<IEnumerable<Eva_curriculo_referencias>> FicMetGetListReferencias()
        {
            return await (from Eva_curriculo_referencias in LoDBContext.eva_Curriculo_Referencias select Eva_curriculo_referencias).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewReferencia(Eva_curriculo_referencias FicInsertReferencia)
        {
            try
            {
                var FicSourceReferenciaExist = await (
                    from referencia in LoDBContext.eva_Curriculo_Referencias
                    where referencia.IdReferencia == FicInsertReferencia.IdReferencia
                    select referencia).FirstOrDefaultAsync();

                if(FicSourceReferenciaExist == null)
                {
                    FicInsertReferencia.FechaReg = DateTime.Today;
                    FicInsertReferencia.FechaUltMod = DateTime.Today;
                    FicInsertReferencia.UsuarioReg = "Alegria";
                    FicInsertReferencia.UsuarioMod = "Alegria";
                    FicInsertReferencia.Activo = "S";
                    FicInsertReferencia.Borrado = "N";
                    await LoDBContext.AddAsync(FicInsertReferencia);
                }
                else
                {
                    FicInsertReferencia.IdReferencia = FicInsertReferencia.IdReferencia;
                    FicInsertReferencia.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourceReferenciaExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertReferencia);
                }
                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta - srv", e.Message.ToString(), "ok");
            }
        }//insert

        public async Task FicMetDeleteReferencia(Eva_curriculo_referencias deleteReferencia)
        {
            using(IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if(await ExistReferencia(deleteReferencia))
                    {
                        await new Page().DisplayAlert("alerta", "no se encontró registro", "ok");
                        return;
                    }

                    LoDBContext.Entry(deleteReferencia).State = EntityState.Detached;
                    LoDBContext.Remove(deleteReferencia);
                    await LoDBContext.SaveChangesAsync();

                    transaction.Commit();
                    return;

                }catch(Exception e)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("alerta - delete", e.Message.ToString(), "ok");

                }
            }

            
        }//delete

        private async Task<bool> ExistReferencia(Eva_curriculo_referencias existReferencia)
        {
            return await (from referencia in LoDBContext.eva_Curriculo_Referencias
                          where referencia.IdReferencia == existReferencia.IdReferencia
                          select referencia).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }
    }
}
