using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_RazonSocial
    {
        private CD_RazonSocial objCapaDato = new CD_RazonSocial();

        public List<RazonSocial> Listar()
        {
            return objCapaDato.listar();
        }
        // Mensaje de Respuesta al Registrar RazonSocial
        public int Registrar(RazonSocial obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.NomRazonSocial) || string.IsNullOrWhiteSpace(obj.NomRazonSocial))
            {
                Mensaje = "La descripcion de la RazonSocial no puede ser vacio";
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
        // Mensaje de Respuesta al Editar Categoria
        public bool Editar(RazonSocial obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NomRazonSocial) || string.IsNullOrWhiteSpace(obj.NomRazonSocial))
            {
                Mensaje = "La descripcion de la RazonSocial no puede ser vacio";
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

        // Eliminar
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }

    }
}