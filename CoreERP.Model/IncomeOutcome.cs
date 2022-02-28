using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class IncomeOutcome
    {
        public int id_ingreso_egreso { get; set; }
        public int id_cliente { get; set; }
        public decimal ingreso_sueldo { get; set; }
        public decimal ingreso_sueldo_conyugue { get; set; }
        public decimal ingreso_honorarios { get; set; }
        public decimal ingreso_ventas { get; set; }
        public decimal ingreso_otros { get; set; }
        public decimal egreso_cuotas { get; set; }
        public decimal egreso_alquiler { get; set; }
        public decimal egreso_gastos_familiares { get; set; }
        public decimal egreso_costo_mercaderias { get; set; }
        public decimal egreso_otros { get; set; }
        public decimal ingreso_total { get; set; }
        public decimal egreso_tota { get; set; }
    }
}
