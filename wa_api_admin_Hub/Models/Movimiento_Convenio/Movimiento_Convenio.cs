using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Movimiento_Convenio : EntidadBase
    {
        public decimal? nu_id_movimiento_convenio { get; set; }
        public decimal? nu_id_convenio { get; set; }
        public decimal? nu_id_tipo_movimiento_convenio { get; set; }
        public string vc_desc_convenio { get; set; }
        public string vc_desc_tipo_movimiento_convenio { get; set; }
        public string vc_nro_movimiento { get; set; }
        public string vc_desc_estado { get; set; }
        public DateTime? dt_fec_movimiento { get; set; }
        public decimal? nu_importe { get; set; }
        public decimal? nu_saldo_previo_convenio { get; set; }
        public string vc_observacion { get; set; }
        public bool? bi_estado { get; set; }
        public string vc_usr_reg { get; set; }
        public DateTime? dt_fec_reg { get; set; }


    }
}
