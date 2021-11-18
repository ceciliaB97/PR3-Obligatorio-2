using Auxiliar;
using CryptoUtils;
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

                    List<string[]> csvParsed = CSVHelper.ParseCSV(content, '|');

                    if (csvParsed.Count > 0)
                    {
                        string[] header = csvParsed[0];

                        if (tipoImport == 0) //usuarios
						{

                            for (var k=1; k< csvParsed.Count;k++)
							{
                                Usuario user = new Usuario
                                {
                                  //  Id = int.Parse(csvParsed[k][0]),
                                    Mail = csvParsed[k][1],
                                    Password = csvParsed[k][2]
                                };

                                //string encryptpsw = Crypto.Encrypt(user.Password);
                                //string decryptPsw = Crypto.Decrypt(csvParsed[k][3]);

                                if (!TryValidateModel(user) || !Facade.Instance.AltaUsuario(user.Mail,user.Password))
								{
                                    var modelErrors = "";
                                    foreach (ModelState modelState in ModelState.Values)
                                    {
                                        foreach (ModelError error in modelState.Errors)
                                        {
                                            modelErrors += error.ErrorMessage+"  |  ";
                                        }
                                    }
                                    throw new Exception($" Error ar dal de alta usuario : {user.Mail} , {user.Password} , Errors: {modelErrors}");
								}
							}
						}
                    }

                    //ViewBag.Content = content;

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
                ViewBag.Message = ex.Message;
                return View();
            }
        }

    }
}