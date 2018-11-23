using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Rh_cat_personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdPersona { get; set; }
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string FechaNac { get; set; }
        public string TipoPersona { get; set; }
        public string Sexo { get; set; }
        public string RutaFoto { get; set; }
        public string Alias { get; set; }

    }
}
