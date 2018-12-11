using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_cat_tipo_competencias
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdTipoCompetencia { get; set; }       
        [StringLength(255)]
        public string DesTipoCompetencia { get; set; }
        [StringLength(255)]
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }       
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //FK
        //public Eva_curriculo_persona eva_curriculo_persona { get; set; }
    }
}
