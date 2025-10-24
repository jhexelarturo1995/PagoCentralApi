using System.Data.SqlClient;
using System.Data;
using System;

namespace wa_api_admin_Hub.Models.Province
{
    public class ProvinceRepository : IProvinceRepository
    {
        public object sel(string conexion, int department_id, string search)
        {
            ProvinceModel model = new ProvinceModel();
            model.vc_tran_clve_find = search;
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("usp_province_sel", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@department_id", department_id);
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
