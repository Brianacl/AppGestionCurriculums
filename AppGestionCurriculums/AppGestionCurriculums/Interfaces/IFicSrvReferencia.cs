using System;
using System.Collections.Generic;
using System.Text;
using AppGestionCurriculums.Models;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvReferencia
    {
        Task<IEnumerable<Eva_curriculo_referencias>> FicMetGetListReferencias();
        Task FicMetInsertNewReferencia(Eva_curriculo_referencias FicPaReferencias);
        Task FicMetDeleteReferencia(Eva_curriculo_referencias FicPaReferencias);
    }
}
