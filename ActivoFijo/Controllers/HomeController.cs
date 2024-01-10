using ActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ActivoFijo.Controllers
{
    [Authorize]
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
        /* Funciones de WorSatation */
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
        /* Funciones de KDS */
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
        /* Funciones de la PCGerencial */
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
        public ActionResult RaonSocial()
        {
            return View();
        }

        #endregion

        #region Tecnico
        public ActionResult Tecnico()
        {
            return View();
        }

        #endregion

        #region Prioridad
        public ActionResult Prioridad()
        {
            return View();
        }

        #endregion

        #region Equipo
        public ActionResult Equipo()
        {
            return View();
        }

        #endregion
    }
}