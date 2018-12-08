using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Rh_cat_personas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdPersona { get; set; }
        public Rh_cat_domicilios rh_cat_domicilios { get; set; }
        public Int16 IdDomicilio { get; set; }
        public Rh_cat_telefonos rh_cat_telefonos { get; set; }
        public Int16 IdTelefono { get; set; }
        public Rh_cat_dir_web rh_cat_dir_web { get; set; }
        public Int16 IdDirWeb { get; set; }
        [StringLength(20)]
        public string NumControl { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(60)]
        public string ApPaterno { get; set; }
        [StringLength(60)]
        public string ApMaterno { get; set; }
        [StringLength(15)]
        public string RFC { get; set; }
        [StringLength(25)]
        public string CURP { get; set; }
        [StringLength(25)]
        public string FechaNac { get; set; }
        [StringLength(1)]
        public string TipoPersona { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(255)]
        public string RutaFoto { get; set; }
        [StringLength(20)]
        public string Alias { get; set; }
        public DateTime? FechaReg { get; set; }
        public DateTime? FechaUltMod { get; set; }
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
