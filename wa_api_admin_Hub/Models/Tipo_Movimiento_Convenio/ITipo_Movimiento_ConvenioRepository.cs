using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface ITipo_Movimiento_ConvenioRepository
    {
        List<object> sel_tipo_movimiento_convenio(string conexion, Tipo_Movimiento_Convenio model);

    }
}
