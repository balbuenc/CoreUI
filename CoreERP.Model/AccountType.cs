using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class AccountType
    {
        public int id_tipo_cuenta { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Tipo debe tener un valor.")]
        public string tipo_cuenta { get; set; }
    }
}
