using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class DistribuidorRepository : IDistribuidorRepository
    {
        public List<object> sel_buscar_distribuidor(string conexion, Distribuidor model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_distribuidor", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_modalidad_comision", model.nu_id_modalidad_comision);
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
        public List<object> sel_distribuidor(string conexion, Distribuidor model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_distribuidor", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 2;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_modalidad_comision", model.nu_id_modalidad_comision);
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
        public object ins_distribuidor(string conexion, Distribuidor model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_ins_distribuidor", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@vc_cod_distribuidor", model.vc_cod_distribuidor);
                        cmd.Parameters.AddWithValue("@vc_desc_distribuidor", model.vc_desc_distribuidor);
                        cmd.Parameters.AddWithValue("@nu_id_modalidad_comision", model.nu_id_modalidad_comision);
                        cmd.Parameters.AddWithValue("@dt_fec_alta", model.dt_fec_alta);
                        cmd.Parameters.AddWithValue("@nu_id_estado", model.nu_id_estado);
                        cmd.Parameters.AddWithValue("@dt_fec_baja", model.dt_fec_baja);
                        cmd.Parameters.AddWithValue("@vc_zip_code", model.vc_zip_code);
                        cmd.Parameters.AddWithValue("@vc_ruc", model.vc_ruc);
                        cmd.Parameters.AddWithValue("@vc_nombre_contacto", model.vc_nombre_contacto);
                        cmd.Parameters.AddWithValue("@vc_email_contacto", model.vc_email_contacto);
                        cmd.Parameters.AddWithValue("@vc_celular_contacto", model.vc_celular_contacto);
                        cmd.Parameters.AddWithValue("@nu_id_comercio", model.nu_id_comercio);
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
        public object upd_distribuidor(string conexion, Distribuidor model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_upd_distribuidor", cn, tran))
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
                        cmd.Parameters.AddWithValue("@vc_ruc", model.vc_ruc);
                        cmd.Parameters.AddWithValue("@vc_nombre_contacto", model.vc_nombre_contacto);
                        cmd.Parameters.AddWithValue("@vc_email_contacto", model.vc_email_contacto);
                        cmd.Parameters.AddWithValue("@vc_celular_contacto", model.vc_celular_contacto);
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
                    if (tran != null)
                        tran.Rollback();
                    throw ex;
                }

            }
        }
        public List<object> sel_distribuidor_saldo(string conexion, Distribuidor model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_distribuidor_saldo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
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


        public async Task<string> get_for_host(DistribuidorForHostRequest model)
        {
            var conect = Environment.GetEnvironmentVariable("CadenaBD");
            using (SqlConnection cn = new SqlConnection(conect))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("USP_DISTRIBUIDOR_FOR_HOST_GET", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VC_HOST", model.vc_host);

                        return (string)await cmd.ExecuteScalarAsync();


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
