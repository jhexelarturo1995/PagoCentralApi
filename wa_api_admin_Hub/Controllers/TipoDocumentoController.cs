using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using wa_api_admin_Hub.Models.IdentityDocumentType;
using wa_api_admin_Hub.Models;
using wa_api_admin_Hub.Models.TipoDocumento;

namespace wa_api_admin_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : Controller
    {
        private readonly ITipoDocumentoRepository _TipoDocumentoRepository;
        public IConfigurationRoot Configuration { get; }
        public string ruta_app { get; set; }

        public TipoDocumentoController(ITipoDocumentoRepository ITipoDocumentoRepository)
        {
            _TipoDocumentoRepository = ITipoDocumentoRepository;

        }



        [HttpGet("sel")]
        public IActionResult sel()
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);
            try
            {
                return this.Ok(_TipoDocumentoRepository.sel(Environment.GetEnvironmentVariable("CadenaBD")));
            }
            catch (Exception ex)
            {
                return this.BadRequest(Utilitarios.JsonErrorSel(ex));
            }

        }
    }
}
