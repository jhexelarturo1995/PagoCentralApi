using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Producto : EntidadBase
    {
        public decimal? nu_id_distribuidor          { get; set; }
        public decimal? nu_id_producto              { get; set; }
        public string   vc_cod_producto             { get; set; }
        public string   vc_desc_producto            { get; set; }
        public decimal? nu_id_convenio              { get; set; }
        public string   vc_desc_convenio            { get; set; }
        public decimal? nu_id_tipo_moneda_compra    { get; set; }
        public string   vc_desc_tipo_moneda_compra  { get; set; }
        public decimal? nu_precio_compra            { get; set; }
        public decimal? nu_id_tipo_moneda_facial    { get; set; }
        public string   vc_desc_tipo_moneda_facial  { get; set; }
        public decimal? nu_valor_facial             { get; set; }
        public decimal? nu_id_tipo_moneda_vta       { get; set; }
        public string   vc_desc_tipo_moneda_vta     { get; set; }
        public decimal? nu_precio_vta               { get; set; }
        public string   ch_tipo_comision_def        { get; set; }
        public string   vc_desc_tipo_comision_def   { get; set; }
        public decimal? nu_valor_comision_def       { get; set; }
        public bool?    bi_estado                   { get; set; }
        public string   vc_cod_ean                  { get; set; }
        public string   vc_desc_categoria           { get; set; }
        public string   vc_desc_tipo_producto       { get; set; }
        public string   vc_desc_sub_tipo_producto   { get; set; }
        public bool?    bi_afecto_impuesto          { get; set; }
        public bool?    bi_venta_zonal              { get; set; }

    }
}
