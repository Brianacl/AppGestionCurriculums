using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_cat_competencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCompetencia { get; set; }       
        public string DesCompetencia { get; set; }
        [StringLength(255)]
        public string Detalle { get; set; }

        //FK
        public Int16 IdTipoCompetencia { get; set; }
        public Eva_cat_tipo_competencias eva_cat_tipo_competencias { get; set; }
        public List<Eva_curriculo_competencias> curriculoCompetencias { get; set; }
        public List<Eva_cat_conocimientos> Conocimientos { get; set; }
    }
}
