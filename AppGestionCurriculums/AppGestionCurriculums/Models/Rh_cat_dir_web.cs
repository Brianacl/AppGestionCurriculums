using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Rh_cat_dir_web
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdDirWeb { get; set; }
        public string DesDirWeb { get; set; }
        public string DireccionWeb { get; set; }
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
