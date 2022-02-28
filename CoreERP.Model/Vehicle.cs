using System;
using System.Collections.Generic;
using System.Text;

namespace CoreERP.Model
{
    public class Vehicle
    {
        public int id_vehiculo { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public int ano_fabricacion { get; set; }
        public decimal valor { get; set; }
    }
}
