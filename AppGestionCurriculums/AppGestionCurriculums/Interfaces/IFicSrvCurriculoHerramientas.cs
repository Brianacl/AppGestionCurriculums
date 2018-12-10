using System.Collections.Generic;
using System.Threading.Tasks;
using AppGestionCurriculums.Models;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvCurriculoHerramientas
    {
        Task<IEnumerable<Eva_curriculo_herramientas>> FicMetGetListHerramientas(Eva_curriculo_conocimientos conocimiento);
        Task FicMetInsertNewHerramienta(Eva_curriculo_herramientas FicPaHerramientas);
        Task FicMetDeleteHerramienta(Eva_curriculo_herramientas FicPaHerramientas);
    }
}
