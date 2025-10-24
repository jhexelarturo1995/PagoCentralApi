using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class PinRepository : IPinRepository
    {
        public object ins(string conexion, Pin model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_trx.USP_INS_PIN_VALIDA_DATOS", cn,tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
                        cmd.Parameters.AddWithValue("@vc_nro_pin", model.vc_nro_pin);
                        UtilSql.iIns(cmd, model);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (cmd.Parameters["@nu_tran_stdo"].Value.ToString() != "1")
                        {
                            tran.Rollback();
                            return Utilitarios.JsonErrorTran(new Exception(cmd.Parameters["@tx_tran_mnsg"].Value.ToText()));
                        }


                        using (var cmd2 = new SqlCommand("tisi_trx.USP_INS_PIN", cn, tran))
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;
                            model.nu_tran_ruta = 1;
                            cmd2.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                            cmd2.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
                            cmd2.Parameters.AddWithValue("@vc_nro_pin", model.vc_nro_pin);
                            cmd2.Parameters.AddWithValue("@bi_bloqueado", false);
                            cmd2.Parameters.AddWithValue("@dt_fec_inicio_vigencia", model.dt_fec_inicio_vigencia);
                            cmd2.Parameters.AddWithValue("@dt_fec_fin_vigencia", model.dt_fec_fin_vigencia);
                            UtilSql.iIns(cmd2, model);
                            SqlDataReader dr2 = cmd2.ExecuteReader();
                            if (cmd2.Parameters["@nu_tran_stdo"].Value.ToString() == "0")
                            {
                                tran.Rollback();
                                return Utilitarios.JsonErrorTran(new Exception(cmd.Parameters["@tx_tran_mnsg"].Value.ToText()));
                            }
                            tran.Commit();

                            return UtilSql.sOutPut(cmd2);
                        }

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
