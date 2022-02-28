using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class RequestsStatus
    {
        public int id_estado_solicitud { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Estado debe tener un valor.")]
        public String estado { get; set; }
        public int id_estado_aprobado { get; set; }
        public int id_estado_rechazado { get; set; }

        public int activo { get; set; }
    }
}
