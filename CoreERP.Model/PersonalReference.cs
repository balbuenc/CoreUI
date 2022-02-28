using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class PersonalReference
    {
        public int id_referencia_personal { get; set; }
        public String nombre { get; set; }
        public String telefono_fijo { get; set; }
        public int id_cliente { get; set; }
        public String telefono_celular { get; set; }
    }
}
