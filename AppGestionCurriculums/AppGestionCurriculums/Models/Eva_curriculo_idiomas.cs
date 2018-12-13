using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_idiomas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdIdioma { get; set; } //PK
        [StringLength(200)]
        public string DesIdioma { get; set; }
        public float Dominio { get; set; }
        [StringLength(1)]
        public char Nativo { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public char Activo { get; set; }
        [StringLength(1)]
        public char Borrado { get; set; }

        public Int16 IdCurriculo { get; set; } //Foreign key
        public Eva_curriculo_persona eva_Curriculo_Persona { get; set; }
    }
}
