﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Tipo_gen_grado_estudio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTipoGeneral { get; set; }
        public Int16 IdGeneral { get; set; }
        public string DesGeneral { get; set; }

        public List<Eva_carrera_grado_estudios> gradosEstudio { get; set; }
    }
}
