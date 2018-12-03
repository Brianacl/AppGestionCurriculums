using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_competencias
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdCurriculo { get; set; }
        public Int16 IdCompetencia { get; set; }
        public float Dominio { get; set; }
        public string DesCompetencia { get; set; }
        public string Detalle { get; set; }
        public DateTime? FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime? FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
    }
}
