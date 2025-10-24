using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IEstadoRepository
    {
        List<object> sel_estado_distribuidor(string conexion, Estado model);
        List<object> sel_estado_comercio(string conexion, Estado model);

    }
}
