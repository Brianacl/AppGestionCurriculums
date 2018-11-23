using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCurriculo { get; set; }
        public Int16 IdPersona { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
