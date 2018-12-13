using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvFunciones
    {
        Task<IEnumerable<Eva_actividades_funciones>> FicMetGetListFunciones(Eva_experiencia_laboral experiencia);
        Task FicMetInsertNewFuncion(Eva_actividades_funciones FicPaFuncion);
        Task FicMetDeleteFuncion(Eva_actividades_funciones FicPaFuncion);
    }
}
