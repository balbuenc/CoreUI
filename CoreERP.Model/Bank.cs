using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Bank
    {
        public int id_banco { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Banco debe tener un valor.")]
        public string banco { get; set; }
        public int id_ciudad { get; set; }
        public string nro_telefono { get; set; }
        public string oficial { get; set; }
        public string email { get; set; }
        public string ciudad { get; set; }
    }
}
