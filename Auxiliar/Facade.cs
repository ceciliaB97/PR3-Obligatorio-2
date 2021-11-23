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

            IRepoActividad repoActividades = FabricaRepositorios.ObtenerRepoActividad();

            List<Actividad> listaActividades = repoActividades.Listar();

            foreach (Actividad actividad in listaActividades)
            {

                if (actividad.Cupos > 0 && edadSocio >= actividad.EdadMinima && edadSocio <= actividad.EdadMaxima)
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

        public List<Membresia> ListarMembresiasMesAnio(int month, int year)
        {
            IRepoMembresia rm = FabricaRepositorios.ObtenerRepoMembresia();
            return rm.ListarPorMesAnio(month, year);
        }

        public List<Membresia> ListarMembresiasPorSocioId(Socio socio)
        {

            try
            {
                return FabricaRepositorios.ObtenerRepoMembresia().ListarPorSocioId(socio.Id);
            }
            catch
            {
                return new List<Membresia>();
            }
        }

        public bool AltaActividad(Actividad actividadAux)
        {
            IRepoActividad repoActividad = FabricaRepositorios.ObtenerRepoActividad();

            int retorno = repoActividad.Alta(actividadAux);

            return retorno > 0;
        }

        public Actividad BuscarActividad(string nombre)
        {
            IRepoActividad repoActividad = FabricaRepositorios.ObtenerRepoActividad();

            return repoActividad.Buscar(nombre);
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
            return FabricaRepositorios.ObtenerRepoSocios().Modificacion(socio);
        }

        public List<Socio> ListaroActualizarSocios()
        {

            return FabricaRepositorios.ObtenerRepoSocios().Listar();
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



        public Membresia PagarMensualidadSocio(int cedulaSocio, Membresia membresia)
        {
            try
            {

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
            catch
            {
                return null;

            }
        }

        public int ObtenerAntiguedadSocio(int cedula)
        {
            try
            {
                IRepoSocios ru = FabricaRepositorios.ObtenerRepoSocios();

                Socio socio = ru.BuscarPorCedula(cedula);

                return socio.CalcularAntiguedad();

            }
            catch
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

        #endregion metodos

    }
}
