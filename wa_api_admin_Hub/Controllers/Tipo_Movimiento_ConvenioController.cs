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
    public class Tipo_Movimiento_ConvenioController : ControllerBase
    {
        private readonly ITipo_Movimiento_ConvenioRepository _Tipo_Movimiento_ConvenioRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public Tipo_Movimiento_ConvenioController(IHostingEnvironment env, ITipo_Movimiento_ConvenioRepository ITipo_Movimiento_ConvenioRepository)
        {
            _Tipo_Movimiento_ConvenioRepository = ITipo_Movimiento_ConvenioRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_tipo_movimiento_convenio")]
        public IActionResult sel_tipo_movimiento_convenio([FromBody]Tipo_Movimiento_Convenio model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Tipo_Movimiento_ConvenioRepository.sel_tipo_movimiento_convenio(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
