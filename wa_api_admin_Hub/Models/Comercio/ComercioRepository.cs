using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class ComercioRepository : IComercioRepository
    {
        public List<object> sel_comercio(string conexion, Comercio model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_comercio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_comercio", model.nu_id_comercio);
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
        public object ins_comercio(string conexion, Comercio model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_ins_comercio", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@vc_cod_comercio", model.vc_cod_comercio);
                        cmd.Parameters.AddWithValue("@vc_nombre_comercio", model.vc_nombre_comercio);
                        cmd.Parameters.AddWithValue("@dt_fec_alta", model.dt_fec_alta);
                        cmd.Parameters.AddWithValue("@dt_fec_baja", model.dt_fec_baja);
                        cmd.Parameters.AddWithValue("@nu_id_estado", model.nu_id_estado);
                        cmd.Parameters.AddWithValue("@bi_estado", model.bi_estado);
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
                    throw ex;
                }

            }
        }
        public object upd_comercio(string conexion, Comercio model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_upd_comercio", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_comercio", model.nu_id_comercio);
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@vc_cod_comercio", model.vc_cod_comercio);
                        cmd.Parameters.AddWithValue("@vc_nombre_comercio", model.vc_nombre_comercio);
                        cmd.Parameters.AddWithValue("@dt_fec_alta", model.dt_fec_alta);
                        cmd.Parameters.AddWithValue("@dt_fec_baja", model.dt_fec_baja);
                        cmd.Parameters.AddWithValue("@nu_id_estado", model.nu_id_estado);
                        cmd.Parameters.AddWithValue("@bi_estado", model.bi_estado);
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
                    throw ex;
                }

            }
        }
        public object anu_comercio(string conexion, Comercio model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_anu_comercio", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_comercio", model.nu_id_comercio);
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
                    throw ex;
                }

            }
        }
    }
}
