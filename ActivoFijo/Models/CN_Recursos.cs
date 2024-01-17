using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace ActivoFijo.Models
{
    public class CN_Recursos
    {
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