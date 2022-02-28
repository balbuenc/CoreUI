using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Country
    {
        public int id_pais { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Pais debe tener un valor.")]
       
        public string pais { get; set; }
        public int id_moneda { get; set; }

        public string moneda { get; set; }
    }
}
