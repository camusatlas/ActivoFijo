﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Venta
    {
        private CD_Venta objCapaDato = new CD_Venta();

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objCapaDato.Registrar(obj, DetalleVenta, out Mensaje);
        }
    }
}