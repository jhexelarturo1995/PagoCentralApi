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
    public class ConvenioController : ControllerBase
    {
        private readonly IConvenioRepository _ConvenioRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public ConvenioController(IHostingEnvironment env, IConvenioRepository IConvenioRepository)
        {
            _ConvenioRepository = IConvenioRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_convenio")]
        public IActionResult sel_convenio([FromBody]Convenio model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_ConvenioRepository.sel_convenio(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
        [HttpPost("sel_convenio_filtro_saldo")]
        public IActionResult sel_convenio_filtro_saldo([FromBody] Convenio model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_ConvenioRepository.sel_convenio_filtro_saldo(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        [HttpPost("sel_convenio_saldo")]
        public IActionResult sel_convenio_saldo([FromBody] Convenio model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_ConvenioRepository.sel_convenio_saldo(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        //[HttpPost("ins_convenio")]
        //public IActionResult ins_convenio([FromBody]Convenio model)
        //{
        //    if (!this.ModelState.IsValid)
        //        return this.BadRequest(this.ModelState);
        //    try
        //    {
        //        return this.Ok(_ConvenioRepository.ins_convenio(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.BadRequest(Utilitarios.JsonErrorSel(ex));
        //    }
        //}

        //[HttpPost("upd_convenio")]
        //public IActionResult upd_convenio([FromBody]Convenio model)
        //{
        //    if (!this.ModelState.IsValid)
        //        return this.BadRequest(this.ModelState);
        //    try
        //    {
        //        return this.Ok(_ConvenioRepository.upd_convenio(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.BadRequest(Utilitarios.JsonErrorSel(ex));
        //    }
        //}
    }
}
