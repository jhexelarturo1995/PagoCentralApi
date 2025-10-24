using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Tipo_Moneda : EntidadBase
    {
        public decimal? nu_id_tipo_moneda           { get; set; }
        public string   vc_simbolo_moneda           { get; set; }
        public string   vc_desc_tipo_moneda         { get; set; }
        public bool?    bi_estado                   { get; set; }

    }
}
