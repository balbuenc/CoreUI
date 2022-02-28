using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class Vendor
    {
        public int id_proveedor { get; set; }
        public String proveedor { get; set; }
        public String descripcion { get; set; }
        public int id_pais { get; set; }

        public string pais { get; set; }
    }
}
