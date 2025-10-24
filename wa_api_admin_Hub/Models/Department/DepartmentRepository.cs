using System.Data.SqlClient;
using System.Data;
using System;

namespace wa_api_admin_Hub.Models.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public object sel(string conexion, string search)
        {
            DepartmentModel model = new DepartmentModel();
            model.vc_tran_clve_find = search;
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("usp_department_sel", cn))
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
