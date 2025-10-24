using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public object get_acceso(string conexion, Usuario model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_seguridad.usp_get_usuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@vc_usuario", model.vc_usuario);
                        cmd.Parameters.AddWithValue("@vc_contraseña", model.vc_contraseña);
                        UtilSql.iGet(cmd, model);
                        SqlDataReader dr = cmd.ExecuteReader();
                        return UtilSql.sGetOutPut(cmd);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public object get_usuario(string conexion, Usuario model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_seguridad.usp_get_usuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 2;
                        cmd.Parameters.AddWithValue("@vc_usuario", model.vc_usuario);
                        cmd.Parameters.AddWithValue("@vc_contraseña", model.vc_contraseña);
                        UtilSql.iGet(cmd, model);
                        SqlDataReader dr = cmd.ExecuteReader();
                        return UtilSql.Get(dr, model);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public object upd_usuario_pass(string conexion, Usuario model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_seguridad.usp_upd_usuario_contraseña", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_usuario", model.nu_id_usuario);
                        cmd.Parameters.AddWithValue("@vc_contraseña", model.vc_contraseña);
                        cmd.Parameters.AddWithValue("@vc_contraseña_nueva", model.vc_contraseña_nueva);
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

        public object usp_ins_usuario_agente(string conexion, Usuario_Afiliacion model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_ins_usuario_agente", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nu_id_cliente", model.nu_id_cliente);
                        cmd.Parameters.AddWithValue("@vc_nro_celular", model.vc_nro_celular);
                        cmd.Parameters.AddWithValue("@vc_correo_electronico", model.vc_correo_electronico);
                        cmd.Parameters.AddWithValue("@vc_contrasena", model.vc_contrasena);
                        cmd.Parameters.AddWithValue("@bi_estado", model.bi_estado);

                        UtilSql.iIns(cmd, model);
                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@nu_tran_stdo"].Value.ToDecimal() == 0)
                        {
                            tran.Rollback();
                            return UtilSql.sOutPutClass(cmd);
                        }

                        tran.Commit();
                        return UtilSql.sOutPutClass(cmd);
                    }



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public object usp_get_usuario_agente(string conexion, Usuario_Afiliacion model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_get_usuario_agente", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nu_id_cliente", model.nu_id_cliente);
                        cmd.Parameters.AddWithValue("@vc_usuario", model.vc_usuario);
                        cmd.Parameters.AddWithValue("@vc_contrasena", model.vc_contrasena);

                        UtilSql.iGet3(cmd, model);
                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@nu_tran_stdo"].Value.ToDecimal() == 0)
                        {
                            tran.Rollback();
                            return UtilSql.sGetOutPut2(cmd);
                        }

                        tran.Commit();
                        return UtilSql.sGetOutPut2(cmd);
                    }



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
