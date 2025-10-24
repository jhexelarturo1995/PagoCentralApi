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
    public class PinController : ControllerBase
    {
        private readonly IPinRepository _PinRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public PinController(IHostingEnvironment env, IPinRepository IPinRepository)
        {
            _PinRepository = IPinRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("ins")]
        public IActionResult ins([FromBody]Pin model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_PinRepository.ins(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

    }
}
