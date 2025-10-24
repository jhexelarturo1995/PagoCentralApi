using System.Data.SqlClient;
using System.Data;
using System;

namespace wa_api_admin_Hub.Models.IdentityDocumentType
{
    public class IdentityDocumentTypeRepository : IIdentityDocumentTypeRepository
    {
        public object sel(string conexion)
        {
            IdentityDocumentTypeModel model = new IdentityDocumentTypeModel();
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("usp_identity_document_type_sel", cn))
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