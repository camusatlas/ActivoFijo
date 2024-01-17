using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Reporte
    {
        public string FechaVenta { get; set; }
        public string Cliente { get; set; }
        public string Equipo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }


        public decimal Total { get; set; }
        public string IdTransaccion { get; set; }
    }
}