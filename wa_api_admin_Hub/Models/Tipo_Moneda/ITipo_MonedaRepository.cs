using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface ITipo_MonedaRepository
    {
        List<object> sel_tipo_moneda(string conexion, Tipo_Moneda model);

    }
}
