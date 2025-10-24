using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Distribuidor : EntidadBase
    {
        public decimal? nu_id_distribuidor              { get; set; }
        public string   vc_cod_distribuidor             { get; set; }
        public string   vc_desc_distribuidor            { get; set; }
        public decimal? nu_id_modalidad_comision        { get; set; }
        public string   vc_desc_modalidad_comision      { get; set; }
        public decimal? nu_imp_limite_piso              { get; set; }
        public decimal? nu_imp_trx                      { get; set; }
        public decimal? nu_saldo                        { get; set; }
        public decimal? nu_saldo_hub                    { get; set; }
        public decimal? nu_saldo_izipay                 { get; set; }
        public decimal? nu_saldo_servipagos             { get; set; }
        public DateTime? dt_fec_alta                    { get; set; }
        public DateTime? dt_fec_baja                    { get; set; }
        public decimal? nu_id_estado                    { get; set; }
        public string   vc_desc_estado                  { get; set; }
        public bool?    bi_estado                       { get; set; }
        public string   vc_zip_code                     { get; set; }
        public string   vc_ruc                          { get; set; }
        public string   vc_nombre_contacto              { get; set; }
        public string   vc_email_contacto               { get; set; }
        public string   vc_celular_contacto             { get; set; }
        public decimal? nu_id_comercio                  { get; set; }

    }


    public class DistribuidorForHostRequest
    {
        public string vc_host { get; set; }
    }
}

