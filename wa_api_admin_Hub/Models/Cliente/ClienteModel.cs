namespace wa_api_admin_Hub.Models.Cliente
{
    public class ClienteModel: EntidadBase
    {
    }

    public class CLientDto
    {
        public int nu_id_cliente { get; set; }
        public int nu_id_tipo_doc_identidad { get; set; }
        public string vc_nro_doc_identidad { get; set; }
        public string ch_tipo_personeria { get; set; }
        public string vc_nombre { get; set; }
        public string vc_ape_paterno { get; set; }
        public string vc_ape_materno { get; set; }
        public string vc_razon_social { get; set; }
        public int nu_id_tipo_documento { get; set; }
        public string vc_email { get; set; }
        public string vc_direccion { get; set; }
        public int nu_id_departamento { get; set; }
        public int nu_id_provincia { get; set; }
        public int nu_id_distrito { get; set; }
    }
}
