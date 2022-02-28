using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreERP.Model
{
    public class RequestsStatusHistory
    {
        public int id_historico_estado_solicitud { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Estado Inicial debe tener un valor.")]
        public int id_estado_inicial { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Estado Final debe tener un valor.")]
        public int id_estado_final { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Funcionario debe tener un valor.")]
        public int id_funcionario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Fecha de cambio debe tener un valor.")]
        public DateTime fecha_cambio_estado { get; set; }
        public String comentario { get; set; }
    }
}
