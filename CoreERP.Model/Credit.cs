using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class Credit
    {
        public int id_credito { get; set; }
        public int id_funcionario { get; set; }
        public DateTime fecha_aprobacion { get; set; }
        public int id_solicitud { get; set; }
        public DateTime fecha_primer_vencimiento { get; set; }
    }
}
