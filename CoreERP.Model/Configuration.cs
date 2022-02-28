using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Configuration
    {
        public int id_configuracion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Configuracion debe tener un valor.")]
        public string parametro { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Valor debe tener un valor.")]
        public string valor { get; set; }
    }
}
