using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public class ProductoRepository : IProductoRepository
    {
        public List<object> sel_buscar_producto(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_producto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
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
        public List<object> sel_buscar_producto_distribuidor(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_producto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 3;
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_distribuidor", model.nu_id_distribuidor);
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
        public List<object> sel_producto(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_producto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 2;
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
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
        public List<object> sel_producto_pin(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_producto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 4;
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@vc_cod_producto", model.vc_cod_producto);
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
        public List<object> sel_producto_convenio(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("tisi_global.usp_sel_producto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 5;
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
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
        public object ins_producto(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_ins_producto", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@vc_cod_producto", model.vc_cod_producto);
                        cmd.Parameters.AddWithValue("@vc_desc_producto", model.vc_desc_producto);
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_moneda_compra", model.nu_id_tipo_moneda_compra);
                        cmd.Parameters.AddWithValue("@nu_precio_compra", model.nu_precio_compra);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_moneda_facial", model.nu_id_tipo_moneda_facial);
                        cmd.Parameters.AddWithValue("@nu_valor_facial", model.nu_valor_facial);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_moneda_vta", model.nu_id_tipo_moneda_vta);
                        cmd.Parameters.AddWithValue("@nu_precio_vta", model.nu_precio_vta);
                        cmd.Parameters.AddWithValue("@ch_tipo_comision_def", model.ch_tipo_comision_def);
                        cmd.Parameters.AddWithValue("@nu_valor_comision_def", model.nu_valor_comision_def);
                        cmd.Parameters.AddWithValue("@bi_afecto_impuesto", model.bi_afecto_impuesto);
                        cmd.Parameters.AddWithValue("@bi_venta_zonal", model.bi_venta_zonal);
                        UtilSql.iIns(cmd, model);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (cmd.Parameters["@nu_tran_stdo"].Value.ToDecimal() == 1)
                            tran.Commit();
                        else
                            tran.Rollback();
                        return UtilSql.sOutPut(cmd);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public object upd_producto(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_upd_producto", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
                        cmd.Parameters.AddWithValue("@vc_cod_producto", model.vc_cod_producto);
                        cmd.Parameters.AddWithValue("@vc_desc_producto", model.vc_desc_producto);
                        cmd.Parameters.AddWithValue("@nu_id_convenio", model.nu_id_convenio);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_moneda_compra", model.nu_id_tipo_moneda_compra);
                        cmd.Parameters.AddWithValue("@nu_precio_compra", model.nu_precio_compra);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_moneda_facial", model.nu_id_tipo_moneda_facial);
                        cmd.Parameters.AddWithValue("@nu_valor_facial", model.nu_valor_facial);
                        cmd.Parameters.AddWithValue("@nu_id_tipo_moneda_vta", model.nu_id_tipo_moneda_vta);
                        cmd.Parameters.AddWithValue("@nu_precio_vta", model.nu_precio_vta);
                        cmd.Parameters.AddWithValue("@ch_tipo_comision_def", model.ch_tipo_comision_def);
                        cmd.Parameters.AddWithValue("@nu_valor_comision_def", model.nu_valor_comision_def);
                        cmd.Parameters.AddWithValue("@bi_estado", model.bi_estado);
                        cmd.Parameters.AddWithValue("@bi_afecto_impuesto", model.bi_afecto_impuesto);
                        cmd.Parameters.AddWithValue("@bi_venta_zonal", model.bi_venta_zonal);
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
        public object anu_producto(string conexion, Producto model)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlTransaction tran = null;
                try
                {
                    cn.Open();
                    tran = cn.BeginTransaction();
                    using (var cmd = new SqlCommand("tisi_global.usp_anu_producto", cn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        model.nu_tran_ruta = 1;
                        cmd.Parameters.AddWithValue("@nu_id_producto", model.nu_id_producto);
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
