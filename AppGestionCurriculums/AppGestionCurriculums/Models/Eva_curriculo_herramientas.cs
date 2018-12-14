using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_herramientas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdHerramienta { get; set; }
        public string DesHerramienta { get; set; }
        public string Detalle { get; set; }
        public float Dominio { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }

        public Tipo_gen_herramienta tipo_gen_herramienta { get; set; }
        public Int16 IdGenTipo { get; set; }
        public Int16 IdGenHerramienta { get; set; } //FK

        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public char Activo { get; set; }
        [StringLength(1)]
        public char Borrado { get; set; }

        public Int16 IdCurriculo { get; set; }
        public Int16 IdConocimientoDet { get; set; }
        public Int16 IdCurriculoCompetencia { get; set; }
        public Eva_curriculo_conocimientos Conocimiento { get; set; }
        public Int16 IdCompetencia { get; set; }
    }
}