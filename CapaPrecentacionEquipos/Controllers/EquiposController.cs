using ActivoFijo.Models;
using DocumentFormat.OpenXml.Bibliography;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
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

        //Detalle de Equipos
        public ActionResult DetalleEquipo(int idequipo = 0)
        {
            Equipo oEquipo = new Equipo();
            bool conversion;
            oEquipo = new CN_Equipo().Listar().Where(p => p.IdEquipos == idequipo).FirstOrDefault();

            if (oEquipo != null)
            {
                oEquipo.Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oEquipo.RutaImagen, oEquipo.NombreImagen), out conversion);
                oEquipo.Extension = Path.GetExtension(oEquipo.NombreImagen);
            }

            return View(oEquipo);
        }


        [HttpGet]
        public JsonResult ListCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            lista = new CN_Categoria().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ListaMarcaporCategoria(int idcategoria)
        {
            List<Marca> lista = new List<Marca>();

            lista = new CN_Marca().listarMarcaporCategoria(idcategoria);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarEquipo(int idcategoria, int idmarca)
        {
            List<Equipo> lista = new List<Equipo>();

            bool conversion;

            lista = new CN_Equipo().Listar().Select(p => new Equipo()
            {
                IdEquipos = p.IdEquipos,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                oMarca = p.oMarca,
                oCategoria = p.oCategoria,
                Precio = p.Precio,
                Stock = p.Stock,
                RutaImagen = p.RutaImagen,
                Base64 = CN_Recursos.ConvertirBase64(Path.Combine(p.RutaImagen, p.NombreImagen), out conversion),
                Extension = Path.GetExtension(p.NombreImagen),
                Activo = p.Activo
            }).Where(p =>
                p.oCategoria.IdCategoria == (idcategoria == 0 ? p.oCategoria.IdCategoria : idcategoria) &&
                p.oMarca.IdMarca == (idmarca == 0 ? p.oMarca.IdMarca : idmarca) &&
                p.Stock > 0 && p.Activo == true
            ).ToList();

            var jsonresult = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;

            return jsonresult;

        }

        public ActionResult Carrito()
        {
            return View();
        }

        // AGREGAR CARRITO
        [HttpPost]
        public JsonResult AgregarCarrito(int idequipo)
        {
            int idusuario = ((Usuario)Session["Usuario"]).IdUsuario;

            bool existe = new CN_Carrito().ExisteCarrito(idusuario, idequipo);

            bool respuesta = false;

            string mensaje = string.Empty;

            if (existe)
            {
                mensaje = "El equipo ya existe en el carrito";
            }
            else
            {
                respuesta = new CN_Carrito().OperacionCarrito(idusuario, idequipo, true, out mensaje);
            }
            return Json(new { respuesta = respuesta, mensaje = mensaje });
        }


        [HttpGet]
        public JsonResult CatidadEnCarrito()
        {
            int idusuario = ((Usuario)Session["Usuario"]).IdUsuario;
            int cantidad = new CN_Carrito().CantidadEnCarrito(idusuario);
            return Json(new { cantidad = cantidad }, JsonRequestBehavior.AllowGet);
        }

        // CREAR UN METODO POST LISTAR PRODUCTO
        [HttpPost]
        public JsonResult ListarProductosCarrito()
        {
            int idusuario = ((Usuario)Session["Usuario"]).IdUsuario;

            List<Carrito> oLista = new List<Carrito>();

            bool conversion;

            oLista = new CN_Carrito().ListarEquipo(idusuario).Select(oc => new Carrito()
            {
                oEquipo = new Equipo()
                {
                    IdEquipos = oc.oEquipo.IdEquipos,
                    Nombre = oc.oEquipo.Nombre,
                    oMarca = oc.oEquipo.oMarca,
                    Precio = oc.oEquipo.Precio,
                    RutaImagen = oc.oEquipo.RutaImagen,
                    Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oc.oEquipo.RutaImagen, oc.oEquipo.Nombre), out conversion),
                    Extension = Path.GetExtension(oc.oEquipo.NombreImagen)
                },
                Cantidad = oc.Cantidad
            }).ToList();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult OperacionCarrito(int idequipo, bool sumar)
        {
            int idusuario = ((Usuario)Session["Usuario"]).IdUsuario;

            bool existe = new CN_Carrito().ExisteCarrito(idusuario, idequipo);

            bool respuesta = false;

            string mensaje = string.Empty;

            respuesta = new CN_Carrito().OperacionCarrito(idusuario, idequipo, true, out mensaje);

            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCarrito(int idequipo)
        {
            int idusuario = ((Usuario)Session["Usuario"]).IdUsuario;

            bool respuesta = false;

            string mensaje = string.Empty;

            respuesta = new CN_Carrito().EliminarCarrito(idusuario, idequipo);

            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        //Obtener MarcaTienda
        public JsonResult ObtenerMarcaTienda()
        {
            List<MarcaTienda> oLista = new List<MarcaTienda>();

            oLista = new CN_Asignado().ObtenerMarcaTienda();

            return Json(new { lista = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerTienda(string idtiendamarca)
        {
            List<Tienda> oLista = new List<Tienda>();

            oLista = new CN_Asignado().ObtenerTienda(idtiendamarca);

            return Json(new { lista = oLista }, JsonRequestBehavior.AllowGet);
        }

    }
}