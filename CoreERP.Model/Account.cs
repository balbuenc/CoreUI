using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Account
    {
        public int id_cuenta { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Tipo debe tener un valor.")]
        public int id_tipo_cuenta { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Banco debe tener un valor.")]
        public int id_banco { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Denominación debe tener un valor.")]
        public string denominacion { get; set; }
        public string nro_cuenta { get; set; }

        public string tipo_cuenta { get; set; }
        public string banco { get; set; }

        public int id_moneda { get; set; }
        public string moneda { get; set; }
    }
}
