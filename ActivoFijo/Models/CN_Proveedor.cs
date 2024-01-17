using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Proveedor
    {
        private CD_Proveedor objCapaDato = new CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return objCapaDato.listar();
        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.NomProveedor) || string.IsNullOrWhiteSpace(obj.NomProveedor))
            {
                Mensaje = "El nombre del proveedor no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NomProveedor) || string.IsNullOrWhiteSpace(obj.NomProveedor))
            {
                Mensaje = "El nolmbre del proveedor no puede ser vacio no puede ser vacio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}