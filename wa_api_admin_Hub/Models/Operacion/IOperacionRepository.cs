using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IOperacionRepository
    {
        List<object> sel_operacion(string conexion, Operacion model);
        object ins_operacion(string conexion, Operacion model);

    }
}
