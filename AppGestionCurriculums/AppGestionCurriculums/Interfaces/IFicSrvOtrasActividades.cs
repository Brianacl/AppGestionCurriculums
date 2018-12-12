using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvOtrasActividades
    {
        Task<IEnumerable<Eva_curriculo_otras_actividades>> FicMetGetListOtrasActividades(Eva_curriculo_persona curriculo);
        Task FicMetInsertNewOtraActividad(Eva_curriculo_otras_actividades FicPaOtraActividad);
        Task FicMetDeleteOtraActividad(Eva_curriculo_otras_actividades FicPaOtraActividad);
    }
}
