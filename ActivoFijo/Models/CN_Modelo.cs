using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Modelo
    {
        private CD_Modelo objCapaDato = new CD_Modelo();

        public List<Modelo> Listar()
        {
            return objCapaDato.listar();
        }
        // Mensaje de Respuesta al Registrar Categoria
        public int Registrar(Modelo obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.NomModelo) || string.IsNullOrWhiteSpace(obj.NomModelo))
            {
                Mensaje = "El nombre del la modelo no puede ser vacio";
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
        public bool Editar(Modelo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NomModelo) || string.IsNullOrWhiteSpace(obj.NomModelo))
            {
                Mensaje = "El nombre del la modelo no puede ser vacio";
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