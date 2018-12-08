using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces.Competencias
{
    public interface IFicSrvCompetencias
    {
        Task<IEnumerable<Eva_curriculo_competencias>> FicMetGetListCompetencias(Rh_cat_personas personas); 
        Task FicMetInsertCompetencias(Eva_curriculo_competencias FicPaCompetencias);
        Task FicMetDeleteCompetencias(Eva_curriculo_competencias FicPaCompetencias);
    }
}
