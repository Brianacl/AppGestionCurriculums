using AppGestionCurriculums.Data;
using AppGestionCurriculums.Interfaces.CurriculumsPersonas;
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

namespace AppGestionCurriculums.Services.CurriculumsPersonas
{ /*
    public class FicSrvCurriculumsPersonas : IFicSrvCurriculumsPersonas
    {
        private readonly DBContext FicLoBDContext;
        public FicSrvCurriculumsPersonas()
        {
            FicLoBDContext = new DBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());           
            /*
            FicLoBDContext.AddDataCurriculo(1, DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataCurriculo(2, DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataCurriculo(3, DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataCurriculo(4, DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataCurriculo(5, DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");

            FicLoBDContext.AddDataDomicilio(1, "Villa de Santisteban #544", "Hume", "Apolonio", "63173", "Mexico", "Nayarit", "Tepic","Aramara", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDomicilio(2, "Ociel Sandoval #21", "Juan Flores", "Federico Loaiza", "63155", "Mexico", "Nayarit", "Tepic", "Caminera", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDomicilio(3, "Lazaro Cardenas #12", "Francisco I. Madero", "Juarez", "63174", "Mexico", "Nayarit", "Tepic", "Los Sauces", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDomicilio(4, "Rio Poo #44", "Cerrada", "Nicaragua", "63148", "Mexico", "Nayarit", "Tepic", "Villas de la paz", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDomicilio(5, "Tenochtitlan #62", "Jaime Nuno", "Fco Gonzalez Bocanegra", "63120", "Mexico", "Nayarit", "Tepic", "San José", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");

            FicLoBDContext.AddDataTelefono(1, "3112593422", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataTelefono(2, "3111326895", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataTelefono(3, "3111610756", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataTelefono(4, "3241202612", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataTelefono(5, "3111225338", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");

            FicLoBDContext.AddDataDirWeb(1, "bedesanchezca@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDirWeb(2, "crelvegalu@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDirWeb(3, "bralcasaslo@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDirWeb(4, "jodemonroysa@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataDirWeb(5, "jobaalegriaji@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");

            FicLoBDContext.AddDataPersonas(1, 1, 1, "14401007", "Betsy", "Sanchez", "Carrillo", "SACB9606264H6", "SACB960626MNTNRT03", "26-06-1996", "F", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataPersonas(2, 2, 2, "14401010", "Cristobal", "Vega", "Luna", "VELC9604124H6", "VELC960412MNTNRT03", "12-04-1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataPersonas(3, 3, 3, "14400446", "Brian", "Casas", "Lopez", "CALB9603214H6", "CALB960321MNTNRT03", "21-03-1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataPersonas(4, 4, 4, "14400968", "Jesus", "Monroy", "Salcedo", "MOSJ9504284H6", "MOSJ950428MNTNRT03", "28-04-1995", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
            FicLoBDContext.AddDataPersonas(5, 5, 5, "14400941", "Jorge", "Alegria", "Jimenez", "AEJJ9501204H6", "AEJJ950120MNTNRT03", "20-01-1995", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "S", "N");
        }//Fin del constructor

        public async Task<IEnumerable<Rh_cat_personas>> FicMetGetListCurriculumsPersonas()
        {
            return await (from eva_curriculo_persona in FicLoBDContext.rh_cat_personas select eva_curriculo_persona).AsNoTracking().ToListAsync();
        }

        public async Task FicMetInsertCurriculo(Rh_cat_personas FicIdPersona)
        {
            try
            {
                var FicInsertCurriculo = new Eva_curriculo_persona();
                var FicSourceCurriculoExist = await (
                       from curriculo in FicLoBDContext.eva_curriculo_persona
                       where curriculo.IdPersona == FicIdPersona.IdPersona
                       select curriculo
                        ).FirstOrDefaultAsync();
                if (FicSourceCurriculoExist == null)
                {
                    //FicInsertCurriculo.IdCurriculo = idCurriculo;
                    FicInsertCurriculo.IdPersona = FicIdPersona.IdPersona;
                    FicInsertCurriculo.FechaReg = DateTime.Now;
                    FicInsertCurriculo.FechaUltMod = DateTime.Now;
                    FicInsertCurriculo.UsuarioReg = "Beth";
                    FicInsertCurriculo.UsuarioMod = "Beth";
                    FicInsertCurriculo.Activo = ActBorr(FicIdPersona.Activo);
                    FicInsertCurriculo.Borrado = ActBorr(FicIdPersona.Borrado);
                    await FicLoBDContext.AddAsync(FicInsertCurriculo);
                    await new Page().DisplayAlert("ALERTA Insert", "Se asigno curriculo a "+ FicIdPersona.Nombre, "OK");               
                }
                else
                {
                    //FicInsertCurriculo.IdCurriculo = FicSourceCurriculoExist.IdCurriculo;
                    //FicInsertCurriculo.IdPersona = FicIdPersona.IdPersona;
                    FicSourceCurriculoExist.FechaUltMod = DateTime.Now;
                    FicSourceCurriculoExist.UsuarioMod = "Beth2";
                    FicSourceCurriculoExist.Activo = ActBorr(FicIdPersona.Activo);
                    FicSourceCurriculoExist.Borrado = ActBorr(FicIdPersona.Borrado);
                    FicLoBDContext.Entry(FicSourceCurriculoExist).State = EntityState.Modified;
                    //FicLoBDContext.Entry(FicSourceCurriculoExist).State = EntityState.Detached;
                    FicLoBDContext.Update(FicSourceCurriculoExist);
                    await new Page().DisplayAlert("ALERTA Insert", "Ya existe asignacion de curriculo a " + FicIdPersona.Nombre, "OK");
                    //FicLoBDContext.Update(FicInsertCompetencias);
                }
                await FicLoBDContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA - SrvInsert", e.Message.ToString(), "OK");
            }

            string ActBorr(string toggle)
            {
                if (toggle == "True")
                {
                    return "S";
                }
                else
                {
                    return "N";
                }
            }
        }//Insertar nuevo

        public async Task<Rh_cat_domicilios> FicMetObtenerDomicilio(Rh_cat_personas persona)
        {
                var FicSourceBuscarDomicilio = await (
                       from domicilio in FicLoBDContext.rh_cat_domicilios
                       where domicilio.IdDomicilio == persona.IdDomicilio
                       select domicilio
                        ).FirstOrDefaultAsync();
            return FicSourceBuscarDomicilio;
            
        }

        public async Task<Rh_cat_dir_web> FicMetObtenerDirWeb(Rh_cat_personas persona)
        {
            var FicSourceBuscarDirWeb = await (
                   from dirWeb in FicLoBDContext.rh_cat_dir_web
                   where dirWeb.IdDirWeb == persona.IdDirWeb
                   select dirWeb
                    ).FirstOrDefaultAsync();
            return FicSourceBuscarDirWeb;

        }

        public async Task<Rh_cat_telefonos> FicMetObtenerTelefono(Rh_cat_personas persona)
        {
            var FicSourceBuscarTelefono = await (
                   from telefono in FicLoBDContext.rh_cat_telefonos
                   where telefono.IdTelefono == persona.IdTelefono
                   select telefono
                    ).FirstOrDefaultAsync();
            return FicSourceBuscarTelefono;

        }
        /*
        public async Task<IEnumerable<Eva_curriculo_competencias>> FicMetObtenerCompetencias(Rh_cat_personas persona)
        {
            return await (from Eva_curriculo_competencias in FicLoBDContext.eva_curriculo_competencias
                          join Eva_curriculo_persona in FicLoBDContext.eva_curriculo_persona on Eva_curriculo_competencias.IdCurriculo equals Eva_curriculo_persona.IdCurriculo
                          where Eva_curriculo_persona.IdPersona == persona.IdPersona
                          select Eva_curriculo_competencias).AsNoTracking().ToListAsync();
        }
    
    }*/
}
