using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Carrito
    {
        private CD_Carrito objCapaDato = new CD_Carrito();

        public bool ExisteCarrito(int idusuario, int idequipo)
        {
            return objCapaDato.ExisteCarrito(idusuario, idequipo);
        }

        public bool OperacionCarrito(int idusuario, int idequipo, bool sumar, out string Mensaje)
        {
            return objCapaDato.OperacionCarrito(idusuario, idequipo, sumar, out Mensaje);
        }

        public int CantidadEnCarrito(int idusuario)
        {
            return objCapaDato.CantidadEnCarrito(idusuario);
        }

        public List<Carrito> ListarEquipo(int idusuario)
        {
            return objCapaDato.ListarEquipo(idusuario);
        }

        public bool EliminarCarrito(int idusuario, int idequipo)
        {
            return objCapaDato.EliminarCarrito(idusuario, idequipo);
        }
    }
}