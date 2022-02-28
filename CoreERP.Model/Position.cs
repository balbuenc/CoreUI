using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Position
    {
        public int id_cargo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Area debe tener un valor.")]
        public int id_area { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Cargo debe tener un valor.")]
        public string cargo { get; set; }

        public string area { get; set; }

        //public virtual Area Area { get; set; }

    }
}
