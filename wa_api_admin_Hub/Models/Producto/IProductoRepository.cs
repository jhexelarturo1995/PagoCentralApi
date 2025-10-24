using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IProductoRepository
    {
        List<object> sel_buscar_producto(string conexion, Producto model);
        List<object> sel_buscar_producto_distribuidor(string conexion, Producto model);
        List<object> sel_producto(string conexion, Producto model);
        List<object> sel_producto_pin(string conexion, Producto model);
        List<object> sel_producto_convenio(string conexion, Producto model);
        object ins_producto(string conexion, Producto model);
        object upd_producto(string conexion, Producto model);
        object anu_producto(string conexion, Producto model);

    }
}
