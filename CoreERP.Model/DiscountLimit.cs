using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class DiscountLimit
    {
        public int id_limite_descuento { get; set; }

        public int id_marca { get; set; }
        public decimal limite { get; set; }

        public string marca { get; set; }

        public decimal limite_actual { get; set; }
    }
}
