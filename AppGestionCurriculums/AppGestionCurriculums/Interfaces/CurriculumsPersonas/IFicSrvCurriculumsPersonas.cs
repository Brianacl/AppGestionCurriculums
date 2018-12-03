using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces.CurriculumsPersonas
{
    public interface IFicSrvCurriculumsPersonas
    {
        Task<IEnumerable<Rh_cat_personas>> FicMetGetListCurriculumsPersonas();
        //Task FicMetInsertCurriculumPersona(Eva_curriculo_persona FicPaCurriculoPersona);
        //Task FicMetUpdateCurriculumPersona(Eva_curriculo_persona ficPa_Eva_curriculo_persona);
        //Task FicMetDeleteCurriculumPersona(Eva_curriculo_persona FicPaCurriculoPersona);
    }
}
