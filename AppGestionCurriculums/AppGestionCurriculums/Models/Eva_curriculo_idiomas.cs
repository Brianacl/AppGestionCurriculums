using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_idiomas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdIdioma { get; set; }
        public string DesIdioma { get; set; }
        public float Dominio { get; set; }
        public bool Nativo { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        public Int16 IdCurriculo { get; set; } //Foreign key
    }
}
