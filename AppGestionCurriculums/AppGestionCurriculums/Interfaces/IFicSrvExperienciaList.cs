using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.Models;
using System.Threading.Tasks;
namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvExperienciaList
    {
        Task<IEnumerable<Eva_experiencia_laboral>> FicMetGetListExperiencia();
        Task FicMetInsertNewExperiencia(Eva_experiencia_laboral FicPaExperiencia);
        Task FicMetDeleteExperiencia(Eva_experiencia_laboral FicPaExperiencia);
        
    }
}
