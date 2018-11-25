using System.Collections.Generic;
using System.Threading.Tasks;
using AppGestionCurriculums.Models;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvGradoEstudios
    {
        Task<IEnumerable<Eva_carrera_grado_estudios>> FicMetGetListGradoEstudios();
        Task FicMetInsertNewEdificio(Eva_carrera_grado_estudios FicPaGradoEstudios);
        Task FicMetDeleteEdificio(Eva_carrera_grado_estudios FicPaGradoEstudios);
    }
}
