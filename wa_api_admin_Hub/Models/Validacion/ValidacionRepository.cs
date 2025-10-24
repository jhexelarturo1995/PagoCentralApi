using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using wa_api_admin_Hub.Models.Cliente;
using static QRCoder.PayloadGenerator;

namespace wa_api_admin_Hub.Models
{
    public class ValidacionRepository : IValidacionRepository
    {
        public List<object> sel_banco(string conexion, Validacion model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_banco", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_banco", model.nu_id_banco);
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

        public object usp_validar_telefono(string conexion, Validacion model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_receipts_validatephone", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@phone_number", model.phone_number);
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

        public object usp_ins_validacion_sms(string conexion, Validacion model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_ins_validacion_sms", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nu_id_cliente", model.nu_id_cliente);
                        cmd.Parameters.AddWithValue("@vc_nro_celular", model.vc_nro_celular);

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

        public object usp_get_validacion_sms(string conexion, Validacion model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_get_validacion_sms", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nu_id_cliente", model.nu_id_cliente);
                        cmd.Parameters.AddWithValue("@vc_nro_celular", model.vc_nro_celular);
                        cmd.Parameters.AddWithValue("@vc_cod_validacion", model.vc_cod_validacion);

                        UtilSql.iGet2(cmd, model);
                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@nu_tran_stdo"].Value.ToDecimal() == 0)
                        {
                            tran.Rollback();
                            return UtilSql.sGetOutPut(cmd);
                        }

                        tran.Commit();
                        return UtilSql.sGetOutPut(cmd);
                    }



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public object usp_ins_validacion_correo_electronico(string conexion, Validacion model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_ins_validacion_correo_usuario_agente", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nu_id_cliente", model.nu_id_cliente);
                        cmd.Parameters.AddWithValue("@vc_nro_celular", model.vc_nro_celular);
                        cmd.Parameters.AddWithValue("@vc_correo_electronico", model.vc_correo_electronico);

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



        public object usp_get_validacion_correo_usuario_agente(string conexion, Validacion model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_get_validacion_correo_usuario_agente", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nu_id_cliente", model.nu_id_cliente);
                        cmd.Parameters.AddWithValue("@vc_nro_celular", model.vc_nro_celular);
                        cmd.Parameters.AddWithValue("@vc_cod_validacion", model.vc_cod_validacion);
                        cmd.Parameters.AddWithValue("@vc_correo_electronico", model.vc_correo_electronico);

                        UtilSql.iGet2(cmd, model);
                        cmd.ExecuteNonQuery();

                        if (cmd.Parameters["@nu_tran_stdo"].Value.ToDecimal() == 0)
                        {
                            tran.Rollback();
                            return UtilSql.sGetOutPut(cmd);
                        }

                        tran.Commit();
                        return UtilSql.sGetOutPut(cmd);
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
