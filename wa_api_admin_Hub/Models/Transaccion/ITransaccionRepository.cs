using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface ITransaccionRepository
    {
        List<object> sel_transaccion(string conexion, Transaccion model);

    }
}
