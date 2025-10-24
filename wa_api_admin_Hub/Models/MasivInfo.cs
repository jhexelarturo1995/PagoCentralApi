namespace wa_api_admin_Hub.Models
{
    public class MasivInfo
    {
        public string apiURL { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string empresa { get; set; }
    }

    public class MasivPostModel
    {
        public string to { get; set; }
        public string text { get; set; }
        public string customdata { get; set; }
        public bool isPremium { get; set; } = false;
        public bool isFlash { get; set; } = false;
        public bool isLongmessage { get; set; } = false;
        public bool isRandomRoute { get; set; } = false;
    }

    public class MasivResponseModel
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public string messageId { get; set; }
    }
}
