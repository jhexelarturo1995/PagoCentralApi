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
    public class Cuenta_CorrienteController : ControllerBase
    {
        private readonly ICuenta_CorrienteRepository _Cuenta_CorrienteRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public Cuenta_CorrienteController(IHostingEnvironment env, ICuenta_CorrienteRepository ICuenta_CorrienteRepository)
        {
            _Cuenta_CorrienteRepository = ICuenta_CorrienteRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_cuenta_corriente")]
        public IActionResult sel_cuenta_corriente([FromBody]Cuenta_Corriente model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Cuenta_CorrienteRepository.sel_cuenta_corriente(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
