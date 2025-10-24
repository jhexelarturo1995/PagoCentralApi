using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IModalidad_ComisionRepository
    {
        List<object> sel_modalidad_comision(string conexion, Modalidad_Comision model);

    }
}
