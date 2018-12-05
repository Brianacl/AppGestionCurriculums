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
{
    public class FicSrvCurriculumsPersonas : IFicSrvCurriculumsPersonas
    {
        private readonly FicDBContext FicLoBDContext;
        public FicSrvCurriculumsPersonas()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLite>().FicGetDataBasePath());           
            FicLoBDContext.AddDataPersonas("1", "1", "1","14401007", "Betsy", "Sanchez","Carrillo","SACB9606264H6","SACB960626MNTNRT03","26/06/1996","F", DateTime.Today.ToString(), DateTime.Today.ToString(),"Beth","Beth", "1", "0");
            FicLoBDContext.AddDataPersonas("2", "2", "2", "14401010", "Cristobal", "Vega", "Luna", "VELC9604124H6", "VELC960412MNTNRT03", "12/04/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataPersonas("3", "3", "3", "14400446", "Brian", "Casas", "Lopez", "CALB9603214H6", "CALB960321MNTNRT03", "21/03/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataPersonas("4", "4", "4", "14400968", "Jesus", "Monroy", "Salcedo", "MOSJ9504284H6", "MOSJ950428MNTNRT03", "28/04/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataPersonas("5", "5", "5", "14400941", "Jorge", "Alegria", "Jimenez", "AEJJ9601204H6", "AEJJ960120MNTNRT03", "20/01/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");

            FicLoBDContext.AddDataCurriculo("1", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataCurriculo("2", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataCurriculo("3", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataCurriculo("4", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataCurriculo("5", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");

            FicLoBDContext.AddDataDomicilio("1", "Villa de Santisteban #544", "Hume", "Apolonio", "63173", "Mexico", "Nayarit", "Tepic","Aramara", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDomicilio("2", "Ociel Sandoval #21", "Juan Flores", "Federico Loaiza", "63155", "Mexico", "Nayarit", "Tepic", "Caminera", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDomicilio("3", "Lazaro Cardenas #12", "Francisco I. Madero", "Juarez", "63174", "Mexico", "Nayarit", "Tepic", "Los Sauces", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDomicilio("4", "Rio Poo #44", "Cerrada", "Nicaragua", "63148", "Mexico", "Nayarit", "Tepic", "Villas de la paz", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDomicilio("5", "Tenochtitlan #62", "Jaime Nuno", "Fco Gonzalez Bocanegra", "63120", "Mexico", "Nayarit", "Tepic", "San José", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");

            FicLoBDContext.AddDataTelefono("1","3112593422", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataTelefono("2", "3111326895", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataTelefono("3", "3111610756", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataTelefono("4", "3241202612", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataTelefono("5", "3111225338", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");

            FicLoBDContext.AddDataDirWeb("1", "bedesanchezca@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDirWeb("2", "crelvegalu@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDirWeb("3", "bralcasaslo@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDirWeb("4", "jodemonroysa@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddDataDirWeb("5", "jobaalegriaji@ittepic.edu.mx", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
        }//Fin del constructor

        public async Task<IEnumerable<Rh_cat_personas>> FicMetGetListCurriculumsPersonas()
        {
            return await (from eva_curriculo_persona in FicLoBDContext.rh_cat_personas select eva_curriculo_persona).AsNoTracking().ToListAsync();
        }
        
    }
}
