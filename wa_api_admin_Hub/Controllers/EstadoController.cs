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
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepository _EstadoRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public EstadoController(IHostingEnvironment env, IEstadoRepository IEstadoRepository)
        {
            _EstadoRepository = IEstadoRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_estado_distribuidor")]
        public IActionResult sel_estado_distribuidor([FromBody]Estado model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_EstadoRepository.sel_estado_distribuidor(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }

        [HttpPost("sel_estado_comercio")]
        public IActionResult sel_estado_comercio([FromBody]Estado model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_EstadoRepository.sel_estado_comercio(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}