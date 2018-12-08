using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_carrera_grado_estudios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdGradoEstudio { get; set; }
        public string NombreEstudioCarrera { get; set; }
        public string NombreEscuela { get; set; }
        public DateTime PeriodoIni { get; set; }
        public DateTime PeriodoFin { get; set; }
        public char UltimoGradoEstudio { get; set; }
        public string PrefijoEstudio { get; set; }
        public Int16 IdTipoEstatus { get; set; } //FK
        public Int16 IdEstatus { get; set; } //FK
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }

        public Int16 IdTipoGenGradoEstudio { get; set; } //FK
        public Int16 IdGenGradoEstudio { get; set; } //FK
        public Int16 IdCurriculo { get; set; } //FK
    }
}
