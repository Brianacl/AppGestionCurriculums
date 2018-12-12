using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Estatus_grado_estudios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTipoEstatus { get; set; }
        public Int16 IdEstatus { get; set; }
        public string DesEstatus { get; set; }

        public List<Eva_carrera_grado_estudios> GradosEstudio { get; set; } 
    }
}
