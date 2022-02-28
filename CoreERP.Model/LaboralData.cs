using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class LaboralData
    {
        

        public int id_cliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Profesión debe tener un valor.")]
        public String profesion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Empresa debe tener un valor.")]
        public String empresa { get; set; }
        public String ramo { get; set; }
        public String cargo { get; set; }
        public String direccion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Fecha de ingreso debe tener un valor.")]
        public DateTime fecha_ingreso { get; set; }
        public int id_barrio { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Teléfono debe tener un valor.")]
        public String telefono { get; set; }
        public String fax { get; set; }
        public int id_conyugue { get; set; }
    }
}
