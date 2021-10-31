using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Auxiliar;

namespace ClubDeportivo.Controllers
{
    public class MembresiaController : Controller
    {
        Facade f1 = new Facade();
        //Session["LogueadoMail"] = usuario.Mail;
        //Session["Logueado"] = true;
        public ActionResult Index()
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<Membresia> lista = f1.ListarMembresias();
                return View(lista);
            }

        }

        public ActionResult DetalleCuponera(Cuponera cuponera)
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

        public ActionResult DetallePaseLibre(PaseLibre paselibre)
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

        //public ActionResult RealizarPagoCuponera(int id)
        //{
        //    Cuponera cuponera = (Cuponera)f1.BuscarMembresia(id);
        //    if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //    else
        //    {
        //        if (cuponera.FechaPago == null)
        //        {
        //            ViewBag.FechaPago = DateTime.Today;
        //            bool res = f1.ModificacionFechaPagoHoyMembresia(cuponera);
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Pago ya ha sido realizado";
        //        }

        //        return View(cuponera);
        //    }

        //}

        //public ActionResult RealizarPagoLibre(int id)
        //{
        //    PaseLibre paselibre = (PaseLibre)f1.BuscarMembresia(id);
        //    if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //    else
        //    {
        //        if (paselibre.FechaPago == null)
        //        {
        //            ViewBag.FechaPago = DateTime.Today;
        //            bool res = f1.ModificacionFechaPagoHoyMembresia(paselibre);
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Pago ya ha sido realizado";
        //        }

        //        return View(paselibre);
        //    }

        //}

    }
}
