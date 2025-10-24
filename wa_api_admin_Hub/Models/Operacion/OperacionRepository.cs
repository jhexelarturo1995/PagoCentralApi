using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class OperacionRepository : IOperacionRepository
    {
        public List<object> sel_operacion(string conexion, Operacion model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_trx.usp_sel_operacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_operacion", model.nu_id_tipo_operacion);
                        cmd.Parameters.AddWithValue("@nu_id_banco", model.nu_id_banco);
                        cmd.Parameters.AddWithValue("@nu_id_cta_cte", model.nu_id_cta_cte);
                        cmd.Parameters.AddWithValue("@dt_fec_inicio", model.dt_fec_inicio);
                        cmd.Parameters.AddWithValue("@dt_fec_final", model.dt_fec_final);
                        cmd.Parameters.AddWithValue("@ch_estado", model.ch_estado);
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
        public object ins_operacion(string conexion, Operacion model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_trx.usp_ins_operacion", cn,tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_operacion", model.nu_id_tipo_operacion);
                        cmd.Parameters.AddWithValue("@nu_id_carta_fianza", model.nu_id_carta_fianza);
                        cmd.Parameters.AddWithValue("@nu_id_cta_cte", model.nu_id_cta_cte);
                        cmd.Parameters.AddWithValue("@vc_nro_operacion", model.vc_nro_operacion);
                        cmd.Parameters.AddWithValue("@dt_fec_operacion", model.dt_fec_operacion);
                        cmd.Parameters.AddWithValue("@nu_importe", model.nu_importe);
                        cmd.Parameters.AddWithValue("@vc_cod_oficina", model.vc_cod_oficina);
                        cmd.Parameters.AddWithValue("@vc_nombre_archivo", model.vc_nombre_archivo);
                        UtilSql.iIns(cmd, model);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (cmd.Parameters["@nu_tran_stdo"].Value.ToString() == "0")
                        {
                            tran.Rollback();
                            return Utilitarios.JsonErrorTran(new Exception(cmd.Parameters["@tx_tran_mnsg"].Value.ToText()));
                        }
                        tran.Commit();
                        return UtilSql.sOutPut(cmd);
                    }
                }
                catch (Exception ex)
                {
                    if (tran != null)
                        tran.Rollback();
                    throw ex;
                }

            }
        }
    }
}
