using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class AccountDetails
    {


        public int id_cuenta_detalle { get; set; }
        public int id_cuenta { get; set; }

        public DateTime fecha { get; set; }

        public int id_funcionario { get; set; }


        public string tipo { get; set; }

        public decimal monto { get; set; }

        public string concepto { get; set; }

        public string beneficiario { get; set; }

        public string nro_comprobante { get; set; }

        public string detalle { get; set; }

        public string nro_cuenta { get; set; }

        public string usuario { get; set; }


    }
}
