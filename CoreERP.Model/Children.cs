using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Children
    {
        public int id_hijo { get; set; }
        public int id_cliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombre debe tener un valor.")]
        public String nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nacimiento debe tener un valor.")]
        public DateTime fecha_nacimiento { get; set; }
    }
}
