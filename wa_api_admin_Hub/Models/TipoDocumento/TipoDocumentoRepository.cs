using System.Data.SqlClient;
using System.Data;
using System;
using wa_api_admin_Hub.Models.IdentityDocumentType;

namespace wa_api_admin_Hub.Models.TipoDocumento
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        public object sel(string conexion)
        {
            TipoDocumentoModel model = new TipoDocumentoModel();
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("usp_tipo_documento_sel", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        UtilSql.iGet(cmd, model);
                        SqlDataReader dr = cmd.ExecuteReader();
                        return UtilSql.Query(dr, model);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }
    }
}
