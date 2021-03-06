﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AppGestionCurriculums.Models;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvCurriculoIdiomas
    {
        Task<IEnumerable<Eva_curriculo_idiomas>> FicMetGetListIdiomas(Eva_curriculo_persona curriculo);
        Task FicMetInsertNewIdioma(Eva_curriculo_idiomas FicPaGradoIdiomas);
        Task FicMetDeleteIdioma(Eva_curriculo_idiomas FicPaIdiomas);
    }
}
