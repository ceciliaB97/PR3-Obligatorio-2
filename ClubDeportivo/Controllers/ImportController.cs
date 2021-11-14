using Auxiliar;
using Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubDeportivo.Controllers
{
    public class ImportController : Controller
    {
      
        public ActionResult Index()
        {
            ViewBag.logueado = Session["Logueado"];
            ViewBag.mail = Session["LogueadoMail"];

            return View();
        }

       
        [HttpGet]
        public ActionResult ImportarDatos()
		{
            //@ViewBag.Message = "Import";
            return View();
		}

        [HttpPost]
        public ActionResult ImportarDatos(int tipoImport)/*HttpPostedFileBase file)*/
        {
            try
            {
                string _FileName = tipoImport == 0 ? "usuarios.csv" : "actividades.csv";
                string _path = Path.Combine(Server.MapPath("~/archivos"), _FileName);

                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(_path))
                {
                    string content = sr.ReadToEnd();
                    ViewBag.Content = content;

                }
                //if (file.ContentLength > 0)
                //{
                //    string _FileName = Path.GetFileName(file.FileName);
                //    string _path = Path.Combine(Server.MapPath("~/archivos"), _FileName);
                //    file.SaveAs(_path);
                //}
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!" + ex.Message;
                return View();
            }
        }

    }
}