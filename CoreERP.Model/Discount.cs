using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Discount
    {
        public int id_descuento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Descuento debe tener un valor.")]
        public String descuento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Porcentaje debe tener un valor.")]
        public decimal porcentaje { get; set; }

    }
}

