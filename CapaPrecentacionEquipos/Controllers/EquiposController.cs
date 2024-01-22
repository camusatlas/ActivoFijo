using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPrecentacionEquipos.Controllers
{
    public class EquiposController : Controller
    {
        // GET: Equipos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EquiposVista()
        {
            return View();
        }
    }
}