﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Almacen
    {
        public int IdAlmacen { get; set; }
        public string NomAlmacen { get; set; }
        public bool Activo { get; set; }
    }
}