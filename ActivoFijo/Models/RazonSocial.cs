using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class RazonSocial
    {
        public int IdRazonSocial { get; set; }
        public string NomRazonSocial { get; set; }
        public bool Activo {  get; set; }
    }
}