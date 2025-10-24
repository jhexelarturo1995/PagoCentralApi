using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wa_api_admin_Hub.Code;
using wa_api_admin_Hub.Models;


namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    public class ValidacionController : ControllerBase
    {
        private readonly IValidacionRepository _ValidacionRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public ValidacionController(IHostingEnvironment env, IValidacionRepository IValidacionRepository)
        {
            _ValidacionRepository = IValidacionRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("validacion_telefono")]
        public IActionResult validacion_telefono([FromBody]Validacion model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_ValidacionRepository.usp_validar_telefono(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }

        [HttpPost("ins_validacion_telefono_sms")]
        public async Task<IActionResult> ins_validacion_telefono_sms([FromBody] Validacion model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var conexion = Configuration.GetSection(model.vc_nombre_conexion).Value;

                var obj = _ValidacionRepository.usp_ins_validacion_sms(conexion, model);
                var resultadoDb = obj as responseClass;

                if (resultadoDb == null)
                {
                    return Ok(new responseClass
                    {
                        nu_tran_stdo = 0,
                        tx_tran_mnsg = "No se obtuvo respuesta válida del servicio de validación.",
                        nu_tran_pkey = null,
                        vc_tran_codi = ""
                    });
                }

                // Si la SP no trae éxito, respeta el mensaje y no envíes correo
                if (resultadoDb.nu_tran_stdo != 1)
                {
                    resultadoDb.vc_tran_codi = ""; // nunca devolver clave
                    return Ok(resultadoDb);
                }
              

                // Éxito en SP: enviar la clave por correo y construir respuesta final
                var clave = resultadoDb.vc_tran_codi;
                var correoDestino = (model.vc_correo_electronico ?? "").Trim();

                var respuestaFinal = await EmailApi.EnviarClaveYConstruirRespuestaAsync(
                    correoDestino,
                    clave,
                    resultadoDb
                );

                return Ok(respuestaFinal);
            }
            catch (Exception ex)
            {
                return BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }



        [HttpPost("get_validacion_telefono_sms")]
        public IActionResult get_validacion_telefono_sms([FromBody] Validacion model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {

                return this.Ok(_ValidacionRepository.usp_get_validacion_sms(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }



        [HttpPost("validacion_correo_electronico")]
        public async Task<IActionResult> ins_validacion_correo_electronico([FromBody] Validacion model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var conexion = Environment.GetEnvironmentVariable("CadenaBD");
                
                var obj = _ValidacionRepository.usp_ins_validacion_correo_electronico(conexion, model);
                var resultadoDb = obj as responseClass;

                if (resultadoDb == null)
                {
                    return Ok(new responseClass
                    {
                        nu_tran_stdo = 0,
                        tx_tran_mnsg = "No se obtuvo respuesta válida del servicio de validación.",
                        nu_tran_pkey = null,
                        vc_tran_codi = ""
                    });
                }

                // Si la SP no trae éxito, respeta el mensaje y no envíes correo
                if (resultadoDb.nu_tran_stdo != 1)
                {
                    resultadoDb.vc_tran_codi = ""; // nunca devolver clave
                    return Ok(resultadoDb);
                }


                // Éxito en SP: enviar la clave por correo y construir respuesta final
                var clave = resultadoDb.vc_tran_codi;
                var correoDestino = (model.vc_correo_electronico ?? "").Trim();

                var respuestaFinal = await EmailApi.EnviarClaveYConstruirRespuestaAsync(
                    correoDestino,
                    clave,
                    resultadoDb
                );

                return Ok(respuestaFinal);
            }
            catch (Exception ex)
            {
                return BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }



        [HttpPost("get_validacion_correo_electronico")]
        public IActionResult get_validacion_correo_electronico([FromBody] Validacion model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {

                return this.Ok(_ValidacionRepository.usp_get_validacion_correo_usuario_agente(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}