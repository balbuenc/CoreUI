using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class Product
    {
        public int id_producto { get; set; }
        public int id_origen { get; set; }
        public String producto { get; set; }
        public String codigo { get; set; }
        public int id_marca { get; set; }
        public String descripcion { get; set; }
        public int? id_proveedor { get; set; }
        public decimal costo { get; set; }
        public decimal precio { get; set; }
        public int dias_garantia { get; set; }

        public int id_moneda { get; set; }

        public String imagen { get; set; }

        public string origen { get; set; }
        public string proveedor { get; set; }
        public string marca { get; set; }
        public string moneda { get; set; }
    }
}
