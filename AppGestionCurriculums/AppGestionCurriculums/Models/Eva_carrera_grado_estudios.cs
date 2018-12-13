using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_carrera_grado_estudios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdUltimoGrado { get; set; } //Primary key
      
        public string NombreEstudioCarrera { get; set; }
        public string NombreEscuela { get; set; }
        public DateTime PeriodoIni { get; set; }
        public DateTime PeriodoFin { get; set; }
        public char UltimoGradoEstudio { get; set; }
        public string PrefijoEstudio { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public char Activo { get; set; }
        public char Borrado { get; set; }

        public Int16 IdTipoGenGradoEstudio { get; set; } //FK
        
        public Int16 IdTipoEstatus { get; set; } //FK
        public Int16 IdEstatus { get; set; } //FK

        //FK
        public Eva_curriculo_persona Eva_Curriculo_Persona { get; set; }
        public Int16 IdCurriculo { get; set; }

        public Tipo_gen_grado_estudio tipoGenGradoEstudio { get; set; }
        public Int16 IdGenTipo { get; set; }
        public Int16 IdGenGradoEstudio { get; set; } //FK
    }
}
