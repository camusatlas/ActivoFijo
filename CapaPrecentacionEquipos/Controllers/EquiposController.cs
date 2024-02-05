using ActivoFijo.Models;
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

        // AGREAR AL CARRITO
        [HttpPost]
        public JsonResult AgregarCarrito(int idequipo)
        {
            // Verificar si el usuario está autenticado
            if (Session["usuario"] != null && Session["usuario"] is string username)
            {
                // Obtener más información del usuario según tus necesidades
                string displayName = Session["displayName"] as string;

                // Ahora puedes usar 'username' y 'displayName' como necesites
                int idcliente = ObtenerIdClienteDesdeAlgunaFuente(username);

                bool existe = new CN_Carrito().ExisteCarrito(idcliente, idequipo);

                bool respuesta = false;
                string mensaje = string.Empty;

                if (existe)
                {
                    mensaje = "El equipo ya existe en el carrito";
                }
                else
                {
                    respuesta = new CN_Carrito().OperacionCarrito(idcliente, idequipo, true, out mensaje);
                }

                return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Manejar el caso donde el usuario no está autenticado
                return Json(new { respuesta = false, mensaje = "Usuario no autenticado" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Método de ejemplo para obtener el IdCliente desde alguna fuente (base de datos, servicio, etc.)
        private int ObtenerIdClienteDesdeAlgunaFuente(string username)
        {
            // Lógica para obtener el IdCliente asociado al nombre de usuario desde alguna fuente de datos
            // Puedes implementar esta lógica según la estructura de tu aplicación
            // En este ejemplo, simplemente devolvemos un valor fijo.
            return 1;
        }

    }
}