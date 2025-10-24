using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface ICuenta_CorrienteRepository
    {
        List<object> sel_cuenta_corriente(string conexion, Cuenta_Corriente model);

    }
}
