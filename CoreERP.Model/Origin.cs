using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Origin
    {
        public int id_origen { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo origen debe tener un valor.")]
        public String origen { get; set; }
        public int id_pais { get; set; }

        public string pais { get; set; }
    }
}
