using Auxiliar;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClubDeportivo.Controllers
{
    public class ActividadController : Controller
    {
        public global::System.Object ConfigurationManager { get; private set; }

        // GET: Actividad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBy()
        {
            return View();
        }

        // GET: Actividad/GetByName/{name}
        public ActionResult GetByName(String name)
        {
            List<Actividad> actividades = null;
            HttpClient proxy = new HttpClient();

            //string ubicacionServicio = ConfigurationManager.AppSettings["ServidorWebApi"];
            string ubicacionServicio = WebConfigurationManager.AppSettings["ServidorWebApi"];
            string url = ubicacionServicio + "actividades/GetByName/" + name;
            Uri uri = new Uri(url);

            Task<HttpResponseMessage> tarea1 = proxy.GetAsync(uri);
            tarea1.Wait();

            if (tarea1.Result.IsSuccessStatusCode)
            {
                Task<string> tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                actividades = JsonConvert.DeserializeObject<List<Actividad>>(json);
            }
            else
            {
                ViewBag.Error = "Hubo un problema al buscar las actividades (" + tarea1.Result.StatusCode + ")";
            }

            return View(actividades);
        }

        // GET: Actividad/GetByMinAge/{age}
        public ActionResult GetByMinAge(int age)
        {
            List<Actividad> actividades = null;
            HttpClient proxy = new HttpClient();
            //string ubicacionServicio = ConfigurationManager.AppSettings["ServidorWebApi"];
            string ubicacionServicio = WebConfigurationManager.AppSettings["ServidorWebApi"];
            string url = ubicacionServicio + "actividades/GetByMinAge/" + age;
            Uri uri = new Uri(url);

            Task<HttpResponseMessage> tarea1 = proxy.GetAsync(uri);
            tarea1.Wait();

            if (tarea1.Result.IsSuccessStatusCode)
            {
                Task<string> tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                actividades = JsonConvert.DeserializeObject<List<Actividad>>(json);
            }
            else
            {
                ViewBag.Error = "Hubo un problema al buscar las actividades (" + tarea1.Result.StatusCode + ")";
            }

            return View(actividades);
        }

        // GET: Actividad/GetBySchedule/{day}/{hour}
        public ActionResult GetBySchedule(DayOfWeek day, int hour)
        {
            List<Actividad> actividades = null;
            HttpClient proxy = new HttpClient();
            //string ubicacionServicio = ConfigurationManager.AppSettings["ServidorWebApi"];
            string ubicacionServicio = WebConfigurationManager.AppSettings["ServidorWebApi"];
            string url = ubicacionServicio + "actividades/GetBySchedule/" + $"{day}/{hour}";
            Uri uri = new Uri(url);

            Task<HttpResponseMessage> tarea1 = proxy.GetAsync(uri);
            tarea1.Wait();

            if (tarea1.Result.IsSuccessStatusCode)
            {
                Task<string> tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                tarea2.Wait();
                string json = tarea2.Result;
                actividades = JsonConvert.DeserializeObject<List<Actividad>>(json);
            }
            else
            {
                ViewBag.Error = "Hubo un problema al buscar las actividades (" + tarea1.Result.StatusCode + ")";
            }

            return View(actividades);
        }

        // GET: Actividad/Details/5
        public ActionResult Details(Actividad actividad)
        {
            return View(actividad);
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actividad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actividad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Actividad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actividad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
