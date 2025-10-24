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
    public class Tipo_MonedaController : ControllerBase
    {
        private readonly ITipo_MonedaRepository _Tipo_MonedaRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public Tipo_MonedaController(IHostingEnvironment env, ITipo_MonedaRepository ITipo_MonedaRepository)
        {
            _Tipo_MonedaRepository = ITipo_MonedaRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_tipo_moneda")]
        public IActionResult sel_Tipo_Moneda([FromBody]Tipo_Moneda model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Tipo_MonedaRepository.sel_tipo_moneda(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
