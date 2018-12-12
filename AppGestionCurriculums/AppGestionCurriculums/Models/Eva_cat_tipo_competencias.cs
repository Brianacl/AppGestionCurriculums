using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_cat_tipo_competencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTipoCompetencia { get; set; }       
        [StringLength(255)]
        public string DesTipoCompetencia { get; set; }
        [StringLength(255)]
        public string Detalle { get; set; }       

        public List<Eva_cat_competencias> catCompetencias { get; set; }
    }
}
