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
        public Int16 IdCurriculo { get; set; }
        public Int16 IdExperiencia { get; set; }
        public string DesOrganizacion { get; set; }
        public string Detalle { get; set; }
        public string Siglas { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public Int16 IdTipoGenGiro { get; set; } //fk no se de donde 
        public Int16 IdGenGiro { get; set; } //fk no se de donde
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsurioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
