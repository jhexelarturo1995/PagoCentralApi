using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using wa_api_admin_Hub.Models;
using wa_api_admin_Hub.Models.Department;

namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public DepartmentController(IDepartmentRepository IDepartmentRepository)
        {
            _DepartmentRepository = IDepartmentRepository;

        }



        [HttpGet("sel")]
        public IActionResult sel([FromQuery] string? search)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_DepartmentRepository.sel(Environment.GetEnvironmentVariable("CadenaBD"), search));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}
