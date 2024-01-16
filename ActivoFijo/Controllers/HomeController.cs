using ActivoFijo.Models;
using System;
using System.Collections.Generic;
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


    }
}