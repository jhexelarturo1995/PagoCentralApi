using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Estado : EntidadBase
    {
        public decimal? nu_id_estado            { get; set; }
        public string   vc_desc_estado          { get; set; }
        public bool?    bi_estado               { get; set; }

    }
}
