using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvEvaCurriculoPersonas
    {
        Task<IEnumerable<Eva_curriculo_persona>> FicMetGetCurriculo(Rh_cat_personas persona);
        Task FicMetInsertNewCurriculo(Eva_curriculo_persona FicPaCurriculo);
        Task FicMetDeleteCurriculo(Eva_curriculo_persona FicPaCurriculo);
    }
}
