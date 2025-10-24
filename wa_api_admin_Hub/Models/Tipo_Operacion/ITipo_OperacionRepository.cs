using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface ITipo_OperacionRepository
    {
        List<object> sel_tipo_operacion(string conexion, Tipo_Operacion model);

    }
}
