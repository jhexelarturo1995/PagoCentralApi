namespace wa_api_admin_Hub.Models.Province
{
    public interface IProvinceRepository
    {
        object sel(string conexion, int department_id, string search);
    }
}
