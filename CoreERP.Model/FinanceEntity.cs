using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class FinanceEntity
    {
        public int id_entidad_financiera { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Entidad debe tener un valor.")]
        public String entidad { get; set; }
        public String telefono { get; set; }
        public String tipo { get; set; }
    }
}
