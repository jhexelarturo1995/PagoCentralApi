using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IMovimiento_ConvenioRepository
    {
        List<object> sel_movimiento_convenio(string conexion, Movimiento_Convenio model);
        object ins_movimiento_convenio(string conexion, Movimiento_Convenio model);

    }
}
