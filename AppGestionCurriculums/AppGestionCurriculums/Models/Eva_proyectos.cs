using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_proyectos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdProyecto { get; set;}
        public string NombreProyecto { get; set; }
        public string Siglas { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string Herramientas { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        
        //FK's
        public Int16 IdCurriculo { get; set; }

        public Eva_experiencia_laboral Experiencia { get; set; }
        public Int16 IdExperiencia { get; set; }

        public Int16 IdTipoEstatus { get; set; }
        public Int16 IdEstatus { get; set; }
    }
}
