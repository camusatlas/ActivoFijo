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

        public List<KDS> ListarKDS()
        {
            return objCapaDato.listarkds();
        }
        // Mensajes de Registrar KDS
        public int Registrar(KDS obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.empresa) || string.IsNullOrWhiteSpace(obj.empresa))
            {
                Mensaje = "El nombre de la empresa no puede estar vacío.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.marca) || string.IsNullOrWhiteSpace(obj.marca))
            {
                Mensaje = "La marca no puede estar vacía.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.nombre_tienda) || string.IsNullOrWhiteSpace(obj.nombre_tienda))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.departamento) || string.IsNullOrWhiteSpace(obj.departamento))
            {
                Mensaje = "El nombre del departamento no puede estar vacío.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.provincia) || string.IsNullOrWhiteSpace(obj.provincia))
            {
                Mensaje = "El nombre de la provincia no puede estar vacío.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.distrito) || string.IsNullOrWhiteSpace(obj.distrito))
            {
                Mensaje = "El nombre del distrito no puede estar vacío.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.ip_kds) || string.IsNullOrWhiteSpace(obj.ip_kds))
            {
                Mensaje = "La dirección IP del KDS no puede estar vacía.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.hostname) || string.IsNullOrWhiteSpace(obj.hostname))
            {
                Mensaje = "El nombre del host no puede estar vacío.";
                return 0;
            }
            else if (string.IsNullOrEmpty(obj.serial) || string.IsNullOrWhiteSpace(obj.serial))
            {
                Mensaje = "El número de serie no puede estar vacío.";
                return 0;
            }
            else
            {
                return 1;
            }
        }

        // Mensajes de Editar KDS
        public bool Editar(KDS obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.empresa) || string.IsNullOrWhiteSpace(obj.empresa))
            {
                Mensaje = "El nombre de la empresa no puede estar vacío.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.marca) || string.IsNullOrWhiteSpace(obj.marca))
            {
                Mensaje = "La marca no puede estar vacía.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.nombre_tienda) || string.IsNullOrWhiteSpace(obj.nombre_tienda))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.departamento) || string.IsNullOrWhiteSpace(obj.departamento))
            {
                Mensaje = "El nombre del departamento no puede estar vacío.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.provincia) || string.IsNullOrWhiteSpace(obj.provincia))
            {
                Mensaje = "El nombre de la provincia no puede estar vacío.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.distrito) || string.IsNullOrWhiteSpace(obj.distrito))
            {
                Mensaje = "El nombre del distrito no puede estar vacío.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.ip_kds) || string.IsNullOrWhiteSpace(obj.ip_kds))
            {
                Mensaje = "La dirección IP del KDS no puede estar vacía.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.hostname) || string.IsNullOrWhiteSpace(obj.hostname))
            {
                Mensaje = "El nombre del host no puede estar vacío.";
                return false;
            }
            else if (string.IsNullOrEmpty(obj.serial) || string.IsNullOrWhiteSpace(obj.serial))
            {
                Mensaje = "El número de serie no puede estar vacío.";
                return false;
            }
            else
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
        }

        // Eliminar
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }

    }
}