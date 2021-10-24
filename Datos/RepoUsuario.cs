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
    public class RepoUsuario : IRepoUsuario
    {
        public void Precarga()
        {
            List<Usuario> lu = new List<Usuario>();
            Usuario u1 = new Usuario("bernardo@mail.com", "1234a");
            Usuario u2 = new Usuario("carlos@mail.com", "1234a");

            lu.Add(u1);
            lu.Add(u2);

            foreach (var item in lu)
            {
                bool existe = buscarLogin(item.Mail, item.Password);

                if (!existe)
                {
                    Alta(item);
                }
            }
        }

        public bool Alta(Usuario t)
        {
            bool ret = false;
            using (ClubContext db = new ClubContext())
            {
                db.Usuarios.Add(t);
                int filasAfectadas = db.SaveChanges();

                ret = filasAfectadas != 0;
            }

            return ret;
        }

        public bool buscarLogin(string mail, string password)
        {
            Usuario u = null;
            using (ClubContext db = new ClubContext())
            {
                //string passEncriptada = CryptoUtils.Crypto.Encrypt(password);

                u = db.Usuarios.Where(c => c.Mail == mail && c.Password == password).ToList().SingleOrDefault();
                if (u != null)
                {
                    return true;
                }
            }
            return false;
        }

        public Usuario Buscar(int id)
        {
            using (ClubContext db = new ClubContext())
            {
                return db.Usuarios.Where(c => c.Id == id).ToList().SingleOrDefault();
            }
        }

    }
}
