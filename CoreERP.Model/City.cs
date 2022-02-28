using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class City
    {
        public int id_ciudad { get; set; }
        public int id_pais { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Ciudad debe tener un valor.")]
        public string ciudad { get; set; }

        public string pais { get; set; }


    }
}
