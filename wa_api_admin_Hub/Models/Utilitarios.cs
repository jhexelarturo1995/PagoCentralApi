using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRCoder;

namespace wa_api_admin_Hub.Models
{
    public static class Utilitarios
    {
        public static void GuardarImagen(string vc_cadena_imagen, string ruta_archivo)
        {
            byte[] aByte = Convert.FromBase64String(vc_cadena_imagen);

            MemoryStream ms = new MemoryStream(aByte, 0, aByte.Length);
            ms.Write(aByte, 0, aByte.Length);
            Image newImage = Image.FromStream(ms, true);

            //string path = Path.Combine(new string[] { url_server, ruta_archivo });
            FileInfo toDownload = new FileInfo(ruta_archivo);

            if (toDownload.Exists)
            {
                System.IO.File.Delete(ruta_archivo);
            }

            newImage.Save(ruta_archivo, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public static string ImagenString64bit(string ruta_archivo)
        {
            FileInfo file = new FileInfo(ruta_archivo);
            if (!file.Exists)
            {
                throw new Exception("No existe el archivo");
            }
            Image imagen = Image.FromFile(ruta_archivo);

            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                imagen.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }

        }

        public static void CreaCarpetasBasicas(string url_server, string nombre_carpeta)
        {
            if (!Directory.Exists(url_server + "\\Recursos"))
                Directory.CreateDirectory(url_server + "\\Recursos");

            if (!Directory.Exists(url_server + "\\Recursos\\" + nombre_carpeta))
                Directory.CreateDirectory(url_server + "\\Recursos\\" + nombre_carpeta);
        }

        public static object JsonErrorTran(Exception ex)
        {
            String jsonObject = "{";
            jsonObject += "\"nu_tran_stdo\":\"0\",";
            jsonObject += "\"nu_tran_pkey\":\"0\",";
            jsonObject += "\"vc_tran_codi\":\"" + ex.GetType() + "\",";
            jsonObject += "\"tx_tran_mnsg\":\"" + ex.Message + "\",";
            jsonObject = jsonObject.Substring(0, jsonObject.Length - 1) + "}";

            return JsonConvert.DeserializeObject<object>(jsonObject);
        }
        public static object JsonErrorObj(dynamic obj)
        {
            String jsonObject = "{";
            jsonObject += "\"nu_tran_stdo\":\"" + obj.nu_tran_stdo + "\",";
            jsonObject += "\"nu_tran_pkey\":\"" + obj.nu_tran_pkey + "\",";
            jsonObject += "\"vc_tran_codi\":\"" + obj.vc_tran_codi + "\",";
            jsonObject += "\"tx_tran_mnsg\":\"" + obj.tx_tran_mnsg + "\",";
            jsonObject = jsonObject.Substring(0, jsonObject.Length - 1) + "}";

            return JsonConvert.DeserializeObject<object>(jsonObject);
        }

        public static object JsonErrorSel(Exception ex)
        {
            //String jsonObject = "{";
            //jsonObject += "\"tipo\":\"" + ex.GetType() + "\",";
            //jsonObject += "\"error\":\"" + ex.Message + "\",";
            //jsonObject = jsonObject.Substring(0, jsonObject.Length - 1) + "}";

            //return JsonConvert.DeserializeObject<object>(jsonObject);

            responseClass ec = new responseClass();
            ec.nu_tran_stdo = 0;
            ec.nu_tran_pkey = 0;
            ec.vc_tran_codi = "";
            ec.tx_tran_mnsg = ex.Message;
            return ec;

        }

        public static string CodigoQrString64bit(string info_qr)
        {
            byte[] ImgStream;
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(2);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(info_qr, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        var img = qrCode.GetGraphic(20, Color.Black, Color.White, null, 0);

                        MemoryStream MS = new MemoryStream();

                        img.Save(MS, ImageFormat.Jpeg);
                        ImgStream = MS.ToArray();
                        MS.Close();
                    }
                }
            }
            return Convert.ToBase64String(ImgStream);
        }

        public static string TicketCentrar(this string cadena)
        {
            string result;
            int lg = 24;
            if (cadena.Length < 48)
            {
                result = new string(' ', lg - cadena.Length / 2) + cadena;
            }
            else
            {
                result = cadena;
            }
            return result;
        }


        public static void EnviarCorreoOffice365(string body, string subject, string correo_envio, string correo_soporte, string contraseña_correo_soporte)
        {
            MailMessage correo = new MailMessage();
            correo.To.Clear();

            correo.Body = body;
            correo.Subject = subject;
            correo.IsBodyHtml = true;
            correo.BodyEncoding = Encoding.UTF8;
            correo.From = new MailAddress(correo_soporte);
            correo.To.Add(correo_envio);

            SmtpClient envio = new SmtpClient("smtp.office365.com", 587);
            envio.DeliveryMethod = SmtpDeliveryMethod.Network;
            envio.UseDefaultCredentials = false;
            envio.Credentials = new NetworkCredential(correo_soporte, contraseña_correo_soporte);
            envio.EnableSsl = true;

            envio.Send(correo);

        }

    }
}
