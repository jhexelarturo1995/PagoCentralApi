using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using wa_api_admin_Hub.Models.Cliente;

namespace wa_api_admin_Hub.Code
{
    public class Sunat
    {
        private const string APIURL = "https://api.apis.net.pe";
        private HttpClient client = new HttpClient();
        public Sunat()
        {
            client.BaseAddress = new Uri(APIURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<SunatModel> GetRuc(string ruc)
        {
            SunatModel sunatRuc = new SunatModel();
            HttpResponseMessage response = await client.GetAsync("v1/ruc?numero=" + ruc);
            if (response.IsSuccessStatusCode)
            {
                sunatRuc = await response.Content.ReadAsAsync<SunatModel>();
            }

            if (sunatRuc == null)
            {
                sunatRuc = new SunatModel { };
            }
            return sunatRuc;
        }



        public async Task<SunatReniecModel> GetDni(string dni)
        {
            SunatReniecModel ReniecDni = new SunatReniecModel();
            HttpResponseMessage response = await client.GetAsync("v1/dni?numero=" + dni);
            if (response.IsSuccessStatusCode)
            {
                ReniecDni = await response.Content.ReadAsAsync<SunatReniecModel>();
            }

            if (ReniecDni == null)
            {
                ReniecDni = new SunatReniecModel { };
            }
            return ReniecDni;
        }
    }
}
