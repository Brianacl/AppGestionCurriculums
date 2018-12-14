using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Tipo_gen_parentezco_referencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTipoGeneral { get; set; }
        public Int16 IdGeneral { get; set; }
        public string DesGeneral { get; set; }

        public List<Eva_curriculo_referencias> curriculoReferencias { get; set; }
    }
}
