using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Equipo
    {
        private CD_Equipo objCapaDato = new CD_Equipo();
        public List<Equipo> Listar()
        {
            return objCapaDato.listar();
        }
        // Mensaje de Respuesta al Registrar Categoria
        public int Registrar(Equipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "La descripcion de la Categoria no puede ser vacio";
            }
            else if (obj.oMarca.IdMarca == 0)
            {
                Mensaje = "Debe seleccionar una Marca";
            }
            else if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una Categoria";
            }
            else if (obj.Precio == 0)
            {
                Mensaje = "Ingresar el precio del equipo";
            }
            else if (obj.oSede.IdSede == 0)
            {
                Mensaje = "Debe seleccionar una Sede";
            }
            else if (obj.oModelo.IdModelo == 0)
            {
                Mensaje = "Debe seleccionar un Modelo";
            }
            else if (string.IsNullOrEmpty(obj.Serie) || string.IsNullOrWhiteSpace(obj.Serie))
            {
                Mensaje = "Ingresa la serie del Equipo";
            }
            else if (string.IsNullOrEmpty(obj.CodInventario) || string.IsNullOrWhiteSpace(obj.CodInventario))
            {
                Mensaje = "Ingresar el codigo de inventario";
            }
            else if (string.IsNullOrEmpty(obj.Usuario) || string.IsNullOrWhiteSpace(obj.Usuario))
            {
                Mensaje = "Ingresa el usuario del tecnico";
            }
            else if (string.IsNullOrEmpty(obj.GuiaIngreso) || string.IsNullOrWhiteSpace(obj.GuiaIngreso))
            {
                Mensaje = "Ingresar la guia de ingreso";
            }
            else if (obj.oProveedor.IdProveedor == 0)
            {
                Mensaje = "Debe seleccionar el proveedor";
            }
            else if (string.IsNullOrEmpty(obj.OrdenCompra) || string.IsNullOrWhiteSpace(obj.OrdenCompra))
            {
                Mensaje = "Ingresar el Orden de Compra";
            }
            else if (string.IsNullOrEmpty(obj.OrdenInterna) || string.IsNullOrWhiteSpace(obj.OrdenInterna))
            {
                Mensaje = "Ingresar la orden interna";
            }
            else  if (string.IsNullOrEmpty(obj.ActivoFijo) || string.IsNullOrWhiteSpace(obj.ActivoFijo))
            {
                Mensaje = "Ingresar el activo fijo";
            }
            else if (obj.oAlmacen.IdAlmacen == 0)
            {
                Mensaje = "Debe seleccionar el almacen";
            }
            else if (string.IsNullOrEmpty(obj.CodMaterialSAP) || string.IsNullOrWhiteSpace(obj.CodMaterialSAP))
            {
                Mensaje = "Ingresar el codigo de SAP";
            }
            else if ()
            {
                Mensaje = "";
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
    }
}