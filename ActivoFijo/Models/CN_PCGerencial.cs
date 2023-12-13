using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_PCGerencial
    {
        private CD_PCGerencial objCapaDato = new CD_PCGerencial();

        public List<PCGerencial> listar()
        {
            return objCapaDato.listarPCGerencial();
        }

        // Mensaje de Registrar PCGerencial
        public int Registrar(PCGerencial obj, out string Mensaje)
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
            else if (string.IsNullOrEmpty(obj.ip_gerente) || string.IsNullOrWhiteSpace(obj.ip_gerente))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.nom_pc_gerencial) || string.IsNullOrWhiteSpace(obj.nom_pc_gerencial))
            {
                Mensaje = "El nombre del departamento no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.modelo) || string.IsNullOrWhiteSpace(obj.modelo))
            {
                Mensaje = "El nombre de la provincia no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "El nombre del distrito no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.sistema_operativo) || string.IsNullOrWhiteSpace(obj.sistema_operativo))
            {
                Mensaje = "La dirección IP del KDS no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.memoria_ram) || string.IsNullOrWhiteSpace(obj.memoria_ram))
            {
                Mensaje = "El nombre del host no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.procesador) || string.IsNullOrWhiteSpace(obj.procesador))
            {
                Mensaje = "El nombre del host no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "El número de serie no puede estar vacío.";

            }
            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.RegistrarPCGerencial(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        // Mensaje de Editar PCGerencial
        public bool Editar(PCGerencial obj, out string Mensaje)
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
            else if (string.IsNullOrEmpty(obj.ip_gerente) || string.IsNullOrWhiteSpace(obj.ip_gerente))
            {
                Mensaje = "El nombre de la tienda no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.nom_pc_gerencial) || string.IsNullOrWhiteSpace(obj.nom_pc_gerencial))
            {
                Mensaje = "El nombre del departamento no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.modelo) || string.IsNullOrWhiteSpace(obj.modelo))
            {
                Mensaje = "El nombre de la provincia no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "El nombre del distrito no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.sistema_operativo) || string.IsNullOrWhiteSpace(obj.sistema_operativo))
            {
                Mensaje = "La dirección IP del KDS no puede estar vacía.";

            }
            else if (string.IsNullOrEmpty(obj.memoria_ram) || string.IsNullOrWhiteSpace(obj.memoria_ram))
            {
                Mensaje = "El nombre del host no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.procesador) || string.IsNullOrWhiteSpace(obj.procesador))
            {
                Mensaje = "El nombre del host no puede estar vacío.";

            }
            else if (string.IsNullOrEmpty(obj.serie) || string.IsNullOrWhiteSpace(obj.serie))
            {
                Mensaje = "El número de serie no puede estar vacío.";

            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarPCGerencial(obj, out Mensaje);
            }
            else
            {
                return objCapaDato.EditarPCGerencial(obj, out Mensaje);
            }
        }

        // Eliminar
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.EliminarPCGerencial(id, out Mensaje);
        }

    }
}