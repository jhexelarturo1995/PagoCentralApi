using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IComercioRepository
    {
        List<object> sel_comercio(string conexion, Comercio model);
        object ins_comercio(string conexion, Comercio model);
        object upd_comercio(string conexion, Comercio model);
        object anu_comercio(string conexion, Comercio model);

    }
}
