using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvReferencias
    {
        Task<IEnumerable<Eva_curriculo_referencias>> FicMetGetListReferencias(Eva_curriculo_persona curriculo);
        Task FicMetInsertNewReferencia(Eva_curriculo_referencias FicPaReferencias);
        Task FicMetDeleteReferencia(Eva_curriculo_referencias FicPaReferencias);
    }
}
