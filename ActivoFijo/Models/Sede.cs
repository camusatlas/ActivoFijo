using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Sede
    {
        public int IdSede { get; set; }
        public string NomSede { get; set; }

        public bool Activo { get; set; }
    }
}