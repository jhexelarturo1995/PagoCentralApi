using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Carta_Fianza : EntidadBase
    {
        public decimal? nu_id_carta_fianza          { get; set; }
        public decimal? nu_id_distribuidor          { get; set; }
        public decimal? nu_id_banco                 { get; set; }
        public string   vc_nro_carta                { get; set; }
        public decimal? nu_id_tipo_moneda           { get; set; }
        public decimal? nu_importe                  { get; set; }
        public DateTime? dt_fec_emision             { get; set; }
        public DateTime? dt_fec_vencimiento         { get; set; }
        public bool?    bi_estado                   { get; set; }

    }
}
