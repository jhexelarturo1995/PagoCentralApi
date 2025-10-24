using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IUsuarioRepository
    {
        object get_acceso(string conexion, Usuario model);
        object get_usuario(string conexion, Usuario model);
        object upd_usuario_pass(string conexion, Usuario model);
        object usp_ins_usuario_agente(string conexion, Usuario_Afiliacion model);
        object usp_get_usuario_agente(string conexion, Usuario_Afiliacion model);

    }
}
