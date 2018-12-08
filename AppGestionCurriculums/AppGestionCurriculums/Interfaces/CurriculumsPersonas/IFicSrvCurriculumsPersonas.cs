using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces.CurriculumsPersonas
{
    public interface IFicSrvCurriculumsPersonas
    {
        Task<IEnumerable<Rh_cat_personas>> FicMetGetListCurriculumsPersonas();
        Task FicMetInsertCurriculo(Rh_cat_personas FicPaCurriculo);
        Task<Rh_cat_domicilios> FicMetObtenerDomicilio(Rh_cat_personas FicPaDomicilio);
        Task<Rh_cat_dir_web> FicMetObtenerDirWeb(Rh_cat_personas FicPaDirWeb);
        Task<Rh_cat_telefonos> FicMetObtenerTelefono(Rh_cat_personas FicPaTelefono);

        //Task<IEnumerable<Eva_curriculo_competencias>> FicMetObtenerCompetencias(Rh_cat_personas FicPaCompetencias);
    }
}
