using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_competencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCurriculo { get; set; }
        public Int16 IdCompetencia { get; set; }
        public float Dominio { get; set; }
        public string DesCompetencia { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioUltMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
