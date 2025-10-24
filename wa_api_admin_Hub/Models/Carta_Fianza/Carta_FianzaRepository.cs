using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class Carta_FianzaRepository : ICarta_FianzaRepository
    {
        public object ins_carta_fianza(string conexion, Carta_Fianza model)
        {
            SqlTransaction tran = null;
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_trx.usp_ins_carta_fianza", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_banco", model.nu_id_banco);
                        cmd.Parameters.AddWithValue("@vc_nro_carta", model.vc_nro_carta);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_moneda", model.nu_id_tipo_moneda);
                        cmd.Parameters.AddWithValue("@nu_importe", model.nu_importe);
                        cmd.Parameters.AddWithValue("@dt_fec_emision", model.dt_fec_emision);
                        cmd.Parameters.AddWithValue("@dt_fec_vencimiento", model.dt_fec_vencimiento);
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
