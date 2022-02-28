using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class PaymentMethod
    {
        public int  id_medio_pago { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Medio debe tener un valor.")]
        public string medio { get; set; }
    }
}
