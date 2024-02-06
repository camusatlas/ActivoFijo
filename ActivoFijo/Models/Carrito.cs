using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public Usuario oUsuario { get; set; }
        public Equipo oEquipo { get; set; }
        public int Cantidad { get; set; }

    }
}