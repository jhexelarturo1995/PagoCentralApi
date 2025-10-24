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
    public class Modalidad_ComisionController : ControllerBase
    {
        private readonly IModalidad_ComisionRepository _Modalidad_ComisionRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public Modalidad_ComisionController(IHostingEnvironment env, IModalidad_ComisionRepository IModalidad_ComisionRepository)
        {
            _Modalidad_ComisionRepository = IModalidad_ComisionRepository;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
            ruta_app = env.ContentRootPath;
        }

        [HttpPost("sel_modalidad_comision")]
        public IActionResult sel_modalidad_comision([FromBody]Modalidad_Comision model)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_Modalidad_ComisionRepository.sel_modalidad_comision(Configuration.GetSection(model.vc_nombre_conexion).Value, model));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }
        }
    }
}
