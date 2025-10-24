using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using wa_api_admin_Hub.Models;
using wa_api_admin_Hub.Models.Province;

namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : Controller
    {
        private readonly IProvinceRepository _ProvinceRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public ProvinceController(IProvinceRepository IProvinceRepository)
        {
            _ProvinceRepository = IProvinceRepository;

        }



        [HttpGet("sel")]
        public IActionResult sel([FromQuery] int department_id, string? search)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_ProvinceRepository.sel(Environment.GetEnvironmentVariable("CadenaBD"), department_id, search));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}
