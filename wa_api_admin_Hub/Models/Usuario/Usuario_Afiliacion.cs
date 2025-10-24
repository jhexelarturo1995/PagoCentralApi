using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Usuario_Afiliacion : EntidadBase
    {
        public decimal? nu_id_cliente { get; set; }
        public string vc_nro_celular { get; set; }
        public string vc_correo_electronico { get; set; }
        public string vc_contrasena { get; set; }
        public bool? bi_estado { get; set; }
        public string vc_usuario { get; set; }

    }
}
