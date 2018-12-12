using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Cat_estatus
    {
        public Int16 IdTipoEstatus { get; set; }
        public Int16 IdEstatus { get; set; }
        public string DesEstatus { get; set; }

        public List<Eva_proyectos> Proyectos { get; set; }
    }
}
