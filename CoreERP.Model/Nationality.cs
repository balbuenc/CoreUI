using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class Nationality
    {
        public int id_nacionalidad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombre debe tener un valor.")]

        public String nacionalidad { get; set; }
    }
}
