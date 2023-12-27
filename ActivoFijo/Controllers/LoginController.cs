using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivoFijo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        /*--------------------------------------------------*/
        public string ObtenerDisplayName(string dominio, string usuario, string pwd, string path)
        {
            string domainAndUsername = usuario + "@" + dominio;

            using (DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, pwd))
            {
                try
                {
                    using (DirectorySearcher search = new DirectorySearcher(entry))
                    {
                        search.Filter = "(samaccountname=" + usuario + ")";
                        search.PropertiesToLoad.Add("displayName");
                        SearchResult result = search.FindOne();

                        if (result != null)
                        {
                            return result.Properties["displayName"][0].ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    // Manejar el error apropiadamente
                    return null;
                }
            }

            return null;
        }





        /*--------------------------------------------------*/
        [HttpPost]
        public ActionResult Login(string usuario, string clave, string mensaje)
        {
            string ldapPath = "LDAP://192.168.0.6/DC=FRANQUICIASPERU,DC=COM";
            string username = usuario;
            string password = clave;
            string msn = mensaje;

            bool isAuthenticated = EstaAutenticado("FRANQUICIASPERU.COM", username, password, ldapPath, msn);

            if (isAuthenticated)
            {
                string displayName = ObtenerDisplayName("FRANQUICIASPERU.COM", username, password, ldapPath);

                // Establecer una variable de sesión o hacer otro tipo de seguimiento de inicio de sesión
                Session["usuario"] = usuario;
                Session["displayName"] = displayName;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }

        public bool EstaAutenticado(string dominio, string usuario, string pwd, string path, string msn)
        {
            // Armamos la cadena completa de dominio y usuario
            string domainAndUsername = usuario + "@" + dominio;

            // Creamos un objeto DirectoryEntry al cual le pasamos el URL, dominio/usuario y la contraseña
            using (DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, pwd))
            {
                try
                {
                    using (DirectorySearcher search = new DirectorySearcher(entry))
                    {
                        // Verificamos que los datos de logeo proporcionados son correctos
                        SearchResult result = search.FindOne();
                        return result != null;
                    }
                }
                catch (Exception)
                {
                    // Puedes manejar el error de alguna manera apropiada, como registrar o mostrar un mensaje
                    return false;
                }
            }
        }
        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
    public class VariableSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }

            base.OnActionExecuted(filterContext);
        }

    }


}
