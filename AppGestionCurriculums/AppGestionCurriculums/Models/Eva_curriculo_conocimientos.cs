using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_conocimientos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdConocimiento { get; set; }
        public string DesConocimiento { get; set; }
        public string Detalle { get; set; }
        public float Dominio { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }

        //Fk
        public Eva_curriculo_persona Curriculos { get; set; }
        public Int16 IdCurriculo { get; set; }

        public Int16 IdCompetencia { get; set; }
        public Eva_curriculo_competencias Competencia { get; set; }
        public List<Eva_curriculo_herramientas> Herramientas { get; set; }
    }
}