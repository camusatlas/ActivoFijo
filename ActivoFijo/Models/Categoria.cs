using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public string Base64 { get; set; }
        public string Extension { get; set; }
        public bool Activo { get; set; }
    }
}