using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Rh_cat_telefonos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdTelefono { get; set; }
        [StringLength(2)]
        public string CodPais { get; set; }
        [StringLength(20)]
        public string NumTelefono { get; set; }
        [StringLength(30)]
        public string NumExtension { get; set; }
        [StringLength(1)]
        public string Principal { get; set; }
        [StringLength(50)]
        public string ClaveReferencia { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }
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
    }
}
