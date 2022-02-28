using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class PurchaseDetails
    {
        public int id_compra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Cantidad debe tener un valor.")]
        public decimal cantidad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Monto debe tener un valor.")]
        public decimal monto { get; set; }

        public String descripcion { get; set; }

        public int id_producto { get; set; }

        public int id_compra_detalle { get; set; }

        
        public string producto { get; set; }

        public string codigo { get; set; }

        public string factura { get; set; }
        public DateTime fecha  { get; set; }

        public string estado { get; set; }
        public string imagen { get; set; }

        public decimal total { get; set; }

        public string proveedor { get; set; }

        public string vendedor { get; set; }

        public string moneda { get; set; }

        
        public string monto_total { get; set; }
        public decimal total_compra { get; set; }


    }
}
