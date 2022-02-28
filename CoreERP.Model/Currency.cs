using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Currency
    {
        public int id_moneda { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Moneda debe tener un valor.")]
        public String moneda { get; set; }
        public String simbolo { get; set; }

        public decimal cotizacion { get; set; }

    }
}
