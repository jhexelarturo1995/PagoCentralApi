using System.Threading.Tasks;

namespace wa_api_admin_Hub.Models.Cliente
{
    public interface IClienteRepository
    {
        Task<string> sel(int client_id);
        responseClass ins(string conexion, CLientDto input);
    }
}
