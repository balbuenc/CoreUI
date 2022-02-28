using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Area
    {
        public int id_area { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Area debe tener un valor.")]
        public String area { get; set; }

        
    }
}
