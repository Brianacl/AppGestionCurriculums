using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Rh_cat_domicilios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdDomicilio { get; set; }
        [StringLength(20)]
        public string Domicilio { get; set; }
        [StringLength(150)]
        public string EntreCalle1 { get; set; }
        [StringLength(150)]
        public string EntreCalle2 { get; set; }
        [StringLength(10)]
        public string CodigoPostal { get; set; }
        [StringLength(255)]
        public string Coordenadas { get; set; }
        [StringLength(1)]
        public string Principal { get; set; }
        [StringLength(50)]
        public string Pais { get; set; }
        [StringLength(50)]
        public string Estado { get; set; }
        [StringLength(50)]
        public string Municipio { get; set; }
        [StringLength(50)]
        public string Localidad { get; set; }
        [StringLength(100)]
        public string Colonia { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }
        [StringLength(50)]
        public string ClaveReferencia { get; set; }
        [StringLength(1)]
        public string TipoDomicilio { get; set; }
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
