using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auxiliar;

namespace ClubDeportivo.Controllers
{
    public class LoginController : Controller
    {
        Facade f1 = new Facade();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult InicioSesion(Usuario usuario)
        {

            bool existe = f1.LoginUsuario(usuario.Mail, usuario.Password);

            if (existe)
            {
                Session["LogueadoMail"] = usuario.Mail;
                Session["Logueado"] = true;
                //se logueo
                return RedirectToAction("about", "Home");
            } else
            {
                ViewBag.Error = "Usuario y/o contraseña incorrectos";
            }

            return View("Index");
        }
        public ActionResult Logout()
        {
            Session["LogueadoMail"] = null;
            Session["Logueado"] = false;

            ViewBag.Mensaje = "Ha cerrado sesión exitosamente";

            return View("Index");
        }

    }
}
