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

                            for (var k = 1; k < csvParsed.Count; k++)
                            {
                                Usuario user = new Usuario
                                {
                                    //  Id = int.Parse(csvParsed[k][0]),
                                    Mail = csvParsed[k][1],
                                    Password = csvParsed[k][2]
                                };

                                if (!TryValidateModel(user))
                                {
                                    var modelErrors = "";
                                    foreach (ModelState modelState in ModelState.Values)
                                    {
                                        foreach (ModelError error in modelState.Errors)
                                        {
                                            modelErrors += error.ErrorMessage + "  |  ";
                                        }
                                    }
                                    throw new Exception($" Error ar dal de alta usuario : {user.Mail} , {user.Password} , Errors: {modelErrors}");
                                }
                                else
                                {
                                    //si el usuario está repetido, el alta no lo agrega
                                    Facade.Instance.AltaUsuario(user.Mail, user.Password);
                                }
                            }
                        }

                        if (tipoImport == 1) //actividades
                        {

                            for (var k = 1; k < csvParsed.Count; k++)
                            {
                                Actividad actAux = new Actividad
                                {
                                    //  Id = int.Parse(csvParsed[k][0]),
                                    Nombre = csvParsed[k][1],
                                    EdadMinima = int.Parse(csvParsed[k][2]),
                                    EdadMaxima = int.Parse(csvParsed[k][3]),
                                    Active = bool.Parse(csvParsed[k][4]),
                                    Cupos = int.Parse(csvParsed[k][5])

                                };

                                string horarioSTR = csvParsed[k][6];

                                string[] listaHorariosSTR = horarioSTR.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                List<Horario> listaHorarios = new List<Horario>();

                                foreach (string horarioSTRAux in listaHorariosSTR)
                                {
                                    string[] values = horarioSTRAux.Split(new char[] { '/' });

                                    Horario HorarioAux = new Horario
                                    {
                                        DiaSemana = (DayOfWeek)int.Parse(values[0]),
                                        Hora = int.Parse(values[1])
                                    };


                                    listaHorarios.Add(HorarioAux);
                                }

                                actAux.ActividadHorarios = listaHorarios;

                                Actividad actBuscar = Facade.Instance.BuscarActividad(actAux.Nombre);

                                if (actBuscar == null)
                                {
                                    if (!TryValidateModel(actAux) || !Facade.Instance.AltaActividad(actAux))
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }

                }

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