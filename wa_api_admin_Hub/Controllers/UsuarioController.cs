using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using wa_api_admin_Hub.Models;


namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public UsuarioController(IHostingEnvironment env, IUsuarioRepository IUsuarioRepository)
        {
            _UsuarioRepository = IUsuarioRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("get_acceso")]
        public IActionResult get_acceso([FromBody]Usuario model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_UsuarioRepository.get_acceso(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
        [HttpPost("get_usuario")]
        public IActionResult get_usuario([FromBody]Usuario model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_UsuarioRepository.get_usuario(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
        [HttpPost("upd_usuario_pass")]
        public IActionResult upd_usuario_pass([FromBody] Usuario model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_UsuarioRepository.upd_usuario_pass(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }

        [HttpPost("usp_ins_usuario_agente")]
        public IActionResult usp_ins_usuario_agente([FromBody] Usuario_Afiliacion model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_UsuarioRepository.usp_ins_usuario_agente(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }

        [HttpPost("get_usuario_agente")]
        public IActionResult get_usuario_agente([FromBody] Usuario_Afiliacion model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_UsuarioRepository.usp_get_usuario_agente(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}