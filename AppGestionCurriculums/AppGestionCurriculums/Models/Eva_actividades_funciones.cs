using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_actividades_funciones
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdFuncionAct { get; set; }
        public string DesActividad { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }

        public Int16 IdCurriculo { get; set; } //FK
        public Int16 IdExperiencia { get; set; }//FK
    }
}
