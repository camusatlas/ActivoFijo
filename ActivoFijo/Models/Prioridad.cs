using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Prioridad
    {
        public int IdPrioridades { get; set; }
        public string NomPrioridad { get; set; }
        public bool Activo { get; set; }
    }
}