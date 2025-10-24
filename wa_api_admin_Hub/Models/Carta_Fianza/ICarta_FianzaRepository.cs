using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface ICarta_FianzaRepository
    {
        object ins_carta_fianza(string conexion, Carta_Fianza model);

    }
}
