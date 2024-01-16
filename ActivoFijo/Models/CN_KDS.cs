using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_KDS
    {
        private CD_KDS objCapaDato = new CD_KDS();

        public List<KDS> listar()
        {
            return objCapaDato.listarkds();
        }

        // Mensajes de Registrar KDS
        public int Registrar(KDS obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.empresa) || string.IsNullOrWhiteSpace(obj.empresa))
            {
                Mensaje = "Ingresar el nombre de la empresa.";

            }
            else if (string.IsNullOrEmpty(obj.marca) || string.IsNullOrWhiteSpace(obj.marca))
            {
                Mensaje = "Ingresar la Marca.";

            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "Ingresa el número de la marca.";

            }
            else if (string.IsNullOrEmpty(obj.nombre_tienda) || string.IsNullOrWhiteSpace(obj.nombre_tienda))
            {
                Mensaje = "Ingresa el nombre de la tienda.";

            }
            else if (string.IsNullOrEmpty(obj.ip_kds) || string.IsNullOrWhiteSpace(obj.ip_kds))
            {
                Mensaje = "Ingresar la IP correspondiente.";

            }
            else if (string.IsNullOrEmpty(obj.hostname) || string.IsNullOrWhiteSpace(obj.hostname))
            {
                Mensaje = "Ingresar el HostName correspondiente.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "Ingresar la serie.";

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

        // Mensajes de Editar KDS
        public bool Editar(KDS obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.empresa) || string.IsNullOrWhiteSpace(obj.empresa))
            {
                Mensaje = "Ingresar el nombre de la empresa.";

            }
            else if (string.IsNullOrEmpty(obj.marca) || string.IsNullOrWhiteSpace(obj.marca))
            {
                Mensaje = "Ingresar la Marca.";

            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "Ingresa el número de la marca.";

            }
            else if (string.IsNullOrEmpty(obj.nombre_tienda) || string.IsNullOrWhiteSpace(obj.nombre_tienda))
            {
                Mensaje = "Ingresa el nombre de la tienda.";

            }
            else if (string.IsNullOrEmpty(obj.ip_kds) || string.IsNullOrWhiteSpace(obj.ip_kds))
            {
                Mensaje = "Ingresar la IP correspondiente.";

            }
            else if (string.IsNullOrEmpty(obj.hostname) || string.IsNullOrWhiteSpace(obj.hostname))
            {
                Mensaje = "Ingresar el HostName correspondiente.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "Ingresar la serie.";

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