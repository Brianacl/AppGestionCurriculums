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
    class FicSrvExperienciaLaboral : IFicSrvExperienciaList
    {
        private readonly FicDBContext LoDbContext;

        public FicSrvExperienciaLaboral()
        {
            LoDbContext = new FicDBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
        }

        public async Task FicMetInsertNewExperiencia(Eva_experiencia_laboral FicMetInsertExperiencia)
        {
            try
            {
                var FicSourceExperienciaExist = await (
                    from experiencias in LoDbContext.eva_Experiencia_Laborals
                    where experiencias.IdExperiencia == FicMetInsertExperiencia.IdExperiencia
                    select experiencias).FirstOrDefaultAsync();
                if (FicSourceExperienciaExist == null)
                {
                    //curriculo experiencia desorganizacion siglas fechareg usuarioreg
                    FicMetInsertExperiencia.FechaReg = DateTime.Today;
                    FicMetInsertExperiencia.UsuarioReg = "Alegria";
                    FicMetInsertExperiencia.Activo = "S";
                    FicMetInsertExperiencia.Borrado = "N";
                    FicMetInsertExperiencia.FechaUltMod = DateTime.Today;

                    await LoDbContext.AddAsync(FicMetInsertExperiencia);

                }
                else
                {

                    FicMetInsertExperiencia.IdExperiencia = FicSourceExperienciaExist.IdExperiencia;
                    FicMetInsertExperiencia.FechaUltMod = DateTime.Now;
                    LoDbContext.Entry(FicSourceExperienciaExist).State = EntityState.Detached;
                    LoDbContext.Update(FicMetInsertExperiencia);
                }
                await LoDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
            }
        }//insertar

        public async Task FicMetDeleteExperiencia(Eva_experiencia_laboral deleteExperiencia)
        {
            using (IDbContextTransaction transaction = LoDbContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistExperiencia(deleteExperiencia))
                    {
                        await new Page().DisplayAlert("alerta", "no se encontro el registro", "okk");
                        return;
                    }
                    LoDbContext.Entry(deleteExperiencia).State = EntityState.Detached;
                    LoDbContext.Remove(deleteExperiencia);
                    await LoDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await new Page().DisplayAlert("alerta", e.Message.ToString(), "ok");
                }
            }
        }

        private async Task<bool> ExistExperiencia(Eva_experiencia_laboral existExperiencia)
        {
            return await (from experiencia in LoDbContext.eva_Experiencia_Laborals
                          where experiencia.IdExperiencia == existExperiencia.IdExperiencia
                          select experiencia).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }

        public async Task<IEnumerable<Eva_experiencia_laboral>> FicMetGetListExperiencia()
        {
            return await(from Eva_experiencia_laboral in LoDbContext.eva_Experiencia_Laborals select Eva_experiencia_laboral).AsNoTracking().ToListAsync();
        }
    }
}
