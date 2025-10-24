using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Usuario : EntidadBase
    {
        public decimal? nu_id_usuario            { get; set; }
        public string   vc_usuario               { get; set; }
        public string   vc_nombres               { get; set; }
        public string   vc_ape_paterno           { get; set; }
        public string   vc_ape_materno           { get; set; }
        public string   vc_contraseña            { get; set; }
        public string   vc_contraseña_nueva      { get; set; }
        public decimal? nu_id_perfil             { get; set; }
        public bool?    bi_estado                { get; set; }
        public decimal? nu_id_distribuidor       { get; set; }
        public decimal? nu_id_convenio           { get; set; }

    }
}
