using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class ComprobantePago : EntidadBase
    {
        public decimal? nu_id_cliente   { get; set; }
        public decimal? page            { get; set; }
        public decimal? pagesize        { get; set; }



        public string? vc_nro_celular { get; set; }
        public string? fecha_comprobante { get; set; }
        public int? nu_id_operador { get; set; }
        public decimal? nu_importe_comprobante { get; set; }
    }
}
