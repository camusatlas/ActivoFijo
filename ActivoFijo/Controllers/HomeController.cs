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
        [HttpGet]
        public JsonResult ListarServidor()
        {
            List<Servidor> oLista = new List<Servidor>();
            oLista = new CN_Servidor().ListarServidores();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GuardarServidor(Servidor objeto)
        {
            string mensaje = string.Empty;
            CN_Servidor gestionServidor = new CN_Servidor();

            string resultado = string.IsNullOrEmpty(objeto.ip_servidor)
                ? gestionServidor.RegistrarServidor(objeto)
                : gestionServidor.ActualizarServidor(objeto);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult EliminarServidor(string tienda)
        {
            string mensaje = string.Empty;
            CN_Servidor gestionServidor = new CN_Servidor();

            string resultado = gestionServidor.EliminarServidor(tienda);

            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        /* Funciones de WorSatation */


        /* Funciones de KDS */
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
    }
}