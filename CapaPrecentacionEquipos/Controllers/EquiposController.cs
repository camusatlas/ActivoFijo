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
        public JsonResult ListarEquipos(int idcategoria, int idmarca)
        {
            List<Equipo> lista = new List<Equipo>();
            bool conversion;

            lista = new CN_Equipo().Listar().Where(p =>
                p.oCategoria.IdCategoria == (idcategoria == 0 ? p.oCategoria.IdCategoria : idcategoria) &&
                p.oMarca.IdMarca == (idmarca == 0 ? p.oMarca.IdMarca : idmarca) &&
                p.Stock > 0 && p.Activo == true
            ).Select(p => new Equipo()
            {
                IdEquipos = p.IdEquipos,
                oCategoria = p.oCategoria,
                Nombre = p.Nombre,
                oMarca = p.oMarca,
                Precio = p.Precio,
                Stock = p.Stock,
                Activo = p.Activo
            }).ToList();

            var resultado = lista.Select(p => new
            {
                IdEquipos = p.IdEquipos,
                Nombre = p.Nombre,
                oMarca = p.oMarca,
                oCategoria = new
                {
                    IdCategoria = p.oCategoria.IdCategoria,
                    Descripcion = p.oCategoria.Descripcion,
                    RutaImagen = (p.oCategoria != null && !string.IsNullOrEmpty(p.oCategoria.RutaImagen) && !string.IsNullOrEmpty(p.oCategoria.NombreImagen))
                        ? Path.Combine(p.oCategoria.RutaImagen, p.oCategoria.NombreImagen)
                        : string.Empty,
                    Base64 = (p.oCategoria != null && !string.IsNullOrEmpty(p.oCategoria.RutaImagen) && !string.IsNullOrEmpty(p.oCategoria.NombreImagen))
                        ? CN_Recursos.ConvertirBase64(Path.Combine(p.oCategoria.RutaImagen, p.oCategoria.NombreImagen), out conversion)
                        : string.Empty,
                    Extension = (p.oCategoria != null && !string.IsNullOrEmpty(p.oCategoria.NombreImagen))
                        ? Path.GetExtension(p.oCategoria.NombreImagen)
                        : string.Empty,
                },
                Precio = p.Precio,
                Stock = p.Stock,
                Activo = p.Activo,
            }).ToList();

            var jsonresult = Json(new { data = resultado }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;

            return jsonresult;
        }






        //[HttpPost]
        //public JsonResult ListarEquipos(int idcategoria, int idmarca)
        //{
        //    List<Equipo> lista = new CN_Equipo().Listar().Where(p =>
        //        p.oCategoria.IdCategoria == (idcategoria == 0 ? p.oCategoria.IdCategoria : idcategoria) &&
        //        p.oMarca.IdMarca == (idmarca == 0 ? p.oMarca.IdMarca : idmarca) &&
        //        p.Stock > 0 && p.Activo == true
        //    ).Select(p => new Equipo()
        //    {
        //        // Otras asignaciones

        //        // Asignaciones relacionadas con la imagen de la categoría
        //        RutaImagenCategoria = p.oCategoria.RutaImagen,
        //        NombreImagenCategoria = p.oCategoria.NombreImagen,

        //        // Otras propiedades de Equipo
        //        IdEquipos = p.IdEquipos,
        //        Nombre = p.Nombre,
        //        oMarca = p.oMarca,
        //        oCategoria = p.oCategoria,
        //        Precio = p.Precio,
        //        Stock = p.Stock,
        //        Activo = p.Activo
        //    }).ToList();

        //    var resultado = lista.Select(p => new
        //    {
        //        IdEquipos = p.IdEquipos,
        //        Nombre = p.Nombre,
        //        oMarca = p.oMarca,
        //        oCategoria = new
        //        {
        //            IdCategoria = p.oCategoria.IdCategoria,
        //            Descripcion = p.oCategoria.Descripcion,
        //            RutaImagen = p.RutaImagenCategoria, // Utiliza la propiedad RutaImagenCategoria
        //            Base64 = ObtenerBase64CategoriaImagen(p.oCategoria),
        //            Extension = ObtenerExtensionCategoriaImagen(p.oCategoria),
        //        },
        //        Precio = p.Precio,
        //        Stock = p.Stock,
        //        Activo = p.Activo,
        //    }).ToList();

        //    var jsonresult = Json(new { data = resultado }, JsonRequestBehavior.AllowGet);
        //    jsonresult.MaxJsonLength = int.MaxValue;

        //    return jsonresult;
        //}


        //private string ObtenerBase64CategoriaImagen(Categoria categoria)
        //{
        //    if (categoria == null || string.IsNullOrEmpty(categoria.RutaImagen) || string.IsNullOrEmpty(categoria.NombreImagen))
        //    {
        //        // Manejar el caso en el que alguno de los valores es nulo o cadena vacía
        //        return string.Empty;
        //    }

        //    bool conversion;
        //    return CN_Recursos.ConvertirBase64(Path.Combine(categoria.RutaImagen, categoria.NombreImagen), out conversion);
        //}

        //private string ObtenerExtensionCategoriaImagen(Categoria categoria)
        //{
        //    return Path.GetExtension(categoria.NombreImagen);
        //}

    }
}