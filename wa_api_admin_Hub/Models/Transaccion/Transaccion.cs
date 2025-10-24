using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Transaccion : EntidadBase
    {
        public decimal? nu_id_trx                   { get; set; }
        public decimal? nu_id_trx_ref               { get; set; }
        public decimal? nu_id_distribuidor          { get; set; }
        public string   vc_desc_distribuidor        { get; set; }
        public decimal? nu_id_comercio              { get; set; }
        public string   vc_nombre_comercio          { get; set; }
        public decimal? nu_id_convenio              { get; set; }
        public string   vc_nombre_convenio          { get; set; }
        public DateTime? dt_fecha                   { get; set; }
        public string   vc_hora                     { get; set; }
        public bool     bi_extorno                  { get; set; }
        public decimal? nu_id_producto              { get; set; }
        public decimal? vc_cod_producto             { get; set; }
        public string   vc_desc_producto            { get; set; }
        public string   ch_tipo_comision            { get; set; }
        public string   vc_desc_tipo_comision       { get; set; }
        public decimal? nu_valor_facial             { get; set; }
        public decimal? nu_valor_comision           { get; set; }
        public decimal? nu_precio_compra            { get; set; }
        public decimal? nu_precio_vta               { get; set; }
        public bool     bi_gratuito                 { get; set; }
        public decimal? nu_imp_trx                  { get; set; }
        public decimal? nu_id_tipo_doc_sol          { get; set; }
        public string   vc_nro_doc_sol              { get; set; }
        public string   ch_dig_ver_sol              { get; set; }
        public string   vc_email_sol                { get; set; }
        public string   vc_telefono_sol             { get; set; }
        public decimal? nu_id_tipo_doc_cpt          { get; set; }
        public string   vc_nro_doc_cpt              { get; set; }
        public string   vc_id_ref_trx               { get; set; }
        public decimal? nu_id_tipo_documento        { get; set; }
        public string   vc_ruc                      { get; set; }
        public string vc_desc_tipo_moneda_facial { get; set; }
        public string vc_desc_tipo_moneda_vta { get; set; }
        public string vc_desc_tipo_moneda_compra { get; set; }
        public string vc_desc_estado { get; set; }
        public decimal? nu_imp_com_usuario_final { get; set; }
        public string vc_desc_convenio { get; set; }
        public decimal? nu_imp_pago_convenio { get; set; }
        public decimal? nu_imp_comision_convenio { get; set; }
        public decimal? nu_imp_pago_neto_convenio { get; set; }

    }
}
