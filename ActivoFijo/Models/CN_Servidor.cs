using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ActivoFijo.Models;
using Microsoft.Ajax.Utilities;

namespace ActivoFijo.Models
{
    public class CN_Servidor
    {
        private CD_Servidor objCapaDato = new CD_Servidor();

        public List<Servidor> listar()
        {
            return objCapaDato.listar();
        }

        // Mensajes de Registrar KDS
        public int Registrar(Servidor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.cod_marca) || string.IsNullOrWhiteSpace(obj.cod_marca))
            {
                Mensaje = "El campo empresa no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.cod_tienda) || string.IsNullOrWhiteSpace(obj.cod_tienda))
            {
                Mensaje = "El campo con_tienda no puede estar vacio.";

            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "El campo tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.ip_servidor) || string.IsNullOrWhiteSpace(obj.ip_servidor))
            {
                Mensaje = "El campo IP no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.nom_servidor) || string.IsNullOrWhiteSpace(obj.nom_servidor))
            {
                Mensaje = "El campo nombre no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.modelo) || string.IsNullOrWhiteSpace(obj.modelo))
            {
                Mensaje = "El campo modelo no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "El campo serie no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.sistema_operativo) || string.IsNullOrWhiteSpace(obj.sistema_operativo))
            {
                Mensaje = "El campo sistema operativo no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.version_micros) || string.IsNullOrWhiteSpace(obj.version_micros))
            {
                Mensaje = "El campo sistema operativo no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.memoria_ram) || string.IsNullOrWhiteSpace(obj.memoria_ram))
            {
                Mensaje = "El campo memoria ram no puede estar vacío.";

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
        public bool Editar(Servidor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.cod_marca) || string.IsNullOrWhiteSpace(obj.cod_marca))
            {
                Mensaje = "El campo empresa no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.cod_tienda) || string.IsNullOrWhiteSpace(obj.cod_tienda))
            {
                Mensaje = "El campo con_tienda no puede estar vacio.";

            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "El campo tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.ip_servidor) || string.IsNullOrWhiteSpace(obj.ip_servidor))
            {
                Mensaje = "El campo IP no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.nom_servidor) || string.IsNullOrWhiteSpace(obj.nom_servidor))
            {
                Mensaje = "El campo nombre no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.modelo) || string.IsNullOrWhiteSpace(obj.modelo))
            {
                Mensaje = "El campo modelo no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "El campo serie no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.sistema_operativo) || string.IsNullOrWhiteSpace(obj.sistema_operativo))
            {
                Mensaje = "El campo sistema operativo no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.version_micros) || string.IsNullOrWhiteSpace(obj.version_micros))
            {
                Mensaje = "El campo sistema operativo no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.memoria_ram) || string.IsNullOrWhiteSpace(obj.memoria_ram))
            {
                Mensaje = "El campo memoria ram no puede estar vacío.";

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
            return objCapaDato.Eliminarservidor(id, out Mensaje);
        }

        // Detalle
        public Servidor Detalle(int idTienda)
        {
            return objCapaDato.Detalle(idTienda);
        }
    }
}
