using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IDistribuidor_ProductoRepository
    {
        List<object> sel_distribuidor_producto(string conexion, Distribuidor_Producto model);
        object ins_distribuidor_producto(string conexion, Distribuidor_Producto model);
        object anu_distribuidor_producto(string conexion, Distribuidor_Producto model);

    }
}
