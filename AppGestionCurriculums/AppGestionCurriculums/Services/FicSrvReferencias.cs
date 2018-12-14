using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppGestionCurriculums.Services
{
    class FicSrvReferencias : IFicSrvReferencias
    {
        private readonly DBContext LoDBContext;

        public FicSrvReferencias()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }

        public async Task<IEnumerable<Eva_curriculo_referencias>> FicMetGetListReferencias(Eva_curriculo_persona curriculo)
        {
            return await (from Eva_curriculo_referencias in LoDBContext.eva_curriculo_referencias
                          where Eva_curriculo_referencias.IdCurriculo == curriculo.IdCurriculo
                          select Eva_curriculo_referencias).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Tipo_gen_parentezco_referencias>> FicMetGetListTipoParentezcoReferencias()
        {
            return await (from parentezco in LoDBContext.tipo_gen_parentezco_referencias
                          select parentezco).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewReferencia(Eva_curriculo_referencias FicInsertReferencia)
        {
            try
            {
                var FicSourceReferenciaExist = await (
                    from referencia in LoDBContext.eva_curriculo_referencias
                    where referencia.IdReferencia == FicInsertReferencia.IdReferencia
                    select referencia).FirstOrDefaultAsync();

                if (FicSourceReferenciaExist == null)
                {
                    var IdReferencia = ultimaReferencia();
                    FicInsertReferencia.IdReferencia = (short)++IdReferencia;
                    FicInsertReferencia.FechaReg = DateTime.Now;
                    FicInsertReferencia.FechaUltMod = DateTime.Now;
                    FicInsertReferencia.UsuarioReg = "Alegria";
                    FicInsertReferencia.UsuarioMod = "Alegria";
                    FicInsertReferencia.Activo = "S";
                    FicInsertReferencia.Borrado = "N";
                    FicInsertReferencia.IdGenTipo = 1;
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
                if (e.InnerException != null)
                    System.Diagnostics.Debug.WriteLine(e.InnerException);
            }
        }//insert

        public async Task FicMetDeleteReferencia(Eva_curriculo_referencias deleteReferencia)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistReferencia(deleteReferencia))
                    {
                        await new Page().DisplayAlert("alerta", "no se encontró registro", "ok");
                        return;
                    }

                    LoDBContext.Entry(deleteReferencia).State = EntityState.Detached;
                    LoDBContext.Remove(deleteReferencia);
                    await LoDBContext.SaveChangesAsync();

                    transaction.Commit();
                    return;

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("alerta - delete", e.Message.ToString(), "ok");

                }
            }


        }//delete

        private async Task<bool> ExistReferencia(Eva_curriculo_referencias existReferencia)
        {
            return await (from referencia in LoDBContext.eva_curriculo_referencias
                          where referencia.IdReferencia == existReferencia.IdReferencia
                          select referencia).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }

        private int ultimaReferencia()
        {
            if (LoDBContext.eva_curriculo_referencias.Count() == 0)
            {
                return 0;
            }

            return LoDBContext.eva_curriculo_referencias.Max(referencia => referencia.IdReferencia);
        }
    }
}
