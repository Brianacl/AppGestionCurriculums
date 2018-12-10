using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_persona
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdCurriculo { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        public List<Eva_curriculo_competencias> Competencias { get; set; }
        public List<Eva_carrera_grado_estudios> GradoEstudios { get; set; }
        public List<Eva_curriculo_idiomas> Idiomas { get; set; }
        public List<Eva_experiencia_laboral> ExperienciaLaboral { get; set; }

        //FK
        public Rh_cat_personas rh_cat_personas { get; set; }
        public Int16 IdPersona { get; set; }
    }
}
