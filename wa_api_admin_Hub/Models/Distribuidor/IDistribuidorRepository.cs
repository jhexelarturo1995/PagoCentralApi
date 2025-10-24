using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IDistribuidorRepository
    {
        List<object> sel_buscar_distribuidor(string conexion, Distribuidor model);
        List<object> sel_distribuidor(string conexion, Distribuidor model);
        object ins_distribuidor(string conexion, Distribuidor model);
        object upd_distribuidor(string conexion, Distribuidor model);
        List<object> sel_distribuidor_saldo(string conexion, Distribuidor model);
        Task<string> get_for_host(DistribuidorForHostRequest host);
    }
}
