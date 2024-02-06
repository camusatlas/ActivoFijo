﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using System.Net.Mail;
using System.Net;


namespace ActivoFijo.Models
{
    public class CN_Recursos
    {
        public static string GenerarClave()
        {
            string calve = Guid.NewGuid().ToString("N").Substring(0,6);
            return calve;
        }

        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;

            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("carlos5517068@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("carlos5517068@gmail.com", "tutmnmzoakakjxjb"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };

                smtp.Send(mail);
                resultado = true;


            }
            catch (Exception ex)
            {
                resultado = false;

            }
            return resultado;
        }



        public static string ConvertirBase64(string ruta, out bool conversion)
        {
            string textoBase64 = string.Empty;
            conversion = true;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                textoBase64 = Convert.ToBase64String(bytes);
            }
            catch
            {
                conversion = false;
            }
            return textoBase64;
        }

    }
}