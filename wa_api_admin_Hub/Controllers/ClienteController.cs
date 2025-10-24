using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using wa_api_admin_Hub.Models;
using wa_api_admin_Hub.Models.Cliente;
using Microsoft.AspNetCore.Authorization;

namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _ClienteRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }


        public ClienteController(IHostingEnvironment env, IClienteRepository IClienteRepository)
        {
            _ClienteRepository = IClienteRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpGet("get/{idCLient:int}")]
        public async Task<IActionResult> sel([FromRoute] int idCLient)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {

                var stri = await _ClienteRepository.sel(idCLient);

                return Content(stri, "application/json");
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }



        [HttpPost]
        public async Task<IActionResult> Ins([FromBody] CLientDto model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_ClienteRepository.ins(Environment.GetEnvironmentVariable("CadenaBD"), model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
