using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_conocimientos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdConocimientoDet { get; set; }
        public string DesConocimiento { get; set; }
        public string Detalle { get; set; }
        public float Dominio { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public char Activo { get; set; }
        public char Borrado { get; set; }

        //Fk
        public Int16 IdCurriculo { get; set; }
        public Int16 IdCompetencia { get; set; }
        public Int16 IdConocimiento { get; set; }
        public Int16 IdCurriculoCompetencia { get; set; }
        public Eva_curriculo_competencias Competencia { get; set; }
        public Eva_cat_conocimientos Conocimientos { get; set; }
        public List<Eva_curriculo_herramientas> Herramientas { get; set; }
    }
}