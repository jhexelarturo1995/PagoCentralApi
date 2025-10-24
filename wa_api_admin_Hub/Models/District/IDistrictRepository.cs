namespace wa_api_admin_Hub.Models.District
{
    public interface IDistrictRepository
    {
        object sel(string conexion,int department_id, int province_id, string search);
    }
}
