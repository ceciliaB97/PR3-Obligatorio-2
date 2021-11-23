using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorios
{
    public class RepoActividad : IRepoActividad
    {

        public int Alta(Actividad t)
        {
            using (ClubContext db = new ClubContext())
            {
                db.Actividades.Add(t);

                db.SaveChanges();

                return t.Id;
            }
        }

        public bool Baja(int id)
        {
            return true;

        }

        public Actividad Buscar(int id)
        {

            return null;

        }

        public ActividadSocio BuscarSocioActividad(int idSocio, int idActividad)
        {

            return null;
        }

        public List<Horario> ListarHorariosActividad(int idActividad)
        {
            return new List<Horario>();
        }
        public List<Actividad> Listar()
        {
            return new List<Actividad>();
        }

        public Actividad Modificacion(Actividad t)
        {

            return null;
        }

        public Actividad Buscar(string nombre)
        {
            using (ClubContext db = new ClubContext())
            {
                return db.Actividades.SingleOrDefault(a => a.Nombre == nombre);
            }
        }
    }
}
