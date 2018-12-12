using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_experiencia_laboral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdExperiencia { get; set; }
        [StringLength(100)]
        public string DesOrganizacion { get; set; }
        [StringLength(1000)]
        public string Detalle { get; set; }
        [StringLength(20)]
        public string Siglas { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public Int16 IdTipoGenGiro { get; set; } //fk no se de donde
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

        //FK
        public Eva_curriculo_persona eva_Curriculo_Persona { get; set; }
        public Int16 IdCurriculo { get; set; }

        public List<Eva_actividades_funciones> Funciones { get; set; }
        public List<Eva_proyectos> Proyectos { get; set; }

        public Tipo_gen_giro_experienciaLaboral tipoGenExperienciaLaboral { get; set; }
        public Int16 IdGenTipo { get; set; }
        public Int16 IdGenExperienciaLaboral { get; set; } //FK
    }
}
