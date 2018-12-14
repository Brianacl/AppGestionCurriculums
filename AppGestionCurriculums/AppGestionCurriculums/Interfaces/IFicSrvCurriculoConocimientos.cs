using System.Collections.Generic;
using System.Threading.Tasks;
using AppGestionCurriculums.Models;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvCurriculoConocimientos
    {
        Task<IEnumerable<Eva_curriculo_conocimientos>> FicMetGetListConocimientos(Eva_curriculo_competencias competencia);
        Task FicMetInsertNewConocimiento(Eva_curriculo_conocimientos FicPaConocimientos);
        Task FicMetDeleteConocimiento(Eva_curriculo_conocimientos FicPaConocimientos);
        Task<IEnumerable<Eva_cat_conocimientos>> FicMetGetListConocimientos();
    }
}
