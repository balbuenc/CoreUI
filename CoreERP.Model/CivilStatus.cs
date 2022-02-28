using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class CivilStatus
    {
        public int id_estado_civil { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Entidad debe tener un valor.")]
        public String estado_civil { get; set; }
    }
}
