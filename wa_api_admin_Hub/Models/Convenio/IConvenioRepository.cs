using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IConvenioRepository
    {
        List<object> sel_convenio(string conexion, Convenio model);
        List<object> sel_convenio_filtro_saldo(string conexion, Convenio model);
        object ins_convenio(string conexion, Convenio model);
        object upd_convenio(string conexion, Convenio model);
        List<object> sel_convenio_saldo(string conexion, Convenio model);

    }
}
