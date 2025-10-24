using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Tipo_Operacion : EntidadBase
    {
        public decimal? nu_id_tipo_operacion        { get; set; }
        public string   vc_cod_tipo_operacion       { get; set; }
        public string   vc_desc_tipo_operacion      { get; set; }
        public bool?    bi_estado                   { get; set; }

    }
}
