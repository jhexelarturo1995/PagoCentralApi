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
    public class DistribuidorController : ControllerBase
    {
        private readonly IDistribuidorRepository _DistribuidorRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public DistribuidorController(IHostingEnvironment env, IDistribuidorRepository IDistribuidorRepository)
        {
            _DistribuidorRepository = IDistribuidorRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_buscar_distribuidor")]
        public IActionResult sel_buscar_distribuidor([FromBody]Distribuidor model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_DistribuidorRepository.sel_buscar_distribuidor(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        [HttpPost("sel_distribuidor")]
        public IActionResult sel_distribuidor([FromBody]Distribuidor model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_DistribuidorRepository.sel_distribuidor(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        [HttpPost("ins_distribuidor")]
        public IActionResult ins_distribuidor([FromBody]Distribuidor model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_DistribuidorRepository.ins_distribuidor(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        [HttpPost("upd_distribuidor")]
        public IActionResult upd_distribuidor([FromBody]Distribuidor model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_DistribuidorRepository.upd_distribuidor(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        [HttpPost("sel_distribuidor_saldo")]
        public IActionResult sel_distribuidor_saldo([FromBody]Distribuidor model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_DistribuidorRepository.sel_distribuidor_saldo(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }



        [HttpPost("get_for_host")]
        public async Task<IActionResult> get_for_host([FromBody] DistribuidorForHostRequest model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {

                var stri = await _DistribuidorRepository.get_for_host(model);

                return Content(stri, "application/json");
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
