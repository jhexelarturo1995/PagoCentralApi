namespace wa_api_admin_Hub.Models.IdentityDocumentType
{
    public class IdentityDocumentTypeModel : EntidadBase
    {
        public int id { get; set; }
        public string description { get; set; }
        public int maximum_number_digits { get; set; }
    }
}
