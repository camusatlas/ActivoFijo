using ActivoFijo.Models;
using ClosedXML.Excel;
using Irony.Parsing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ActivoFijo.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /* Funciones de Servidores */
        public ActionResult Servidor()
        {
            return View();
        }
        /*Listo*/
        #region Servidor
        // Listar Servidor
        [HttpGet]
        public JsonResult ListarServidor()
        {
            List<Servidor> oLista = new List<Servidor>();

            oLista = new CN_Servidor().listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Guardar Servidor
        [HttpPost]
        public JsonResult GuardarServidor(Servidor objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdTienda == 0)
            {
                resultado = new CN_Servidor().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Servidor().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult EliminarServidor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Servidor().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion Servidor
        /* Listo */
        #region Worstation
        public ActionResult WorkStation()
        {
            return View();
        }

        // Listar WorkStation
        [HttpGet]
        public JsonResult ListarWorkStation()
        {
            List<WorkStation> oLista = new List<WorkStation>();

            oLista = new CN_WorkStation().listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Guardad 
        [HttpPost]
        public JsonResult GuardarWorkStation(WorkStation objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdWorkStation == 0)
            {
                resultado = new CN_WorkStation().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_WorkStation().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar WorkStation
        [HttpPost]
        public JsonResult EliminarWorkStation(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_WorkStation().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion Workstation
        /* Listo */
        #region KDS
        public ActionResult Kds()
        {
            return View();
        }

        // Listar KDS
        [HttpGet]
        public JsonResult ListarKDS()
        {
            List<KDS> oLista = new List<KDS>();

            oLista = new CN_KDS().listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Guardar KDS
        [HttpPost]
        public JsonResult GuardarKDS(KDS objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdKds == 0)
            {
                resultado = new CN_KDS().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_KDS().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar KDS
        [HttpPost]
        public JsonResult EliminarKDS(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_KDS().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion KDS
        /* Listo */
        #region PCGerencial
        public ActionResult PCGerencial()
        {
            return View();
        }

        // Listar PCGerencial
        [HttpGet]
        public JsonResult ListarPCGerencial()
        {
            List<PCGerencial> oLista = new List<PCGerencial>();

            oLista = new CN_PCGerencial().listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Guardar PCGerencial
        [HttpPost]
        public JsonResult GuardarPCGerencial(PCGerencial objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdPcdGerencial == 0)
            {
                resultado = new CN_PCGerencial().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_PCGerencial().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar PCGerencial
        [HttpPost]
        public JsonResult EliminarPCGerencial(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_KDS().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        /* Activo Fijo */
        public ActionResult Inventario()
        {
            return View();
        }
        #endregion PCGerencial
        /* Listo */
        #region Categoria

        public ActionResult Categoria()
        {
            return View();
        }

        // Listado de Categoria
        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<Categoria> oLista = new List<Categoria>();

            oLista = new CN_Categoria().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Registrar y Editar Categoria
        [HttpPost]
        public JsonResult GuardarCategoria(Categoria objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdCategoria == 0)
            {
                resultado = new CN_Categoria().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Categoria().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        

        // Eliminar Usuario
        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Categoria().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion Categoria
        /* Listo */
        #region Marca

        public ActionResult Marca()
        {
            return View();
        }

        // Listado de Categoria
        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<Marca> oLista = new List<Marca>();

            oLista = new CN_Marca().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Registrar y Editar Categoria
        [HttpPost]
        public JsonResult GuardarMarca(Marca objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdMarca == 0)
            {
                resultado = new CN_Marca().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Marca().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar Usuario
        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Marca().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion
        /* Listo */
        #region Sede
        public ActionResult Sede()
        {
            return View();
        }
        // Listar Sede
        [HttpGet]
        public JsonResult ListarSede()
        {
            List<Sede> oLista = new List<Sede>();

            oLista = new CN_Sede().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        // Registrar y Editar Sede
        [HttpPost]
        public JsonResult GuardarSede(Sede objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdSede == 0)
            {
                resultado = new CN_Sede().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Sede().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar Sede
        [HttpPost]
        public JsonResult EliminarSede(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Sede().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region RaonSocial
        public ActionResult RazonSocial()
        {
            return View();
        }
        // Listar RazonSocial
        [HttpGet]
        public JsonResult ListarRazonSocial()
        {
            List<RazonSocial> oLista = new List<RazonSocial>();

            oLista = new CN_RazonSocial().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        // Registrar y Editar RazonSocial
        [HttpPost]
        public JsonResult GuardarRazonSocial(RazonSocial objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdRazonSocial == 0)
            {
                resultado = new CN_RazonSocial().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_RazonSocial().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        // Eliminar Sede
        [HttpPost]
        public JsonResult EliminarRazonSocial(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_RazonSocial().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Tecnico
        public ActionResult Tecnico()
        {
            return View();
        }
        // Listar Tecnico
        [HttpGet]
        public JsonResult ListarTecnico()
        {
            List<Tecnico> oLista = new List<Tecnico>();

            oLista = new CN_Tecnico().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        // Registrar y Editar Tecnico
        [HttpPost]
        public JsonResult GuardarTecnico(Tecnico objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdTecnico == 0)
            {
                resultado = new CN_Tecnico().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Tecnico().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        // Eliminar Tecnico
        [HttpPost]
        public JsonResult EliminarTecnico(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Tecnico().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        /*Listo*/
        #region Almacen
        public ActionResult Almacen()
        {
            return View();
        }
        // Listar Sede
        [HttpGet]
        public JsonResult ListarAlmacen()
        {
            List<Almacen> oLista = new List<Almacen>();

            oLista = new CN_Almacen().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        // Registrar y Editar Sede
        [HttpPost]
        public JsonResult GuardarAlmacen(Almacen objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdAlmacen == 0)
            {
                resultado = new CN_Almacen().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Almacen().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        // Eliminar Sede
        [HttpPost]
        public JsonResult EliminarAlmacen(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Almacen().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Modelo

        public ActionResult Modelo()
        {
            return View();
        }

        // Listar Modelo
        [HttpGet]
        public JsonResult ListarModelo()
        {
            List<Modelo> oLista = new List<Modelo>();

            oLista = new CN_Modelo().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        // Registrar y Editar Modelo
        [HttpPost]
        public JsonResult GuardarModelo(Modelo objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdModelo == 0)
            {
                resultado = new CN_Modelo().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Modelo().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        // Eliminar Sede
        [HttpPost]
        public JsonResult EliminarModelo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Modelo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        /*Listo*/
        #region Prioridades
        public ActionResult Prioridad()
        {
            return View();
        }
        // Listar Sede
        [HttpGet]
        public JsonResult ListarPrioridad()
        {
            List<Prioridad> oLista = new List<Prioridad>();

            oLista = new CN_Prioridad().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        // Registrar y Editar Prioridad
        [HttpPost]
        public JsonResult GuardarPrioridad(Prioridad objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdPrioridades == 0)
            {
                resultado = new CN_Prioridad().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Prioridad().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        // Eliminar Prioridad
        [HttpPost]
        public JsonResult EliminarPrioridad(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Prioridad().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Equipo
        public ActionResult Equipo()
        {
            return View();
        }
        //Listar Equipo
        [HttpGet]
        public JsonResult ListarEquipo()
        {
            List<Equipo> oLista = new List<Equipo>();

            oLista = new CN_Equipo().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Guardar Equipo Registrar y Actualizar Equipos
        [HttpPost]
        public JsonResult GuardarEquipo(string objeto, HttpPostedFileBase archivoImagen)
        {
            string mensaje = string.Empty;

            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;

            Equipo oEquipo = new Equipo();
            oEquipo = JsonConvert.DeserializeObject<Equipo>(objeto);

            decimal precio;

            if (decimal.TryParse(oEquipo.PrecioTexto, NumberStyles.AllowDecimalPoint, new CultureInfo("es-PE"), out precio))
            {
                oEquipo.Precio = precio;
            }
            else
            {
                return Json(new { operacionExitosa = false, mensaje = "El formato del precio debe ser ###.##" }, JsonRequestBehavior.AllowGet);
            }

            if (oEquipo.IdEquipos == 0)
            {
                int idEquipoGenerado = new CN_Equipo().Registrar(oEquipo, out mensaje);

                if (idEquipoGenerado != 0)
                {
                    oEquipo.IdEquipos = idEquipoGenerado;
                }
                else
                {
                    operacion_exitosa = false;
                }
            }
            else
            {
                operacion_exitosa = new CN_Equipo().Editar(oEquipo, out mensaje);
            }
            if (operacion_exitosa)
            {
                if (archivoImagen != null)
                {
                    string ruta_guardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombre_imagen = string.Concat(oEquipo.IdEquipos.ToString(), extension);

                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar, nombre_imagen));
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        guardar_imagen_exito = false;
                    }

                    if (guardar_imagen_exito)
                    {
                        oEquipo.RutaImagen = ruta_guardar;
                        oEquipo.NombreImagen = nombre_imagen;
                        bool rsp = new CN_Equipo().GuardarDatosImagen(oEquipo, out mensaje);
                    }
                    else
                    {
                        mensaje = "Se guardo el producto pero hubo problemas con la imagen";
                    }

                }
            }
            return Json(new { operacionExitosa = operacion_exitosa, idGenerado = oEquipo.IdEquipos, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        // Guardar las imagenes de los equipos

        [HttpPost]
        public JsonResult ImagenEquipo(int id)
        {
            bool conversion;
            Equipo oEquipo = new CN_Equipo().Listar().Where(p => p.IdEquipos == id).FirstOrDefault();
            string textoBase64 = CN_Recursos.ConvertirBase64(Path.Combine(oEquipo.RutaImagen, oEquipo.NombreImagen), out conversion);
            return Json(new
            {
                conversion = conversion,
                textobase64 = textoBase64,
                extension = Path.GetExtension(oEquipo.NombreImagen)
            },
            JsonRequestBehavior.AllowGet);

        }


        // Eliminar Equipo
        [HttpPost]
        public JsonResult EliminarEquipo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Equipo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region SistemaOperativo

        public ActionResult SistemaOperativo()
        {
            return View();
        }
        // Listar Sede
        [HttpGet]
        public JsonResult ListarSistemaOperativo()
        {
            List<SistemaOperativo> oLista = new List<SistemaOperativo>();

            oLista = new CN_SistemaOperativo().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        // Registrar y Editar Sede
        [HttpPost]
        public JsonResult GuardarSistemaOperativo(SistemaOperativo objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdSistema == 0)
            {
                resultado = new CN_SistemaOperativo().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_SistemaOperativo().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar Sede
        [HttpPost]
        public JsonResult EliminarSistemaOperativo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_SistemaOperativo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion
        /*Listo*/
        #region Proveedor

        public ActionResult Proveedor()
        {
            return View();
        }

        // Listar Proveedor
        [HttpGet]
        public JsonResult ListarProveedor()
        {
            List<Proveedor> oLista = new List<Proveedor>();

            oLista = new CN_Proveedor().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        // Registrar y Editar Proveedor
        [HttpPost]
        public JsonResult GuardarProveedor(Proveedor objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdProveedor == 0)
            {
                resultado = new CN_Proveedor().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Proveedor().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar Proveedor
        [HttpPost]
        public JsonResult EliminarProveedor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Proveedor().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion
        /*Listo*/
        #region DashBoard
        // Vista de DashBoard
        [HttpGet]
        public JsonResult VistaDashBoard()
        {
            DashBoard objeto = new CN_Reportes().VerDashBoard();
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Reportes

        // Lista de Resportes
        [HttpGet]
        public JsonResult ListaReporte(string fechainicio, string fechafin, string idtransaccion)
        {
            List<Reporte> oLista = new List<Reporte>();

            oLista = new CN_Reportes().Ventas(fechainicio, fechafin, idtransaccion);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public FileResult ExportarVenta(string fechainicio, string fechafin, string idtransaccion)
        {
            List<Reporte> oLista = new List<Reporte>();
            oLista = new CN_Reportes().Ventas(fechainicio, fechafin, idtransaccion);

            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-Pe");
            dt.Columns.Add("Fecha Asigando", typeof(string));
            dt.Columns.Add("Tecnico", typeof(string));
            dt.Columns.Add("Equipo", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("IdTransaccion", typeof(string));


            foreach (Reporte rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.FechaVenta,
                    rp.Cliente,
                    rp.Equipo,
                    rp.Precio,
                    rp.Cantidad,
                    rp.Total,
                    rp.IdTransaccion
                });
            }
            dt.TableName = "Datos";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ResporteVenta" + DateTime.Now.ToString() + ".xlsx");
                }
            }

        }

        #endregion

        #region

        public ActionResult AsignacionEquipos()
        {
            return View();
        }

        #endregion
    }
}