using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Cuenta_Corriente : EntidadBase
    {
        public decimal? nu_id_cta_cte               { get; set; }
        public decimal? nu_id_banco                 { get; set; }
        public string   vc_cod_cta_cte              { get; set; }
        public string   vc_desc_cta_cte             { get; set; }
        public bool?    bi_estado                   { get; set; }

    }
}
