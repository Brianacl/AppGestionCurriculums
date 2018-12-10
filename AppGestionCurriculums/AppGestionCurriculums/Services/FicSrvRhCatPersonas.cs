using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces;
using AppGestionCurriculums.Interfaces.SQLite;
using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppGestionCurriculums.Services
{
    class FicSrvRhCatPersonas : IFicSrvRhCatPersonas
    {
        private readonly DBContext LoDBContext;
        private bool nuevaPersona = false;

        public FicSrvRhCatPersonas()
        {
            LoDBContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());
        }//Fin del constructor

        public async Task<IEnumerable<Rh_cat_personas>> FicMetGetListPersonas()
        {
            return await (from rh_cat_personas in LoDBContext.rh_cat_personas select rh_cat_personas).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertNewPersona(Rh_cat_personas FicInsertPersona)
        {
            try
            {
                var FicSourcePersonaExist = await (
                       from personas in LoDBContext.rh_cat_personas
                       where personas.IdPersona == FicInsertPersona.IdPersona
                       select personas
                        ).FirstOrDefaultAsync();

                if (FicSourcePersonaExist == null)
                {

                    FicInsertPersona.FechaReg = DateTime.Now;
                    FicInsertPersona.FechaUltMod = DateTime.Now;
                    FicInsertPersona.UsuarioReg = "Beth";
                    FicInsertPersona.UsuarioMod = "Beth";
                    FicInsertPersona.Activo = "S";
                    FicInsertPersona.Borrado = "N";

                    await LoDBContext.AddAsync(FicInsertPersona);
                    nuevaPersona = true;

                }
                else
                {
                    FicInsertPersona.IdPersona = FicSourcePersonaExist.IdPersona;
                    FicInsertPersona.FechaUltMod = DateTime.Now;
                    LoDBContext.Entry(FicSourcePersonaExist).State = EntityState.Detached;
                    LoDBContext.Update(FicInsertPersona);
                    nuevaPersona = false;
                }

                await LoDBContext.SaveChangesAsync();

                if(nuevaPersona)
                {
                    System.Diagnostics.Debug.WriteLine(UltimaPersona());
                    CrearCurriculo(UltimaPersona());
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }
        }//Insertar nuevo

        public async Task FicMetDeletePersona(Rh_cat_personas deletePersona)
        {
            using (IDbContextTransaction transaction = LoDBContext.Database.BeginTransaction())
            {
                try
                {
                    if (await ExistPersona(deletePersona))
                    {
                        await new Page().DisplayAlert("ALERTA", "No se encontró el registro", "OK");
                        return;
                    }//BUSCAR SI YA SE INSERTO UN REGISTRO

                    LoDBContext.Entry(deletePersona).State = EntityState.Detached;
                    LoDBContext.Remove(deletePersona);
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

        private async Task<bool> ExistPersona(Rh_cat_personas existPersona)
        {
            return await (from personas in LoDBContext.rh_cat_personas
                          where personas.IdPersona == existPersona.IdPersona
                          select personas).AsNoTracking().SingleOrDefaultAsync() == null ? true : false;
        }//BUSCA SI EXISTE UN REGISTRO

        private int UltimaPersona()
        {
            return  (from personas in LoDBContext.rh_cat_personas
                          select personas.IdPersona).Max();
        }//BUSCA ULTIMO ID

        private async void CrearCurriculo(int idPersona)
        {
            var nuevoCurriculo = new Eva_curriculo_persona();
            nuevoCurriculo.FechaReg = DateTime.Now;
            nuevoCurriculo.FechaUltMod = DateTime.Now;
            nuevoCurriculo.UsuarioReg = "Beth";
            nuevoCurriculo.UsuarioMod = "Beth";
            nuevoCurriculo.Activo = "S";
            nuevoCurriculo.Borrado = "N";
            nuevoCurriculo.IdPersona = (Int16) idPersona;

            await LoDBContext.AddAsync(nuevoCurriculo);
            await LoDBContext.SaveChangesAsync();
        }
    }
}
