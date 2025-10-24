using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Modalidad_Comision : EntidadBase
    {
        public decimal? nu_id_modalidad_comision    { get; set; }
        public string   vc_desc_modalidad_comision  { get; set; }
        public bool?    bi_estado                   { get; set; }

    }
}
