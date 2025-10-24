using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Validacion : EntidadBase
    {
        public decimal? nu_id_banco             { get; set; }
        public string?  phone_number            { get; set; }
        public decimal? nu_id_cliente           { get; set; }
        public string? vc_nro_celular           { get; set; }
        public string? vc_cod_validacion        { get; set; }
        public string? vc_correo_electronico { get; set; }
    }
}
