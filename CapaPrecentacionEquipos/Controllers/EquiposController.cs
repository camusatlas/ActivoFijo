using ActivoFijo.Models;
using DocumentFormat.OpenXml.Bibliography;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                oRazonSocial = p.oRazonSocial,
                Serie = p.Serie,
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
        public JsonResult ObtenerTienda(string idmarcatienda)
        {
            List<Tienda> oLista = new List<Tienda>();

            oLista = new CN_Asignado().ObtenerTienda(idmarcatienda);

            return Json(new { lista = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ObtenerTecnico()
        {
            List<Tecnico> oLista = new List<Tecnico>();

            oLista = new CN_Asignado().ObtenerTecnico();

            return Json(new { lista = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarEquipoCarrito()
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
                    Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oc.oEquipo.RutaImagen, oc.oEquipo.NombreImagen), out conversion),
                    Extension = Path.GetExtension(oc.oEquipo.NombreImagen)
                },
                Cantidad = oc.Cantidad
            }).ToList();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> ProcesarPago(List<Carrito> oListaCarrito, Venta oVenta)
        {
            decimal total = 0;

            DataTable detalle_venta = new DataTable();
            detalle_venta.Locale = new CultureInfo("es-PE");
            detalle_venta.Columns.Add("IdEquipos", typeof(string));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("Total", typeof(decimal));

            foreach (Carrito oCarrito in oListaCarrito)
            {
                decimal subtotal = Convert.ToDecimal(oCarrito.Cantidad.ToString()) * oCarrito.oEquipo.Precio;

                total += subtotal;
                detalle_venta.Rows.Add(new object[]
                {
                    oCarrito.oEquipo.IdEquipos,
                    oCarrito.Cantidad,
                    subtotal,
                });

            }

            oVenta.MontoTotal = total;
            oVenta.IdUsuario = ((Usuario)Session["Usuario"]).IdUsuario;

            TempData["Venta"] = oVenta;
            TempData["DetalleVenta"] = detalle_venta;

            return Json(new { Status = true, Link = "/Equipos/Pagoefectuado?idTransaccion=code0001&status=true" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PagoEfectuado()
        {
            string idtransaccion = Request.QueryString["idTransaccion"];
            bool status = Convert.ToBoolean(Request.QueryString["status"]);

            ViewData["Status"] = status;

            if (status)
            {
                Venta oVenta = (Venta)TempData["Venta"];

                DataTable detalle_venta = (DataTable)TempData["DetalleVenta"];

                oVenta.IdTransaccion = idtransaccion;

                string mensaje = string.Empty;

                bool respuesta = new CN_Venta().Registrar(oVenta, detalle_venta, out mensaje);

                ViewData["IdTransaccion"] = oVenta.IdTransaccion;
            }

            return View();
        }

    }
}