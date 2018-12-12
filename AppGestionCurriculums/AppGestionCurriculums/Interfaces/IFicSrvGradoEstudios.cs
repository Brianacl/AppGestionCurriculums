using System.Collections.Generic;
using System.Threading.Tasks;
using AppGestionCurriculums.Models;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvGradoEstudios
    {
        Task<IEnumerable<Eva_carrera_grado_estudios>> FicMetGetListGradoEstudios(Eva_curriculo_persona curriculo);
        Task FicMetInsertNewGradoEstudios(Eva_carrera_grado_estudios FicPaGradoEstudios);
        Task FicMetDeleteGradoEstudios(Eva_carrera_grado_estudios FicPaGradoEstudios);
        Task<IEnumerable<Tipo_gen_grado_estudio>> FicMetGetListTipoGradoEstudio();
        Task<IEnumerable<Estatus_grado_estudios>> FicMetGetListEstatusGradoEstudio();
    }
}
