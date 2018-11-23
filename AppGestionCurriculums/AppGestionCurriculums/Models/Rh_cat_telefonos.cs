using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Rh_cat_telefonos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTelefono { get; set; }
        public string NumTelefono { get; set; }
        public string NumExtension { get; set; }
        public string Principal { get; set; }
        public string ClaveReferencia { get; set; }
        public string Referencia { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
