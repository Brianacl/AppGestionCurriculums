using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppGestionCurriculums.Models
{
    public class Eva_curriculo_referencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdReferencia { get; set; }
        public Int16 IdTipoGenParentezco { get; set; } //fk no se de donde
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(60)]
        public string ApPaterno { get; set; }
        [StringLength(60)]
        public string ApMaterno { get; set; }
        [StringLength(1)]
        public string Finado { get; set; }
        [StringLength(20)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Domicilio { get; set; }
        [StringLength(255)]
        public string Observacion { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(100)]
        public string EntreCalles { get; set; }
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

        //FK
        public Int16 IdCurriculo { get; set; }
        public Eva_curriculo_persona eva_curriculo_personas { get; set; }

        public Tipo_gen_parentezco_referencias tipoGenParentezco { get; set; }
        public Int16 IdGenTipo { get; set; }
        public Int16 IdGenParentezco { get; set; } //FK 
    }
}

