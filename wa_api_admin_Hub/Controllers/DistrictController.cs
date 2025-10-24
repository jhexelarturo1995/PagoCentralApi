using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using wa_api_admin_Hub.Models;
using wa_api_admin_Hub.Models.District;

namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : Controller
    {
        private readonly IDistrictRepository _DistrictRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public DistrictController(IDistrictRepository IDistrictRepository)
        {
            _DistrictRepository = IDistrictRepository;

        }



        [HttpGet("sel")]
        public IActionResult sel([FromQuery] int department_id, int province_id, string? search)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_DistrictRepository.sel(Environment.GetEnvironmentVariable("CadenaBD"), department_id, province_id, search));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}
