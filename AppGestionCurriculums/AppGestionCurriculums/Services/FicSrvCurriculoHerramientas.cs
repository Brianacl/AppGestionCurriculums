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
    public class FicSrvCurriculoHerrmaientas : IFicSrvCurriculoHerramientas
    {
        private readonly DBContext LoDBContext;

        public FicSrvCurriculoHerrmaientas()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }

        public async Task<IEnumerable<Eva_curriculo_herramientas>> FicMetGetListHerramientas(Eva_curriculo_conocimientos conocimiento)
        {
            return await(from eva_curriculo_herramientas in LoDBContext.eva_curriculo_herramientas
                         where eva_curriculo_herramientas.IdConocimientoDet == conocimiento.IdConocimientoDet
                         select eva_curriculo_herramientas).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewHerramienta(Eva_curriculo_herramientas FicPaHerramientas)
        {
            try
            {
                var FicSourceHerramientaExist = await(
                       from herramientas in LoDBContext.eva_curriculo_herramientas
                       where herramientas.IdHerramienta == FicPaHerramientas.IdHerramienta
                       select herramientas
                        ).FirstOrDefaultAsync();

                if (FicSourceHerramientaExist == null)
                {
                    var IdHerramienta = ultimoRegistro();
                    FicPaHerramientas.IdHerramienta = (short)++IdHerramienta;
                    FicPaHerramientas.FechaReg = DateTime.Today;
                    FicPaHerramientas.FechaUltMod = DateTime.Today;
                    FicPaHerramientas.UsuarioReg = "Jesus Monroy";
                    FicPaHerramientas.UsuarioMod = "Jesus Monroy";
                    FicPaHerramientas.Activo = 'S';
                    FicPaHerramientas.Borrado = 'N';

                    await LoDBContext.AddAsync(FicPaHerramientas);

                }
                else
                {
                    FicPaHerramientas.IdHerramienta = FicSourceHerramientaExist.IdHerramienta;
                    FicPaHerramientas.FechaUltMod = DateTime.Today;
                    LoDBContext.Entry(FicSourceHerramientaExist).State = EntityState.Detached;
                    LoDBContext.Update(FicPaHerramientas);
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
            if (LoDBContext.eva_curriculo_herramientas.Count() == 0)
            {
                return 0;
            }
            return LoDBContext.eva_curriculo_herramientas.Max(r => r.IdHerramienta);
        }

        public async Task FicMetDeleteHerramienta(Eva_curriculo_herramientas FicPaHerramientas)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistHerramienta(FicPaHerramientas))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }

                    LoDBContext.Entry(FicPaHerramientas).State = EntityState.Detached;
                    LoDBContext.Remove(FicPaHerramientas);
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

        private async Task<bool> ExistHerramienta(Eva_curriculo_herramientas existHerramienta)
        {
            return await (from herramienta in LoDBContext.eva_curriculo_herramientas
                          where herramienta.IdHerramienta == existHerramienta.IdHerramienta
                          select herramienta).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }

        public async Task<IEnumerable<Tipo_gen_herramienta>> FicMetGetListTipoHerramienta()
        {
            return await(from tipoHerramientas in LoDBContext.tipo_gen_herramienta
                         select tipoHerramientas).AsNoTracking().ToListAsync();
        }
    }
}
