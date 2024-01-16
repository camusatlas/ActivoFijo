using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class SistemaOperativo
    {
        public int IdSistema { get; set; }
        public string NombreSistema { get; set; }
        public bool Activo { get; set; }
    }
}