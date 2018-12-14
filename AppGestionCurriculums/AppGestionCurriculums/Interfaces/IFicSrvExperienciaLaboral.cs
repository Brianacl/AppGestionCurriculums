using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvExperienciaLaboral
    {
        Task<IEnumerable<Eva_experiencia_laboral>> FicMetGetListExperiencias(Eva_curriculo_persona curriculo);
        Task FicMetInsertNewExperiencia(Eva_experiencia_laboral FicPaExperiencia);
        Task FicMetDeleteExperiencia(Eva_experiencia_laboral FicPaExperiencias);
        Task<IEnumerable<Tipo_gen_giro_experienciaLaboral>> FicMetGetListTipoGiroExperienciaLaboral();
    }
}
