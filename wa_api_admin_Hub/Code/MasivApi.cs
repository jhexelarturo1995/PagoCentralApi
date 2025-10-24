using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using wa_api_admin_Hub.Models;

namespace wa_api_admin_Hub.Code
{

    public class MasivApi
    {
        private string ApiURL = "";
        private HttpClient api = new HttpClient();

        IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

        string userName;
        string password;
        string empresa;

        public MasivApi()
        {
            ApiURL = Environment.GetEnvironmentVariable("CadenaBD"); 
            userName = Environment.GetEnvironmentVariable("CadenaBD"); 
            password = Environment.GetEnvironmentVariable("CadenaBD"); 
            empresa = Environment.GetEnvironmentVariable("CadenaBD"); 

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            api = new HttpClient(clientHandler);

            var byteArray = Encoding.ASCII.GetBytes(userName + ":" + password);
            api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            api.BaseAddress = new Uri(ApiURL);
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<bool> EnviarSMS(string numero, string mensaje)
        {
            MasivResponseModel Result = null;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string url = ApiURL + "send-message";

                MasivPostModel PostModel = new MasivPostModel();

                string codigo_ciudad = "";
                string celular = "";

                if (numero.Length == 9 && numero.Substring(0, 1) == "9")
                {
                    codigo_ciudad = "51";
                    celular = numero;
                }
                else if (numero.Length < 9)
                {
                    Result = new MasivResponseModel();
                    Result.statusCode = -3;
                    Result.statusMessage = "Número de celular inválido.";
                }
                else
                {
                    codigo_ciudad = numero.Substring(0, 2);
                    celular = numero.Substring(2, numero.Length - 2);
                }

                PostModel.to = codigo_ciudad + celular;
                PostModel.text = mensaje;
                PostModel.customdata = empresa;

                if (mensaje.Length > 160)
                    PostModel.isLongmessage = true;

                var httpContent = new StringContent(JsonConvert.SerializeObject(PostModel), Encoding.UTF8, "application/json");

                response = await api.PostAsync(url, httpContent).ConfigureAwait(false);

                Result = JsonConvert.DeserializeObject<MasivResponseModel>(await response.Content.ReadAsStringAsync());

                if (Result != null && Result.statusCode == 200)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Result = new MasivResponseModel();
                Result.statusCode = -99;
                Result.statusMessage = "Error en la solicitud . (" + ex.Message + " | " + (response.Content == null ? "" : response.Content.ReadAsStringAsync().Result) + ")";

                return false;
            }
            return false;
        }
    }
}
