using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Venta
    {
        public int IdSalidaEquipo { get; set; }
        public int IdTecnico { get; set; }
        public int IdUsuario { get; set; }
        public int TotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public string IdTienda { get; set; }
        public string Ticket { get; set; }
        public string GuiaSalida { get; set; }
        public string FechaTexto { get; set; }
        public string IdTransaccion { get; set; }

    }
}