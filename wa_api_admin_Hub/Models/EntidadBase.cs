﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class EntidadBase
    {
        private string usuario_reg = "";
        private string usuario_mod = "";

        public string vc_nombre_conexion { get; set; }
        public decimal? nu_tran_ruta { get; set; }
        public string vc_tran_clve_find { get; set; }
        public string vc_tran_usua_ptcn { get; set; }
        public string vc_tran_usua_regi
        {
            get { return usuario_reg; }
            set { usuario_reg = value.ToUpper(); }
        }
        public string vc_tran_usua_modi
        {
            get { return usuario_mod; }
            set { usuario_mod = value.ToUpper(); }
        }
        public decimal? nu_tran_pkey { get; set; }
        public string vc_tran_codi { get; set; }
        public decimal? nu_tran_stdo { get; set; }
        public string tx_tran_mnsg { get; set; }
        public string ch_tran_stdo_regi { get; set; }
        public DateTime dt_fec_inicio { get; set; }
        public DateTime dt_fec_final { get; set; }
        public string ch_estado { get; set; }
        public string ch_periodo_ini { get; set; }
        public string ch_periodo_fin { get; set; }

        public decimal? nu_tran_regs_pagn { get; set; }
        public decimal? nu_tran_pagn { get; set; }
    }
}
