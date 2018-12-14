using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces.Competencias
{
    public interface IFicSrvCompetencias
    {
        Task<IEnumerable<Eva_curriculo_competencias>> FicMetGetListCompetencias(Eva_curriculo_persona curriculo);
        Task FicMetInsertCompetencias(Eva_curriculo_competencias FicPaCompetencias);
        Task FicMetDeleteCompetencias(Eva_curriculo_competencias FicPaCompetencias);
        Task<IEnumerable<string>> FicMetGetListCatCompetencias();
        Task<Eva_cat_competencias> FicMetObtenerIdsCompetencias(string FicPaCompetencias);
        Task<Eva_cat_competencias> FicMetObtenerNombreCompetencias(short idComp);
    }
}
