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

        public ActionResult Usuarios()
        {
            return View();
        }

        public ActionResult Servidor()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarServidor()
        {
            List<Servidor> oLista = new List<Servidor>();

            oLista = new CN_Servidor().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }




        
    }
}