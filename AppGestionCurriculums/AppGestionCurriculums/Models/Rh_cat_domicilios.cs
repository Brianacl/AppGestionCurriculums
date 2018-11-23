using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Rh_cat_domicilios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdDomicilio { get; set; }
        public string Domicilio { get; set; }
        public string EntreCalle1 { get; set; }
        public string EntreCalle2 { get; set; }
        public string CodigoPostal { get; set; }
        public string Coordenadas { get; set; }
        public string Principal { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public string Colonia { get; set; }
        public string Referencia { get; set; }
        public string ClaveReferencia { get; set; }
        public string TipoDomicilio { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
