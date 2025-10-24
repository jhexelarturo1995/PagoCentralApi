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
    public class Carta_FianzaController : ControllerBase
    {
        private readonly ICarta_FianzaRepository _Carta_FianzaRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public Carta_FianzaController(IHostingEnvironment env, ICarta_FianzaRepository ICarta_FianzaRepository)
        {
            _Carta_FianzaRepository = ICarta_FianzaRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("ins_carta_fianza")]
        public IActionResult ins_carta_fianza([FromBody]Carta_Fianza model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Carta_FianzaRepository.ins_carta_fianza(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}