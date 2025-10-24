using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IBancoRepository
    {
        List<object> sel_banco(string conexion, Banco model);

    }
}
