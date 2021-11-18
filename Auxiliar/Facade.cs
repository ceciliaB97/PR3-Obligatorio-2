using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;
using System.Data;
using System.Web;

namespace Auxiliar
{
    public class Facade
    {
        public static Configuration Configuration { get; set; }
        public static Dictionary<int, Actividad> ActividadesClub { get; set; }
        private static Dictionary<int, Socio> mapSocio;// = new Dictionary<int, Socio>();
        private static Dictionary<int, Actividad> mapActividad;// = new Dictionary<int, Actividad>();

        public static Facade _instance = null;
        public static Facade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Facade();
                }

                return _instance;
            }
        }

        public static void ActualizarActividadesClub()
        {
            Facade.ActividadesClub = new Dictionary<int, Actividad>();
            IRepoActividad ra = FabricaRepositorios.ObtenerRepoActividad();

            List<Actividad> actividades = ra.Listar();
            foreach (var act in actividades)
            {
                act.ActividadHorarios = ra.ListarHorariosActividad(act.Id);

                Facade.ActividadesClub.Add(act.Id, act);
            }
        }

        public Facade()
        {
        }

        #region metodos

        public int AltaMembresia(decimal cedula, Membresia m)
        {
            IRepoMembresia rm = FabricaRepositorios.ObtenerRepoMembresia();
            IRepoSocios rs = FabricaRepositorios.ObtenerRepoSocios();
            int idSocio = rs.BuscarPorCedula(cedula).Id;

            m.FechaPago = DateTime.Now;
            m.Anio = m.FechaPago.Value.Year;
            m.Mes = m.FechaPago.Value.Month;
         
            //Aqui se hace el alta de la membresia y al mismo tiempo se le asigna al socio indicado
            return FabricaRepositorios.ObtenerRepoMembresia().Alta(idSocio, m);
        }

        public List<ActividadSocio> GetActividadSocioRango(decimal cedula, DateTime start, DateTime end)
		{
            IRepoSocios rs = FabricaRepositorios.ObtenerRepoSocios();
            Socio s = rs.BuscarPorCedula(cedula);
            s = ActualizarSocio(s);
            return s.ActividadSocios.Where(e => e.Fecha >= start && e.Fecha < end).ToList();

        }
        public List<ActividadHorarioDTO> GetActividadesDia(int edadSocio)
        {
            List<ActividadHorarioDTO> result = new List<ActividadHorarioDTO>();
            DateTime _now = DateTime.Now;

            foreach (Actividad actividad in ActividadesClub.Values)
            {

                if (actividad.Cupos > 0 && edadSocio >= actividad.EdadMinima && edadSocio <=actividad.EdadMaxima)
                {
                    foreach (var h in actividad.ActividadHorarios)
                    {
                        if (h.DiaSemana == _now.DayOfWeek && h.Hora > _now.Hour) //verificar si puede entrar a la actividad
                        {
                            result.Add(new ActividadHorarioDTO
                            {
                                Id = actividad.Id,
                                Hora = h.Hora,
                                Nombre = actividad.Nombre
                            });
                        }
                    }
                }
            }

            return result.OrderBy(e => e.Hora).ToList();

        }

        public bool BajaMembresia(int id)
        {
            IRepoMembresia rm = FabricaRepositorios.ObtenerRepoMembresia();
            return rm.Baja(id);
        }

        public bool ModificacionFechaPagoHoyMembresia(Membresia m)
        {
            IRepoMembresia rm = FabricaRepositorios.ObtenerRepoMembresia();
            bool res = rm.ModificarFechaPagoHoy(m);
            return res;
        }

        public List<Membresia> ListarMembresias()
        {
            IRepoMembresia rm = FabricaRepositorios.ObtenerRepoMembresia();
            return rm.Listar();
        }

        public List<Membresia> ListarMembresiasPorSocioId(Socio socio)
        {
            //IRepoMembresia rm = FabricaRepositorios.ObtenerRepoMembresia();
            //List<Membresia> lista = rm.ListarPorSocioId(socio.IdSocio);
            //mapSocio[socio.IdSocio].Membresias.Clear();
            //List<Membresia> listaSocio = mapSocio[socio.IdSocio].Membresias;
            //foreach (var item in lista)
            //{
            //    if (item.TipoMembresia == "cuponera")
            //    {
            //        listaSocio.Add((Cuponera)item);
            //    }

            //    if (item.TipoMembresia == "paselibre")
            //    {
            //        listaSocio.Add((PaseLibre)item);
            //    }
            //}

            try
            {
                return FabricaRepositorios.ObtenerRepoMembresia().ListarPorSocioId(socio.Id); 
                    //mapSocio[socio.Id].Membresias;
            } catch(Exception err)
            {
                return new List<Membresia>();
            }
            //return mapSocio[socio.IdSocio].Membresias; //socio.Membresias;
        }

        public List<Actividad> ListarActividades()
        {
            return new List<Actividad>();
        }

        public Actividad BuscarActividad(int id)
        {
            return new Actividad();
        }

        public int AltaSocio(Socio socio)
        {
            if (Socio.ValidarDatos(socio))
            {
                IRepoSocios rs = FabricaRepositorios.ObtenerRepoSocios();
                Socio s = new Socio()
                {
                    Cedula = socio.Cedula,
                    NombreApellido = socio.NombreApellido,
                    FechaNacimiento = socio.FechaNacimiento,
                    FechaIngreso = DateTime.Now.ToLocalTime(),
                    Activo = true
                };

                return rs.Alta(s);
            }

            return -1;
        }

        public bool BajaSocio(int id)
        {
            bool s = FabricaRepositorios.ObtenerRepoSocios().Baja(id);
            return s;
        }

        public Socio ModificarSocio(Socio socio)
        {
            return FabricaRepositorios.ObtenerRepoSocios().Modificacion(socio);
        }

        public Socio BuscarSocio(int id)
        {
            Socio s = FabricaRepositorios.ObtenerRepoSocios().Buscar(id);
            return s;
        }

        public Socio ActualizarSocio(Socio socio)
        {
            //if (socio == null)
            //{
            //    return null;
            //}

            //IRepoSocios rs = FabricaRepositorios.ObtenerRepoSocios();
            //List<Membresia> membresia = FabricaRepositorios.ObtenerRepoMembresia().Listar();
            //List<SocioMembresia> socioMembresia = rs.ListarSocioMembresia();

            //List<SocioActividad> socioActividades = rs.ListarSocioActividad();

            //foreach (SocioMembresia m in socioMembresia)
            //{
            //    if (socio.Id == m.Socio.Id)
            //    {
            //        Membresia mem = BuscarMembresiaEnLista(membresia, m.IdMembresia);
            //        if (mem != null)
            //        {
            //            socio.Membresias.Add(mem);
            //        }
            //        else
            //        {
            //            throw new Exception("Base de datos inconsisitente");
            //        }
            //    }

            //}


            //foreach (SocioActividad sa in socioActividades)
            //{
            //    if (socio.Id == sa.IdSocio)
            //    {
            //        Actividad actividad =
            //                            Facade.ActividadesClub.ContainsKey(sa.IdActividad) ? Facade.ActividadesClub[sa.IdActividad] :
            //                             null;

            //        if (actividad != null)
            //        {
            //            socio.ActividadSocios.Add(new ActividadSocio
            //            {
            //                Actividad = actividad,
            //                Socio = socio,
            //                Fecha = sa.Fecha
            //            });
            //        }
            //        else
            //        {
            //            throw new Exception("Base de datos inconsisitente");
            //        }
            //    }

            //}

            return FabricaRepositorios.ObtenerRepoSocios().Modificacion(socio);
        }

        public List<Socio> ListaroActualizarSocios()
        {
            //mapSocio = new Dictionary<int, Socio>();
            //mapActividad = new Dictionary<int, Actividad>();

            //IRepoSocios rs = FabricaRepositorios.ObtenerRepoSocios();
            //List<Socio> lista = rs.Listar();
            //List<Membresia> membresia = FabricaRepositorios.ObtenerRepoMembresia().Listar();
            //List<SocioMembresia> socioMembresia = rs.ListarSocioMembresia();

            //List<SocioActividad> socioActividades = rs.ListarSocioActividad();

            //foreach (SocioMembresia m in socioMembresia)
            //{
            //    Socio socio = null;
            //    if (!mapSocio.ContainsKey(m.Socio.Id))
            //    {
            //        socio = BuscarSocioEnLista(lista, m.Socio.Id);
            //        mapSocio.Add(m.Socio.Id, socio);
            //    }
            //    else
            //    {
            //        socio = mapSocio[m.Socio.Id];
            //    }


            //    Membresia mem = BuscarMembresiaEnLista(membresia, m.IdMembresia);
            //    if (socio != null && mem != null)
            //    {
            //        socio.Membresias.Add(mem);
            //    }
            //    else
            //    {
            //        throw new Exception("Base de datos inconsisitente");
            //    }
            //}


            //foreach (SocioActividad sa in socioActividades)
            //{
            //    Socio socio = mapSocio.ContainsKey(sa.IdSocio) ? mapSocio[sa.IdSocio] : null;

            //    Actividad actividad =
            //        Facade.ActividadesClub.ContainsKey(sa.IdActividad) ? Facade.ActividadesClub[sa.IdActividad] :
            //         null;


            //    if (socio != null && actividad != null)
            //    {
            //        socio.ActividadSocios.Add(new ActividadSocio
            //        {
            //            Actividad = actividad,
            //            Socio = socio,
            //            Fecha = sa.Fecha
            //        });
            //    }
            //    else
            //    {
            //        throw new Exception("Base de datos inconsisitente");
            //    }
            //}

            return FabricaRepositorios.ObtenerRepoSocios().Listar();
        }

        private Membresia BuscarMembresiaEnLista(List<Membresia> membresia, int idMembresia)
        {
            foreach (var m in membresia)
            {
                if (m.Id == idMembresia)
                {
                    return m;
                }
            }
            return null;
        }

        public Membresia BuscarMembresia(int idMembresia)
        {
            foreach (var m in ListarMembresias())
            {
                if (m.Id == idMembresia)
                {
                    return m;
                }
            }
            return null;
        }

        private Socio BuscarSocioEnLista(List<Socio> lista, int idSocio)
        {
            foreach (var s in lista)
            {
                if (s.Id == idSocio)
                {
                    return s;
                }
            }
            return null;
        }

        public bool AltaUsuario(string email, string contrasenia)
        {
            IRepoUsuario ru = FabricaRepositorios.ObtenerRepoUsuarios();
            string passEncriptada = CryptoUtils.Crypto.Encrypt(contrasenia);

            bool existe = ru.buscarLogin(email, passEncriptada);

            if (!existe)
            {
                //en caso de que no exista
                Usuario u = new Usuario()
                {
                    Mail = email,
                    Password = passEncriptada
                };

                bool res = ru.Alta(u);
                return res;
            }
            else
            {
                //en caso de que ya exista
                return false;
            }
        }

        public bool LoginUsuario(string mail, string password)
        {
            IRepoUsuario ru = FabricaRepositorios.ObtenerRepoUsuarios();
            string contraEncriptada = CryptoUtils.Crypto.Encrypt(password);
            bool existe = ru.buscarLogin(mail, contraEncriptada);

            return existe;
        }



        public Membresia PagarMensualidadSocio(int cedulaSocio,Membresia membresia)
        {
            try
            {
               
                //p.Precio = (decimal) Facade.Instance.PagarMensualidadSocio((int)cedula);
                //int idPaseLibre = facade.AltaMembresia(cedula, p);
                //PaseLibre paselibre = (PaseLibre)facade.BuscarMembresia(idPaseLibre);

                if (membresia.TipoMembresia == "paselibre")
                {
                    int antiguedadSocio = ObtenerAntiguedadSocio(cedulaSocio);
                    membresia.Precio = (decimal)membresia.calcularPagoFinal(Facade.Configuration, antiguedadSocio);
                }
                else
                {
                    membresia.Precio = (decimal)membresia.calcularPagoFinal(Facade.Configuration);

                }

                int idMem = AltaMembresia(cedulaSocio, membresia);
                return BuscarMembresia(idMem);
                



            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public int ObtenerAntiguedadSocio(int cedula)
        {
            try
            {
                IRepoSocios ru = FabricaRepositorios.ObtenerRepoSocios();                
                // Configuration config = repoConfig.Buscar(1);


                Socio socio = ru.BuscarPorCedula(cedula);

                return socio.CalcularAntiguedad();

            }
            catch (Exception ex)
            {
                return -1;

            }
        }

        public Socio BuscarSocioPorCedula(decimal cedula)
        {
            Socio s = FabricaRepositorios.ObtenerRepoSocios().BuscarPorCedula(cedula);
            return s;
        }


        public static void PrecargaDatos()
        {
            IRepoUsuario ru = FabricaRepositorios.ObtenerRepoUsuarios();

            ru.Precarga();

            RepoHelper.PreCargaDatosPrueba();

        }

        //TODO Migrar para usar entityFramework
        //public ActividadSocioDTOResult IngresarSocioActividad(ActividadSocioDTO actividadSocio)
        //{
        //    if (actividadSocio == null)
        //    {
        //        return new ActividadSocioDTOResult
        //        {
        //            Success = false,
        //            Error = "Parametros invalidos al tratar ingresar un socio en una actividad"
        //        };
        //    }
        //    Socio socio = repoSocios.Buscar(actividadIdSocioSocio);


        //    if (socio == null)
        //    {
        //        return new ActividadSocioDTOResult
        //        {
        //            Success = false,
        //            Error = "Socio al dar de alta actividad debe existir"
        //        };
        //    }
        //    Actividad actividad = repoActividad.Buscar(actividadSocio.IdActividad);
        //    if (actividad == null)
        //    {
        //        return new ActividadSocioDTOResult
        //        {
        //            Success = false,
        //            Error = "Actividad no existe"
        //        };
        //    }

        //    int edad = DateTime.Today.Year - socio.FechaNacimiento.Year;
        //    if (edad < actividad.EdadMin || edad > actividad.EdadMax)
        //    {
        //        return new ActividadSocioDTOResult
        //        {
        //            Success = false,
        //            Error = "Edad no apropiada para el socio para realizar la actividad"
        //        };
        //    }
        //    ///validacion que no exista socio actividad para idSocio y idActividad
        //    if (repoActividad.BuscarSocioActividad(actividadSocio.IdSocio, actividadSocio.IdActividad) != null)
        //    {
        //        return new ActividadSocioDTOResult
        //        {
        //            Success = false,
        //            Error = "Socio ya esta ingresado para esa actividad"
        //        };
        //    }

        //    try
        //    {
        //        int resultIngresoSocioActividad = repoSocios.IngresarActividadSocio(actividadSocio.IdSocio, actividad, actividadSocio.Fecha);

        //        if (resultIngresoSocioActividad > 0)
        //        {
        //            return new ActividadSocioDTOResult
        //            {
        //                Success = true,
        //                Error = ""
        //            };
        //        }
        //        else
        //        {
        //            return new ActividadSocioDTOResult
        //            {
        //                Success = false,
        //                Error = "No se pudo ingresar el socio en la actividad result: " + resultIngresoSocioActividad
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ActividadSocioDTOResult
        //        {
        //            Success = false,
        //            Error = ex.Message + "-" + (ex.InnerException != null ? ex.InnerException.Message : "")
        //        };
        //    }
        //}


        #endregion metodos

    }
}
