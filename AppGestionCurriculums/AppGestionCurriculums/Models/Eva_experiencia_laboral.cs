using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_experiencia_laboral
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }

        //FK
        public Eva_curriculo_persona eva_Curriculo_Persona { get; set; }
        public Int16 IdCurriculo { get; set; }

        public List<Eva_actividades_funciones> Funciones { get; set; }
        public List<Eva_proyectos> Proyectos { get; set; }
    }
}
