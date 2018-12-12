using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_otras_actividades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdActividad { get; set; } //PK
        [StringLength(255)]
        public string DesActividad { get; set; }
        [StringLength(255)]
        public string Observaciones { get; set; }
        
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public char Activo { get; set; }
        [StringLength(1)]
        public char Borrado { get; set; }

        //Fk
        public Eva_curriculo_persona eva_Curriculo_Persona { get; set; }
        public Int16 IdCurriculo { get; set; } //Foreign key
    }
}
