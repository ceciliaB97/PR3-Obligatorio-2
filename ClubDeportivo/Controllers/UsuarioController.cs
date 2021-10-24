using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auxiliar;
using Dominio;

namespace ClubDeportivo.Controllers
{
    public class UsuarioController : Controller
    {
        Facade f1 = Facade.Instance;

        // GET: Usuario/Create
        public ActionResult RegistrarUsuario()
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }

        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario usuario)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (Usuario.validarDatosUsuario(usuario))
                {
                    // TODO: Add insert logic here
                    bool alta = f1.AltaUsuario(usuario.Mail, usuario.Password);
                    if (alta)
                    {
                        ViewBag.Message = "Usuario creado exitosamente";
                        return View("Success");
                    }
                }

                ViewBag.Message = "Hubo un error al crear el usuario"; //implementar codigo de error en usuario dominio
                return View("Error");
            }


        }

    }
}
