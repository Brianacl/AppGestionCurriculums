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
            FicLoBDContext.AddData("1", "1", "1","14401007", "Betsy", "Sanchez","Carrillo","SACB9606264H6","SACB960626MNTNRT03","26/06/1996","F", DateTime.Today.ToString(), DateTime.Today.ToString(),"Beth","Beth", "1", "0");
            FicLoBDContext.AddData("2", "2", "2", "14401010", "Cristobal", "Vega", "Luna", "VELC9604124H6", "VELC960412MNTNRT03", "12/04/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData("3", "3", "3", "14400446", "Brian", "Casas", "Lopez", "CALB9603214H6", "CALB960321MNTNRT03", "21/03/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData("4", "4", "4", "14400968", "Jesus", "Monroy", "Salcedo", "MOSJ9504284H6", "MOSJ950428MNTNRT03", "28/04/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData("5", "5", "5", "14400941", "Jorge", "Alegria", "Jimenez", "ALJJ9601204H6", "ALJJ960120MNTNRT03", "20/01/1996", "M", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData2("1", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData2("2", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData2("3", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData2("4", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
            FicLoBDContext.AddData2("5", DateTime.Today.ToString(), DateTime.Today.ToString(), "Beth", "Beth", "1", "0");
        }//Fin del constructor

        public async Task<IEnumerable<Rh_cat_personas>> FicMetGetListCurriculumsPersonas()
        {
            return await (from eva_curriculo_persona in FicLoBDContext.rh_cat_personas select eva_curriculo_persona).AsNoTracking().ToListAsync();
        }
        
    }
}
