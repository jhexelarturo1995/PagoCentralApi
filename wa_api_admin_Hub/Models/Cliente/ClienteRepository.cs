using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System;

namespace wa_api_admin_Hub.Models.Cliente
{
    public class ClienteRepository : IClienteRepository
    {

        public async Task<string> sel(int client_id)
        {
            var conect = Environment.GetEnvironmentVariable("CadenaBD");
            using (SqlConnection cn = new SqlConnection(conect))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("TISI_TRX.USP_CLIENTE_GET", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NU_ID_CLIENTE", client_id);

                        return (string)await cmd.ExecuteScalarAsync();


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }




        public responseClass ins(string conexion, CLientDto input)
        {

            SqlTransaction tran = null;
            try
            {
                ClienteModel model = new ClienteModel();
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_trx.usp_upd_cliente", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nu_id_cliente", input.nu_id_cliente);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_doc_identidad", input.nu_id_tipo_doc_identidad);
                        cmd.Parameters.AddWithValue("@vc_nro_doc_identidad", input.vc_nro_doc_identidad);
                        cmd.Parameters.AddWithValue("@ch_tipo_personeria", input.ch_tipo_personeria);
                        cmd.Parameters.AddWithValue("@vc_nombre", input.vc_nombre);
                        cmd.Parameters.AddWithValue("@vc_ape_paterno", input.vc_ape_paterno);
                        cmd.Parameters.AddWithValue("@vc_ape_materno", input.vc_ape_materno);
                        cmd.Parameters.AddWithValue("@vc_razon_social", input.vc_razon_social);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_documento", input.nu_id_tipo_documento);
                        cmd.Parameters.AddWithValue("@vc_email", input.vc_email);
                        cmd.Parameters.AddWithValue("@vc_direccion", input.vc_direccion);
                        cmd.Parameters.AddWithValue("@nu_id_departamento", input.nu_id_departamento);
                        cmd.Parameters.AddWithValue("@nu_id_provincia", input.nu_id_provincia);
                        cmd.Parameters.AddWithValue("@nu_id_distrito", input.nu_id_distrito);
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
    }
}
