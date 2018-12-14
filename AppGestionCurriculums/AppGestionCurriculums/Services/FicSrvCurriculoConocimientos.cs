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
    public class FicSrvCurriculoConocimientos : IFicSrvCurriculoConocimientos
    {
        private readonly DBContext LoDBContext;

        public FicSrvCurriculoConocimientos()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }
        

        public async Task<IEnumerable<Eva_curriculo_conocimientos>> FicMetGetListConocimientos(Eva_curriculo_competencias competencia)
        {
            return await(from eva_curriculo_conocimientos in LoDBContext.eva_curriculo_conocimientos
                         where eva_curriculo_conocimientos.IdCurriculoCompetencia == competencia.IdCompetenciaCurriculum
                         select eva_curriculo_conocimientos).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Eva_cat_conocimientos>> FicMetGetListConocimientos()
        {
            return await (from conocimientos in LoDBContext.eva_cat_conocimientos
                          select conocimientos).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewConocimiento(Eva_curriculo_conocimientos FicPaConocimientos)
        {
            try
            {
                var FicSourceConocimientoExist = await(
                       from conocimientos in LoDBContext.eva_curriculo_conocimientos
                       where conocimientos.IdConocimientoDet == FicPaConocimientos.IdConocimientoDet
                       select conocimientos
                        ).FirstOrDefaultAsync();

                if (FicSourceConocimientoExist == null)
                {
                    var IdConocimientoDet = ultimoRegistro();
                    FicPaConocimientos.IdConocimientoDet = (short)IdConocimientoDet++;
                    FicPaConocimientos.FechaReg = DateTime.Today;
                    FicPaConocimientos.FechaUltMod = DateTime.Today;
                    FicPaConocimientos.UsuarioReg = "Jesus Monroy";
                    FicPaConocimientos.UsuarioMod = "Jesus Monroy";
                    FicPaConocimientos.Activo = 'S';
                    FicPaConocimientos.Borrado = 'N';

                    await LoDBContext.AddAsync(FicPaConocimientos);

                }
                else
                {
                    FicPaConocimientos.IdConocimientoDet = FicSourceConocimientoExist.IdConocimientoDet;
                    FicPaConocimientos.FechaUltMod = DateTime.Today;
                    LoDBContext.Entry(FicSourceConocimientoExist).State = EntityState.Detached;
                    LoDBContext.Update(FicPaConocimientos);
                }

                await LoDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }
        private int ultimoRegistro()
        {
            if (LoDBContext.eva_curriculo_conocimientos.Count() == 0)
            {
                return 0;
            }
            return LoDBContext.eva_curriculo_conocimientos.Max(r => r.IdConocimientoDet);
        }
        public async Task FicMetDeleteConocimiento(Eva_curriculo_conocimientos FicPaConocimientos)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistConocimiento(FicPaConocimientos))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }

                    LoDBContext.Entry(FicPaConocimientos).State = EntityState.Detached;
                    LoDBContext.Remove(FicPaConocimientos);
                    await LoDBContext.SaveChangesAsync();

                    transaction.Commit();
                    return;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("ALERTA - SrvDelete", ex.Message.ToString(), "OK");
                }
            }
        }

        private async Task<bool> ExistConocimiento(Eva_curriculo_conocimientos existConocimiento)
        {
            return await (from conocimiento in LoDBContext.eva_curriculo_conocimientos
                          where conocimiento.IdConocimientoDet == existConocimiento.IdConocimientoDet
                          select conocimiento).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }

        public async Task<IEnumerable<string>> FicMetGetListCatConocimientos()
        {
            return await(from CatConocimientos in LoDBContext.eva_cat_conocimientos
                          select CatConocimientos.DesConocimiento).AsNoTracking().ToListAsync();
        }

        public async Task<Eva_cat_conocimientos> FicMetObtenerIdsConocimientos(string FicPaConocimientos)
        {
            return await(from conocimientos in LoDBContext.eva_cat_conocimientos
                         where conocimientos.DesConocimiento == FicPaConocimientos
                         select conocimientos).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<Eva_cat_conocimientos> FicMetObtenerNombreConocimientos(short idCono)
        {
            return await(from conocimientos in LoDBContext.eva_cat_conocimientos
                         where conocimientos.IdConocimiento == idCono
                         select conocimientos).AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
