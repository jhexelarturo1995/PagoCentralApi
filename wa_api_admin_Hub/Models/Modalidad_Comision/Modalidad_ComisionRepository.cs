using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Modalidad_ComisionRepository : IModalidad_ComisionRepository
    {
        public List<object> sel_modalidad_comision(string conexion, Modalidad_Comision model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_modalidad_comision", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_modalidad_comision", model.nu_id_modalidad_comision);
                        cmd.Parameters.AddWithValue("@bi_estado", model.bi_estado);
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
