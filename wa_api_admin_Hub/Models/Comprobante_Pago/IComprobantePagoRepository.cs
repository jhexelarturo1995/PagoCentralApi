using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IComprobantePagoRepository
    {
        List<object> sel_Comprobante_Pago(string conexion, ComprobantePago model);
        object get_valida_comprobante_pago(string conexion, ComprobantePago model);

    }
}
