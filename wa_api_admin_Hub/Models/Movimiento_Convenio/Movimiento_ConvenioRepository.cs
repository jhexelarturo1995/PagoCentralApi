using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Movimiento_ConvenioRepository : IMovimiento_ConvenioRepository
    {
        public List<object> sel_movimiento_convenio(string conexion, Movimiento_Convenio model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_trx.usp_sel_movimiento_convenio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_movimiento_convenio", model.nu_id_tipo_movimiento_convenio);
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
        public object ins_movimiento_convenio(string conexion, Movimiento_Convenio model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_trx.usp_ins_movimiento_convenio", cn,tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_movimiento_convenio", model.nu_id_tipo_movimiento_convenio);
                        cmd.Parameters.AddWithValue("@vc_nro_movimiento", model.vc_nro_movimiento);
                        cmd.Parameters.AddWithValue("@dt_fec_movimiento", model.dt_fec_movimiento);
                        cmd.Parameters.AddWithValue("@nu_importe", model.nu_importe);
                        cmd.Parameters.AddWithValue("@vc_observacion", model.vc_observacion);
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
