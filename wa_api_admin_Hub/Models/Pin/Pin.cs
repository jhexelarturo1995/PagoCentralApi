using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Pin : EntidadBase
    {
        public decimal? nu_id_convenio { get; set; }
        public int? nu_id_distribuidor { get; set; } = 1;
        public int? nu_id_producto { get; set; }
        public string vc_cod_producto { get; set; }
        public string vc_desc_producto { get; set; }
        public string vc_nro_pin { get; set; }
        public string dt_fec_inicio_vigencia { get; set; }
        public string dt_fec_fin_vigencia { get; set; }

    }
}
