using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Prioridad
    {
        private CD_Prioridad objCapaDato = new CD_Prioridad();

        public List<Prioridad> Listar()
        {
            return objCapaDato.listar();
        }
        // Mensaje de Respuesta al Registrar Categoria
        public int Registrar(Prioridad obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.NomPrioridad) || string.IsNullOrWhiteSpace(obj.NomPrioridad))
            {
                Mensaje = "El nombre de la prioridad no puede ser vacio";
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
        public bool Editar(Prioridad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NomPrioridad) || string.IsNullOrWhiteSpace(obj.NomPrioridad))
            {
                Mensaje = "El nombre de la prioridad no puede ser vacio";
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