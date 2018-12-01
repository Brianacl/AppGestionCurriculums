using System.Collections.Generic;
using System.Threading.Tasks;
using AppGestionCurriculums.Models;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvCurriculoConocimientos
    {
        Task<IEnumerable<Eva_curriculo_conocimientos>> FicMetGetListConocimientos();
        Task FicMetInsertNewConocimiento(Eva_curriculo_conocimientos FicPaConocimientos);
        Task FicMetDeleteConocimiento(Eva_curriculo_conocimientos FicPaConocimientos);
    }
}
