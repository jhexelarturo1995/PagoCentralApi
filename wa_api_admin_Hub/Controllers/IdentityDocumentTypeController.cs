using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using wa_api_admin_Hub.Models;
using wa_api_admin_Hub.Models.IdentityDocumentType;

namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityDocumentTypeController : Controller
    {
        private readonly IIdentityDocumentTypeRepository _IdentityDocumentTypeRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public IdentityDocumentTypeController(IIdentityDocumentTypeRepository IIdentityDocumentTypeRepository)
        {
            _IdentityDocumentTypeRepository = IIdentityDocumentTypeRepository;

        }



        [HttpGet("sel")]
        public IActionResult sel()
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_IdentityDocumentTypeRepository.sel(Environment.GetEnvironmentVariable("CadenaBD")));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}
