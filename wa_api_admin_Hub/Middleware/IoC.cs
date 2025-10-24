using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wa_api_admin_Hub.Models;
using wa_api_admin_Hub.Models.Cliente;
using wa_api_admin_Hub.Models.Department;
using wa_api_admin_Hub.Models.District;
using wa_api_admin_Hub.Models.IdentityDocumentType;
using wa_api_admin_Hub.Models.Province;
using wa_api_admin_Hub.Models.TipoDocumento;

namespace wa_api_admin_Hub.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IValidacionRepository, ValidacionRepository>();
            services.AddSingleton<ICarta_FianzaRepository, Carta_FianzaRepository>();
            services.AddSingleton<IComercioRepository, ComercioRepository>();
            services.AddSingleton<IConvenioRepository, ConvenioRepository>();
            services.AddSingleton<ICuenta_CorrienteRepository, Cuenta_CorrienteRepository>();
            services.AddSingleton<IDistribuidor_ProductoRepository, Distribuidor_ProductoRepository>();
            services.AddSingleton<IDistribuidorRepository, DistribuidorRepository>();
            services.AddSingleton<IEstadoRepository, EstadoRepository>();
            services.AddSingleton<IModalidad_ComisionRepository, Modalidad_ComisionRepository>();
            services.AddSingleton<IOperacionRepository, OperacionRepository>();
            services.AddSingleton<IProductoRepository, ProductoRepository>();
            services.AddSingleton<ITipo_MonedaRepository, Tipo_MonedaRepository>();
            services.AddSingleton<ITipo_OperacionRepository, Tipo_OperacionRepository>();
            services.AddSingleton<ITransaccionRepository, TransaccionRepository>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IMovimiento_ConvenioRepository, Movimiento_ConvenioRepository>();
            services.AddSingleton<ITipo_Movimiento_ConvenioRepository, Tipo_Movimiento_ConvenioRepository>();
            services.AddSingleton<IPinRepository, PinRepository>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IDistrictRepository, DistrictRepository>();
            services.AddSingleton<IProvinceRepository, ProvinceRepository>();
            services.AddSingleton<IIdentityDocumentTypeRepository, IdentityDocumentTypeRepository>();
            services.AddSingleton<ITipoDocumentoRepository, TipoDocumentoRepository>();
            services.AddSingleton<IValidacionRepository, ValidacionRepository>();
            services.AddSingleton<IComprobantePagoRepository, ComprobantePagoRepository>();

            return services;
        }
    }
}
