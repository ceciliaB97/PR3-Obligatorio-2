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
    public class RepoMembresia : IRepoMembresia
    {
        private const string TABLE_NAME = "Membresia";


        public int Alta(int idSocio, Membresia t)
        {
            using (ClubContext db = new ClubContext())
            {
                db.Membresias.Add(t);
                Socio s = db.Socios.Find(idSocio);
                s.Membresias.Add(t);
                t.Socios.Add(s);
                db.SaveChanges();

                return t.Id;
            }
        }

        public int Alta(Membresia t)
        {
            return -1;
        }

        public bool Baja(int id)
        {
            using (ClubContext db = new ClubContext())
            {
                Membresia m = db.Membresias.Find(id);
                
                
            }
                return false;
        }

        public Membresia Buscar(int id)
        {
            using (ClubContext db = new ClubContext())
            {
                return db.Membresias.Find(id);
            }
        }

        public List<Membresia> Listar()
        {
            using (ClubContext db = new ClubContext())
            {
                return db.Membresias.ToList();
            }
        }
        public List<Membresia> ListarPorSocioId(int id)
        {
            using (ClubContext db = new ClubContext())
            {
                return db.Membresias.Where(m => m.Socios.Any(s => s.Id == id)).ToList();
            }
        }

        public Membresia Modificacion(Membresia t)
        {
            throw new Exception("invalida");
        }

        public bool ModificarFechaPagoHoy(Membresia t)
        {
            throw new Exception("invalida");
        }

    }
}
