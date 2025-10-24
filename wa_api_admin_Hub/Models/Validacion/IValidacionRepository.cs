using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models
{
    public interface IValidacionRepository
    {     
        object usp_validar_telefono(string conexion, Validacion model);
        object usp_ins_validacion_sms(string conexion, Validacion model);
        object usp_get_validacion_sms(string conexion, Validacion model);
        object usp_ins_validacion_correo_electronico(string conexion, Validacion model);
        object usp_get_validacion_correo_usuario_agente(string conexion, Validacion model);
    }
}
