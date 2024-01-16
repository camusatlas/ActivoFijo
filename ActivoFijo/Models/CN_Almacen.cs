using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Almacen
    {
        private CD_Almacen objCapaDato = new CD_Almacen();

        public List<Almacen> Listar()
        {
            return objCapaDato.listar();
        }
        // Mensaje de Respuesta al Registrar Categoria
        public int Registrar(Almacen obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.NomAlmacen) || string.IsNullOrWhiteSpace(obj.NomAlmacen))
            {
                Mensaje = "La descripcion de la Marca no puede ser vacio";
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
        public bool Editar(Almacen obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NomAlmacen) || string.IsNullOrWhiteSpace(obj.NomAlmacen))
            {
                Mensaje = "La descripcion de la Marca no puede ser vacio";
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