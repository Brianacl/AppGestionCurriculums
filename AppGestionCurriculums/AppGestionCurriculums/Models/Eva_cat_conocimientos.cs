using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_cat_conocimientos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdConocimiento { get; set; }
        public Int16 IdCompetencia { get; set; } // FK
        [StringLength(255)]
        public string DesConocimiento { get; set; }
        [StringLength(3000)]
        public string Detalle { get; set; }

        public Eva_cat_competencias eva_cat_competencias { get; set; }
        public List<Eva_curriculo_conocimientos> listConocimientos { get; set; }
        
    }
}
