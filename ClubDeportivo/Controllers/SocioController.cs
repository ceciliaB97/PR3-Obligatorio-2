using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Auxiliar;

namespace ClubDeportivo.Controllers
{
    public class SocioController : Controller
    {

        Facade facade = Facade.Instance;

        // GET: Socio
        public ActionResult Index()
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(facade.ListaroActualizarSocios());
            }

        }

        // GET: Socio/Details/5
        public ActionResult Details(int id)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Socio s = Facade.Instance.BuscarSocio(id);
                //s = Facade.Instance.ActualizarSocio(s);
                int edadSocio = DateTime.Now.Year - s.FechaNacimiento.Year;
                ViewBag.ActividadesDelDia = Facade.Instance.GetActividadesDia(edadSocio);

                return View(s);
            }

        }

        public ActionResult DetailsCedula(decimal cedula)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Socio s = Facade.Instance.BuscarSocioPorCedula(cedula);
                return View("Details", s);
            }

        }

        // GET: Socio/Create
        public ActionResult Create()
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Socio s = new Socio();
                return View(s);
            }

        }

        // POST: Socio/Create
        [HttpPost]
        public ActionResult Create(Socio socio)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // TODO: Add insert logic here
                if (Socio.ValidarDatos(socio))
                {
                    int crearSocio = facade.AltaSocio(socio);
                    if (crearSocio != -1)
                    {
                        ViewBag.Message = "El socio se ha creado exitosamente";
                        return View("Success");
                    }
                }

                ViewBag.Message = "Ha habido un error al registro del socio";
                return View("Error");

                //Si se desea se puede modificar para devolver mensajes de error 
            }

        }

        // GET: Socio/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Socio s = Facade.Instance.BuscarSocio(id);
                return View(s);
            }

        }

        // POST: Socio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Socio socio)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (Socio.ValidarDatos(socio))
                {
                    socio.Id = id;
                    var alta = Facade.Instance.ModificarSocio(socio);

                    return RedirectToAction("Index");
                }
            }

            ViewBag.Message = "Hubo un error al modificar los datos del usuario";
            return View("Error");
        }

        // GET: Socio/Delete/5
        public ActionResult Delete()
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                ViewBag.error = "";
                return View();
            }
        }

        // POST: Socio/Delete/5
        [HttpPost]
        public ActionResult DeleteDetalle(decimal cedula)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Socio s = Facade.Instance.BuscarSocioPorCedula(cedula);
                if (s != null)
                {
                    return View("Delete", s);
                }

                ViewBag.Message = "Socio no encontrado, verifique la cedula ingresada";
                return View("Error");
            }

        }

        public ActionResult DeleteDetalleInactivar(int idSocio) //Revisar mensajes de error 
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                bool baja = Facade.Instance.BajaSocio(idSocio);
                if (baja)
                {
                    ViewBag.error = "Baja existosa";
                    return View("Delete");
                }
                ViewBag.error = "Ha ocurrido un error";
                return View("Delete");
            }

        }

        public ActionResult BuscarPorCedula(decimal? cedula)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (cedula != null && cedula.HasValue)
                {
                    Socio s = Facade.Instance.BuscarSocioPorCedula(cedula.Value);
                    return View(s);
                }

                return View();
            }


        }

        public ActionResult IngresoSocioActividad(int idSocio, int idActividad, int hora)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                //TODO
                //CAMBIAR ESO PARA USAR WEBAPI

                // Create a client object with the given client endpoint configuration.
                //ServiceClient clubSolisClient = new ServiceClient("BasicHttpBinding_IService");

                //ActividadSocioDTOResult resService = clubSolisClient.IngresarSocioActividad(new ActividadSocioDTO
                //{
                //    Fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, 0, 0),
                //    IdActividad = idActividad,
                //    IdSocio = idSocio
                //});

                //if (resService.Success)
                //{
                //    Facade.ActualizarActividadesClub();

                //    ViewBag.Message = "Socio ingresado exitosamente en la actividad";
                //    return View("Success");
                //}
                //else
                //{
                //    ViewBag.Message = resService.Error;
                //    return View("Error");
                //}

                ViewBag.Message = "IMPLEMENTAR!";
                return View("Error");

            }

        }

        public ActionResult CreateCuponera(decimal cedula)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(new Cuponera());
            }

        }
        [HttpPost]
        public ActionResult CreateCuponera(int cedula, Cuponera cupo)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                if (cupo.CantActividades < 8 || cupo.CantActividades > 60)
                {
                    ViewBag.Message = "La cantidad de actividades es incorrecta, debe ser entre 8 y 60";
                    return View("Error");
                }

                Socio socio = facade.BuscarSocioPorCedula(cedula);

                if (!socio.ValidarPagoMembresia())
                {

                    Cuponera cuponera = (Cuponera)facade.PagarMensualidadSocio(cedula, cupo);

                    //agregar mensaje de success
                    return View(cuponera);
                }
                else
				{
                    ViewBag.Message = "Cuponera ya esta paga";
                    return View("Error");
                }

            }

        }

       
        public ActionResult CreatePaseLibre(int cedula)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Antiguedad = Facade.Instance.ObtenerAntiguedadSocio((int)cedula);
                return View(new PaseLibre());
            }

        }
        [HttpPost]
        public ActionResult CreatePaseLibre(int cedula, PaseLibre pase)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Socio socio = facade.BuscarSocioPorCedula(cedula);

                if (!socio.ValidarPagoMembresia())
                {
                    PaseLibre paseLibre = (PaseLibre)facade.PagarMensualidadSocio(cedula, pase);
                    //agregar mensaje de success
                    return View(paseLibre);
                }
                else
                {
                    ViewBag.Message = "Pase libre ya esta pago";
                    return View("Error");
                }

            }

        }


        public ActionResult ListarPaseLibrePorSocioId(int id)
        {
            Socio socio = facade.BuscarSocio(id);
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<PaseLibre> lista = facade.ListarMembresiasPorSocioId(socio).
                    Where(item => item.TipoMembresia == "paselibre").Cast<PaseLibre>().ToList();

                return View(lista);
            }

        }

        public ActionResult ListarMCuponeraPorSocioId(int id)
        {
            Socio socio = facade.BuscarSocio(id);
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<Cuponera> lista = facade.ListarMembresiasPorSocioId(socio).
                    Where(item => item.TipoMembresia == "cuponera").Cast<Cuponera>().ToList();

                return View(lista);
            }

        }

        [HttpGet]
        public ActionResult RealizarPagoCuponera(int id)
        {
            Cuponera cuponera = (Cuponera)facade.BuscarMembresia(id);
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                return View(cuponera);
            }

        }

        [HttpPost]
        public ActionResult RealizarPagoCuponera(Cuponera cuponera)
        {
            // Cuponera cuponera = (Cuponera)f1.BuscarMembresia(id);
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (cuponera.FechaPago == null)
                {
                    ViewBag.Message = "Pago realizado exitosamente";
                    //bool res = f1.ModificacionFechaPagoHoyMembresia(cuponera);
                    facade.ListaroActualizarSocios();
                }
                else
                {
                    ViewBag.Message = "Pago ya ha sido realizado";
                }

                return View("Success");
            }
        }

        [HttpGet]
        public ActionResult RealizarPagoLibre(int id)
        {
            PaseLibre paselibre = (PaseLibre)facade.BuscarMembresia(id);
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(paselibre);
            }
        }


        [HttpPost]
        public ActionResult RealizarPagoLibre(PaseLibre paselibre)
        {
            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (paselibre.FechaPago == null)
                {
                    ViewBag.Message = "Pago realizado exitosamente";
                    //bool res = f1.ModificacionFechaPagoHoyMembresia(paselibre);
                    facade.ListaroActualizarSocios();
                }
                else
                {
                    ViewBag.Message = "Pago ya ha sido realizado";
                }

                return View("Success");
            }

        }

        public ActionResult MostrarIngresosSocio(decimal cedula, DateTime? start, DateTime? end)
        {

            if (Session["LogueadoMail"] == null && Session["Logueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Cedula = cedula;
                if (start == null || !start.HasValue || end == null || !end.HasValue)
                {
                    var _now = DateTime.Now;
                    var _nowNextMonth = _now.AddMonths(1);
                    ViewBag.Datos = Facade.Instance.GetActividadSocioRango(cedula, new DateTime(_now.Year, _now.Month, 1),
                         new DateTime(_nowNextMonth.Year, _nowNextMonth.Month, 1)
                        );

                }
                else
                {
                    ViewBag.Datos = Facade.Instance.GetActividadSocioRango(cedula, start.Value, end.Value
                       );
                }


                return View();
            }
        }



    }
}
