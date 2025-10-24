using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Comercio : EntidadBase
    {
        public decimal? nu_id_comercio              { get; set; }
        public decimal? nu_id_distribuidor          { get; set; }
        public string   vc_cod_comercio             { get; set; }
        public string   vc_nombre_comercio          { get; set; }
        public DateTime? dt_fec_alta                { get; set; }
        public DateTime? dt_fec_baja                { get; set; }
        public decimal? nu_id_estado                { get; set; }
        public string   vc_desc_estado              { get; set; }
        public bool?    bi_estado                   { get; set; }

    }
}
