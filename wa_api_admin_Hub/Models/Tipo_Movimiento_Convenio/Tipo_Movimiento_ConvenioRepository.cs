using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Tipo_Movimiento_ConvenioRepository : ITipo_Movimiento_ConvenioRepository
    {
        public List<object> sel_tipo_movimiento_convenio(string conexion, Tipo_Movimiento_Convenio model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_tipo_movimiento_convenio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_tipo_movimiento_convenio", model.nu_id_tipo_movimiento_convenio);
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
