using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_experiencia_laboral
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdExperiencia { get; set; }
        [StringLength(20)]
        public Int16 IdCurriculo { get; set; }//fk
        [StringLength(20)]
        public string DesOrganizacion { get; set; }
        [StringLength(1000)]
        public string Detalle { get; set; }
        [StringLength(20)]
        public string Siglas { get; set; }
        
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        [StringLength(20)]
        public Int16 IdTipoGenGiro { get; set; } //fk no se de donde 
        [StringLength(20)]
        public Int16 IdGenGiro { get; set; } //fk no se de donde
        
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
        
    }
}
