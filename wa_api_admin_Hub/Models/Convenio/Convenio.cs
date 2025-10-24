using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Convenio : EntidadBase
    {
        public decimal? nu_id_convenio              { get; set; }
        public string   vc_cod_convenio             { get; set; }
        public string   vc_desc_convenio            { get; set; }
        public bool?    bi_estado                   { get; set; }
        public decimal? nu_imp_movimientos { get; set; }
        public decimal? nu_imp_trx { get; set; }
        public decimal? nu_saldo_hub { get; set; }
        public decimal? nu_saldo { get; set; }
        public decimal? nu_diferencia { get; set; }
        public string vc_url_api_aes { get; set; }
        public string vc_clave_aes { get; set; }

    }
}
