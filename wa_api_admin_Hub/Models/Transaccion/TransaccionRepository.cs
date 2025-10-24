using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class TransaccionRepository : ITransaccionRepository
    {
        public List<object> sel_transaccion(string conexion, Transaccion model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_trx.usp_sel_transaccion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
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
        public object upd_transaccion_extorno(string conexion, Distribuidor model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_trx.upd_transaccion_extorno", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@vc_cod_distribuidor", model.vc_cod_distribuidor);
                        cmd.Parameters.AddWithValue("@vc_desc_distribuidor", model.vc_desc_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_modalidad_comision", model.nu_id_modalidad_comision);
                        cmd.Parameters.AddWithValue("@dt_fec_alta", model.dt_fec_alta);
                        cmd.Parameters.AddWithValue("@nu_id_estado", model.nu_id_estado);
                        cmd.Parameters.AddWithValue("@dt_fec_baja", model.dt_fec_baja);
                        cmd.Parameters.AddWithValue("@bi_estado", model.bi_estado);
                        cmd.Parameters.AddWithValue("@vc_zip_code", model.vc_zip_code);
                        UtilSql.iUpd(cmd, model);
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
