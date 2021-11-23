using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repositorios
{
	public class RepoSocios : IRepoSocios
    {
        public int IngresarActividadSocio(int idSocio, Actividad actividad, DateTime dateTime)
        {
            using (ClubContext db = new ClubContext())
            {
                Socio s = db.Socios.Find(idSocio);
                ActividadSocio ac = new ActividadSocio(dateTime, actividad, s);
                db.ActividadSocios.Add(ac);
                return db.SaveChanges();
            }
        }
        public int Alta(Socio t)
        {
            using (ClubContext db = new ClubContext())
            {
                db.Socios.Add(t);
                db.SaveChanges();
                return t.Id;
            }
        }

        public bool Baja(int id)
        {
            using (ClubContext db = new ClubContext())
            {
                Socio s = db.Socios.Find(id);
                s.Activo = false;
                db.SaveChanges();

                if (!db.Socios.Find(id).Activo)
                {
                    return true;
                }
            }
            return false;
        }

        public Socio Buscar(int id)
        {
            using (ClubContext db = new ClubContext())
            {
                Socio s = db.Socios.Include("Membresias").Include("ActividadSocios").
                    Where(x => x.Id == id).SingleOrDefault();
                // Find(id);
                //Accedemos a las listas por el lazy loading, para que cargue las dependencias, si no, no se cargan
                //List<Membresia> mAux = s.Membresias;
                //List<ActividadSocio> acAux = s.ActividadSocios;
                return s;
            }
        }

        public Socio BuscarPorCedula(decimal cedulaSocio)
        {
            using (ClubContext db = new ClubContext())
            {
                return db.Socios.Include("Membresias").Include("ActividadSocios").Where(s => s.Cedula == cedulaSocio).SingleOrDefault();
            }
        }

        public List<Socio> Listar()
        {
            using (ClubContext db = new ClubContext())
            {
                return db.Socios.ToList();
            }
        }

        public Socio Modificacion(Socio t)
        {
            using (ClubContext db = new ClubContext())
            {
                Socio s = db.Socios.Find(t.Id);
                s.Activo = t.Activo;
                s.FechaNacimiento = t.FechaNacimiento;
                s.NombreApellido = t.NombreApellido;
                db.SaveChanges();

                return s;
            }
        }
    }
}