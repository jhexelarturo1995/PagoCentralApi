using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Operacion : EntidadBase
    {
        public decimal? nu_id_operacion { get; set; }
        public decimal? nu_id_distribuidor { get; set; }
        public string vc_desc_distribuidor { get; set; }
        public decimal? nu_id_tipo_operacion { get; set; }
        public string vc_desc_tipo_operacion { get; set; }
        public decimal? nu_id_carta_fianza { get; set; }
        public bool bi_carta_fianza { get; set; }
        public decimal? nu_id_cta_cte { get; set; }
        public string vc_desc_cta_cte { get; set; }
        public string vc_nro_operacion { get; set; }
        public DateTime? dt_fec_operacion { get; set; }
        public decimal? nu_importe { get; set; }
        public string vc_cod_oficina { get; set; }
        public bool? bi_estado { get; set; }
        public decimal? nu_id_banco { get; set; }
        public string vc_desc_banco { get; set; }
        public string vc_desc_estado { get; set; }
        public string vc_nombre_archivo { get; set; }

    }
}
