using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class ComercialReference
    {
        public int id_referencia_comercial { get; set; }
        public int id_cliente { get; set; }
        public int id_entidad_financiera { get; set; }
    }
}
