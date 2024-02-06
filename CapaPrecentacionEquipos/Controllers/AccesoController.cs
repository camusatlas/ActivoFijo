using ActivoFijo.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CapaPrecentacionEquipos.Controllers
{
    public class AccesoController : Controller
    {

        #region Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave, string name)
        {
            Usuario oUsuario = null;

            oUsuario = new CN_Usuario().Listar().Where(item => item.Correo == correo && item.Clave == CN_Recursos.ConvertirSha256(clave)).FirstOrDefault();
            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no son correctas";
                return View();
            }
            else
            {
                if (oUsuario.Reestablecer)
                {
                    TempData["IdUsuario"] = oUsuario.IdUsuario;
                    return RedirectToAction("CambiarClave", "Acceso");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);

                    Session["Usuario"] = oUsuario;

                    ViewBag.Error = null;
                    return RedirectToAction("Index", "Equipos");
                }
            }
        }

        #endregion

        #region Regitrar

        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuario objeto)
        {
            int resultado;
            string mensaje = string.Empty;

            ViewData["Nombres"] = string.IsNullOrEmpty(objeto.Nombres) ? "" : objeto.Nombres;
            ViewData["Apellidos"] = string.IsNullOrEmpty(objeto.Apellidos) ? "" : objeto.Apellidos;
            ViewData["Correo"] = string.IsNullOrEmpty(objeto.Correo) ? "" : objeto.Correo;

            if (objeto.Clave != objeto.Confirmarclave)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            resultado = new CN_Usuario().Registrar(objeto, out mensaje);

            if (resultado > 0)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }

        #endregion Registrar

        #region Restablece

        public ActionResult Reestablecer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reestablecer(string correo)
        {
            Usuario usuario = new Usuario();
            usuario = new CN_Usuario().Listar().Where(item => item.Correo == correo).FirstOrDefault();

            if (usuario == null)
            {

                ViewBag.Error = "No se encontro un Cliente relacionado en ese correo";
                return View();
            }


            string mensaje = string.Empty;
            bool respuesta = new CN_Usuario().ReestablecerClave(usuario.IdUsuario, correo, out mensaje);

            if (respuesta)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }

        #endregion Restablece

        #region CambiarClave

        public ActionResult CambiarClave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarClave(string idusuario, string claveactual, string nuevaclave, string confirmaclave)
        {
            Usuario oUsuario = new Usuario();
            oUsuario = new CN_Usuario().Listar().Where(u => u.IdUsuario == int.Parse(idusuario)).FirstOrDefault();

            if (oUsuario.Clave != CN_Recursos.ConvertirSha256(claveactual))
            {
                TempData["IdUsuario"] = idusuario;
                ViewData["vclave"] = "";
                ViewBag.Error = "La contraseña actual no es corresta";
                return View();
            }
            else if (nuevaclave != confirmaclave)
            {
                TempData["IdUsuario"] = idusuario;
                ViewData["vclave"] = claveactual;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            ViewData["vclave"] = "";

            nuevaclave = CN_Recursos.ConvertirSha256(nuevaclave);

            string mensaje = string.Empty;
            bool respuesta = new CN_Usuario().CambiarClave(int.Parse(idusuario), nuevaclave, out mensaje);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IdUsuario"] = idusuario;

                ViewBag.Error = mensaje;
                return View();
            }
        }

        #endregion CambiarClave

        public ActionResult CerrarSesion()
        {

            Session["Usuario"] = null;

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Acceso");
        }

    }
}