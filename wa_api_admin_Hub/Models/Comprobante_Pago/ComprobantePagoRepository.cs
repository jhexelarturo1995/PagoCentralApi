using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class ComprobantePagoRepository : IComprobantePagoRepository
    {
        public List<object> sel_Comprobante_Pago(string conexion, ComprobantePago model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                using (var cmd = new SqlCommand("dbo.usp_ComprobantePago_Paginado", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Tus mismos parámetros, con los mismos nombres
                    cmd.Parameters.AddWithValue("@nu_id_cliente", model.nu_id_cliente);
                    cmd.Parameters.AddWithValue("@page", model.page);
                    cmd.Parameters.AddWithValue("@pagesize", model.pagesize);

                    using (var dr = cmd.ExecuteReader())
                    {
                        var resultado = new List<object>();

                        // 1) Result set de filas (página)
                        var filas = new List<Dictionary<string, object>>();
                        while (dr.Read())
                        {
                            var row = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                            for (int i = 0; i < dr.FieldCount; i++)
                                row[dr.GetName(i)] = dr.IsDBNull(i) ? null : dr.GetValue(i);
                            filas.Add(row);
                        }
                        resultado.Add(filas);

                        // 2) Result set de metadatos
                        var meta = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                        if (dr.NextResult() && dr.Read())
                        {
                            meta["total_rows"] = dr["total_rows"];
                            meta["page"] = dr["page"];
                            meta["page_size"] = dr["page_size"];
                            meta["total_pages"] = dr["total_pages"];
                        }
                        resultado.Add(meta);

                        return resultado;
                    }
                }
            }
        }




        public object get_valida_comprobante_pago(string conexion, ComprobantePago model)
        {

            SqlTransaction tran = null;
            try
            {
                using (var cn = new SqlConnection(conexion))
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("dbo.usp_get_valida_comprobante_pago", cn, tran))
                    {
                        model.nu_tran_ruta = 1;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VC_NRO_CELULAR", model.vc_nro_celular);
                        cmd.Parameters.AddWithValue("@DT_FECHA", model.fecha_comprobante);
                        cmd.Parameters.AddWithValue("@NU_IMPORTE_TOTAL", model.nu_importe_comprobante);
                        cmd.Parameters.AddWithValue("@NU_ID_OPERADOR", model.nu_id_operador);
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
