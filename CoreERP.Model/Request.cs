using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class Request
    {
        public int id_solicitud { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public int id_estado_solicitud { get; set; }
        public int id_presupuesto { get; set; }
        public int cuotas { get; set; }
        public decimal entrega { get; set; }
        public decimal monto_credito { get; set; }
        public decimal interes { get; set; }
    }
}
