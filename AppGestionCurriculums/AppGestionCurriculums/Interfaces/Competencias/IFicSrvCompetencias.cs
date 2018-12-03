using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces.Competencias
{
    public interface IFicSrvCompetencias
    {
        Task<IEnumerable<Eva_curriculo_competencias>> FicMetGetListCompetencias();
        Task FicMetInsertCompetencia(Eva_curriculo_competencias FicPaCompetencias);
        //Task FicMetUpdateCompetencia(Eva_curriculo_competencias ficPa_Eva_curriculo_competencias);
        Task FicMetDeleteCompetencia(Eva_curriculo_competencias FicPaCompetencias);
    }
}
