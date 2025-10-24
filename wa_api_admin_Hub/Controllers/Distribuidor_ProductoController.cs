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
    public class Distribuidor_ProductoController : ControllerBase
    {
        private readonly IDistribuidor_ProductoRepository _Distribuidor_ProductoRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public Distribuidor_ProductoController(IHostingEnvironment env, IDistribuidor_ProductoRepository IDistribuidor_ProductoRepository)
        {
            _Distribuidor_ProductoRepository = IDistribuidor_ProductoRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_distribuidor_producto")]
        public IActionResult sel_distribuidor_producto([FromBody]Distribuidor_Producto model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Distribuidor_ProductoRepository.sel_distribuidor_producto(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        [HttpPost("ins_distribuidor_producto")]
        public IActionResult ins_distribuidor_producto([FromBody]Distribuidor_Producto model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Distribuidor_ProductoRepository.ins_distribuidor_producto(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }

        [HttpPost("anu_distribuidor_producto")]
        public IActionResult anu_distribuidor_producto([FromBody]Distribuidor_Producto model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Distribuidor_ProductoRepository.anu_distribuidor_producto(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
