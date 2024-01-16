using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_SistemaOperativo
    {
        private CD_SistemaOperativo objCapaDato = new CD_SistemaOperativo();

        public List<SistemaOperativo> Listar()
        {
            return objCapaDato.listar();
        }
        public int Registrar(SistemaOperativo obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.NombreSistema) || string.IsNullOrWhiteSpace(obj.NombreSistema))
            {
                Mensaje = "Ingresar el nombre de Sistema Operativo";
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
        public bool Editar(SistemaOperativo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreSistema) || string.IsNullOrWhiteSpace(obj.NombreSistema))
            {
                Mensaje = "Ingresar el nombre de Sistema Operativo";
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