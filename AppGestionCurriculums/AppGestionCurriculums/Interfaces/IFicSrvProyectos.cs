﻿using AppGestionCurriculums.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCurriculums.Interfaces
{
    public interface IFicSrvProyectos
    {
        Task<IEnumerable<Eva_proyectos>> FicMetGetListProyectos(Eva_experiencia_laboral experiencia);
        Task FicMetInsertNewProyecto(Eva_proyectos FicPaProyecto);
        Task FicMetDeleteProyecto(Eva_proyectos FicPaProyecto);
    }
}
