using System.Data.SqlClient;
using System.Data;
using System;

namespace wa_api_admin_Hub.Models.District
{
    public class DistrictRepository:IDistrictRepository
    {
        public object sel(string conexion, int department_id, int province_id, string search)
        {
            DistrictModel model = new DistrictModel();
            model.vc_tran_clve_find = search;
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("usp_district_sel", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1; 
                        cmd.Parameters.AddWithValue("@province_id", province_id);
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
