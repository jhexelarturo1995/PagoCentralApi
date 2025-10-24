using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using wa_api_admin_Hub.Models;

namespace wa_api_admin_Hub.Code
{

    public static class EmailApi
    {

        public static async Task<responseClass> EnviarClaveYConstruirRespuestaAsync(
        string correoDestino,
        string clave,
        responseClass baseResp 
    )
        {
         
            var resp = new responseClass
            {
                nu_tran_stdo = baseResp?.nu_tran_stdo ?? 0,
                nu_tran_pkey = baseResp?.nu_tran_pkey,
                vc_tran_codi = "", // por seguridad jamás devolvemos la clave
                tx_tran_mnsg = baseResp?.tx_tran_mnsg
            };

            if (string.IsNullOrWhiteSpace(clave))
            {
                resp.nu_tran_stdo = 0;
                resp.tx_tran_mnsg = "No se generó la clave de validación.";
                return resp;
            }

            if (string.IsNullOrWhiteSpace(correoDestino))
            {
                resp.nu_tran_stdo = 0;
                resp.tx_tran_mnsg = "No se recibió un correo de destino válido.";
                return resp;
            }

            // Envío
            bool enviado = await EnviarClaveAsync(correoDestino, clave);

            if (enviado)
            {
                resp.nu_tran_stdo = 1;
                resp.tx_tran_mnsg = $"Te enviamos la clave de validación al correo {EnmascararCorreo(correoDestino)}. " +
                                    "Revisa tu bandeja de entrada o spam.";
            }
            else
            {
                resp.nu_tran_stdo = 0;
                resp.tx_tran_mnsg = "Generamos la clave, pero no pudimos enviarla por correo. " +
                                    "Intenta nuevamente en unos minutos.";
            }

            return resp;
        }

        private static string EnmascararCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@")) return correo;
            var partes = correo.Split('@');
            var local = partes[0];
            var dominio = partes[1];
            if (local.Length <= 2) return $"**@{dominio}";
            return $"{local.Substring(0, 2)}***@{dominio}";
        }

        public static async Task<bool> EnviarClaveAsync(string correoDestino, string codigo)
        {
            try
            {
                string correoEmisor = "jhexelarturo10@gmail.com";
                string claveEmisor = "plccryxhmearhffj"; // app password

                string html = ObtenerHtmlCodigoVerificacion(correoDestino, codigo);
                string textoPlano = $"Hola ,\n\nTu código de verificación es: {codigo}\n\nSi no lo solicitaste, ignora este mensaje.";

                using (var mensaje = new MailMessage())
                {
                    mensaje.From = new MailAddress(correoEmisor, "Agente Multibanco Kasnet");
                    mensaje.To.Add(correoDestino);
                    mensaje.Subject = "Código de verificación";
                    mensaje.SubjectEncoding = Encoding.UTF8;
                    mensaje.BodyEncoding = Encoding.UTF8;
                    mensaje.IsBodyHtml = true;

                    var plainView = AlternateView.CreateAlternateViewFromString(textoPlano, Encoding.UTF8, "text/plain");
                    var htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, "text/html");
                    mensaje.AlternateViews.Add(plainView);
                    mensaje.AlternateViews.Add(htmlView);

                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(correoEmisor, claveEmisor);
                        await smtp.SendMailAsync(mensaje);
                    }
                }
                return true;
            }
            catch { return false; }
        }


        private static string ObtenerHtmlCodigoVerificacion(string nombre, string codigo)
        {
            // Colores tipo Interbank
            const string VERDE = "#0d6efd";
            const string AZUL = "#0d6efd";

            return $@"
                    <!doctype html>
                    <html lang=""es"">
                      <head>
                        <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Código de verificación</title>
                      </head>
                      <body style=""margin:0; padding:0; background:#f5f7fb;"">
                        <center style=""width:100%; background:#f5f7fb;"">
                          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""max-width:560px; margin:0 auto;"">

                            <!-- Espaciado superior -->
                            <tr><td style=""height:12px;""></td></tr>

                            <!-- Contenido -->
                            <tr>
                              <td style=""background:#ffffff; padding:26px 24px; border-radius:18px;"">
                                <p style=""margin:0 0 8px; font-family:Segoe UI, Roboto, Arial, sans-serif; font-size:16px; color:#111827;"">
                                  Hola:
                                </p>

                                <p style=""margin:0 0 18px; font-family:Segoe UI, Roboto, Arial, sans-serif; font-size:14px; line-height:1.7; color:#374151;"">
                                  Para seguir con tu solicitud, ingresa este
                                  <strong style=""color:{VERDE};"">código de verificación</strong> en la web.
                                </p>

                                <!-- Tarjeta del código -->
                                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""border-collapse:separate; margin:8px 0 16px;"">
                                  <tr>
                                    <td style=""background:#ffffff; border:1px solid #e5e7eb; padding:22px; border-radius:16px;"">
                                      <p style=""margin:0 0 6px; font-family:Segoe UI, Roboto, Arial, sans-serif; font-size:12px; color:#9ca3af; text-align:center;"">
                                        Tu código de verificación es
                                      </p>
                                      <div style=""text-align:center; font-family:'Segoe UI Semibold', Segoe UI, Roboto, Arial, sans-serif;
                                                   font-size:28px; letter-spacing:2px; color:{VERDE};"">
                                        {System.Net.WebUtility.HtmlEncode(codigo)}
                                      </div>
                                    </td>
                                  </tr>
                                </table>

                                <p style=""margin:0; font-family:Segoe UI, Roboto, Arial, sans-serif; font-size:12px; color:#6b7280;"">
                                  Si no solicitaste este código, ignora este mensaje.
                                </p>
                              </td>
                            </tr>

                            <!-- Footer simple -->
                            <tr>
                              <td style=""padding:14px 8px; text-align:center; color:#9ca3af;
                                         font-family:Segoe UI, Roboto, Arial, sans-serif; font-size:11px;"">
                                {DateTime.UtcNow:dd/MM/yyyy}
                              </td>
                            </tr>
                          </table>
                        </center>
                      </body>
                    </html>";
        }

    }
}
