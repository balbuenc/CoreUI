using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class SaleDetails
    {
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal costo { get; set; }
        public String precio { get; set; }
    }
}
