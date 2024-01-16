using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace ActivoFijo.Models
{
    public class Tecnico
    {
        public int IdTecnico { get; set; }
        public string Nombres { get; set; } 
        public string Correo { get; set; }
        public bool Activo { get; set; }
    }
}