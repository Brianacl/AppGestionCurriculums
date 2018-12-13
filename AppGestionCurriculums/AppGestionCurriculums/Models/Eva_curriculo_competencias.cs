using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_competencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCompetenciaCurriculum { get; set; }
        public float Dominio { get; set; }
        [StringLength(255)]
        public string DesCompetencia { get; set; }
        [StringLength(255)]
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //FK
        public Int16 IdCurriculo { get; set; }
        public Int16 IdCompetencia { get; set; }
        public Eva_curriculo_persona eva_curriculo_persona { get; set; }
        public Eva_cat_competencias eva_cat_competencias { get; set; }
        public List<Eva_curriculo_conocimientos> Conocimientos { get; set; }
    }
}
