using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NomProveedor { get; set; }
        public bool Activo { get; set; }
    }
}