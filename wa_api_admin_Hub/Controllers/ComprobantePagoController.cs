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
    public class ComprobantePagoController : ControllerBase
    {
        private readonly IComprobantePagoRepository _ComprobantePagoRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public ComprobantePagoController(IHostingEnvironment env, IComprobantePagoRepository IComprobantePagoRepository)
        {
            _ComprobantePagoRepository = IComprobantePagoRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_Comprobante_Pago")]
        public IActionResult sel_Comprobante_Pago([FromBody] ComprobantePago model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_ComprobantePagoRepository.sel_Comprobante_Pago(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }

        [HttpPost("get_valida_comprobante_pago")]
        public IActionResult get_valida_comprobante_pago([FromBody] ComprobantePago model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                var conexion = Environment.GetEnvironmentVariable("CadenaBD");
                return this.Ok(_ComprobantePagoRepository.get_valida_comprobante_pago(conexion, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}