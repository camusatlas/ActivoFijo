using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivoFijo.Models;
using Microsoft.Ajax.Utilities;

namespace ActivoFijo.Models
{
    public class CN_WorkStation
    {
        private CD_WorkStation objCapaDato = new CD_WorkStation();

        public List<WorkStation> listar()
        {
            return objCapaDato.listar();
        }
        // Mensaje de Registros
        public int Registrar(WorkStation obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.cod_marca) || string.IsNullOrWhiteSpace(obj.cod_marca))
            {
                Mensaje = "El nombre de la empresa no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.cod_tienda) || string.IsNullOrWhiteSpace(obj.cod_tienda))
            {
                Mensaje = "La marca no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.caja) || string.IsNullOrWhiteSpace(obj.caja))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.ip_workstation) || string.IsNullOrWhiteSpace(obj.ip_workstation))
            {
                Mensaje = "El nombre del departamento no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.hostname) || string.IsNullOrWhiteSpace(obj.hostname))
            {
                Mensaje = "El nombre de la provincia no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.tipo) || string.IsNullOrWhiteSpace(obj.tipo))
            {
                Mensaje = "El nombre del distrito no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.modelo) || string.IsNullOrWhiteSpace(obj.modelo))
            {
                Mensaje = "La dirección IP del KDS no puede estar vacía.";

            }
            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.RegistrarWorkSation(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        // Mensaje de Editar
        public bool Editar(WorkStation obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.cod_marca) || string.IsNullOrWhiteSpace(obj.cod_marca))
            {
                Mensaje = "El nombre de la empresa no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.cod_tienda) || string.IsNullOrWhiteSpace(obj.cod_tienda))
            {
                Mensaje = "La marca no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.tienda) || string.IsNullOrWhiteSpace(obj.tienda))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.caja) || string.IsNullOrWhiteSpace(obj.caja))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.ip_workstation) || string.IsNullOrWhiteSpace(obj.ip_workstation))
            {
                Mensaje = "El nombre del departamento no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.hostname) || string.IsNullOrWhiteSpace(obj.hostname))
            {
                Mensaje = "El nombre de la provincia no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.tipo) || string.IsNullOrWhiteSpace(obj.tipo))
            {
                Mensaje = "El nombre del distrito no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.modelo) || string.IsNullOrWhiteSpace(obj.modelo))
            {
                Mensaje = "La dirección IP del KDS no puede estar vacía.";

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