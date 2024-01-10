using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Sede
    {
        private CD_Sede objCapaDato = new CD_Sede();

        public List<Sede> Listar()
        {
            return objCapaDato.listar();
        }
        public int Registrar(Sede obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.NomSede) || string.IsNullOrWhiteSpace(obj.NomSede))
            {
                Mensaje = "Ingresar el nombre de Sede";
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

        // MEnsaje de Respuesta al actualizar
        public bool Editar(Sede obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NomSede) || string.IsNullOrWhiteSpace(obj.NomSede))
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