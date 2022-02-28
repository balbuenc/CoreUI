using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Spouse
    {
        public int id_conyugue { get; set; }
        public int id_cliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombres debe tener un valor.")]
        public String nombres { get; set; }
        public String apellidos { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo CI debe tener un valor.")]
        public String ci { get; set; }
        public int id_nacionalidad { get; set; }
        public DateTime fecha_nacimiento { get; set; }
    }
}
