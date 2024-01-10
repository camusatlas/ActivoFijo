using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Caracteristicas
    {
        public int IdCaracteristicas { get; set; }
        public TipoEquipo oTipoEquipo { get; set; }
        public string Serie { get; set; }
        public string GuiaIngreso { get; set; }
        public string ActivoFijo { get; set; }
        public Sistema oSistemaOperativo { get; set; }
        public string AndressMac { get; set; }
        public string NomCaracteristicas { get; set; }
        public string FechaGenerada { get; set; }
        public string FechaActual { get; set; }
    }
}