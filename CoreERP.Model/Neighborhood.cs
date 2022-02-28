using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Neighborhood
    {
        public int id_barrio { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Barrio debe tener un valor.")]
        public string barrio { get; set; }
        public int id_ciudad { get; set; }

        public string ciudad { get; set; }
    }
}
