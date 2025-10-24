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
    public class Tipo_OperacionController : ControllerBase
    {
        private readonly ITipo_OperacionRepository _Tipo_OperacionRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public Tipo_OperacionController(IHostingEnvironment env, ITipo_OperacionRepository ITipo_OperacionRepository)
        {
            _Tipo_OperacionRepository = ITipo_OperacionRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_tipo_operacion")]
        public IActionResult sel_tipo_operacion([FromBody]Tipo_Operacion model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Tipo_OperacionRepository.sel_tipo_operacion(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
