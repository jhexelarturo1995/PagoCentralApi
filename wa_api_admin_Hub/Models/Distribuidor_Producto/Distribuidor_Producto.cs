using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Distribuidor_Producto : EntidadBase
    {
        public decimal? nu_id_distribuidor { get; set; }
        public decimal? nu_id_producto { get; set; }
        public string vc_cod_producto { get; set; }
        public string vc_desc_producto { get; set; }
        public string ch_tipo_comision { get; set; }
        public string vc_desc_tipo_comision { get; set; }
        public decimal? nu_valor_comision { get; set; }
        public decimal? nu_imp_com_usuario_final { get; set; }
        public bool? bi_estado { get; set; }

    }
}
