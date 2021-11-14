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

            string pass = CryptoUtils.Crypto.Encrypt("1234a");
            Usuario u1 = new Usuario("bernardo@mail.com",pass);
            Usuario u2 = new Usuario("carlos@mail.com", pass);

            lu.Add(u1);
            lu.Add(u2);

            using (var context = new ClubContext())
            {
                foreach (var item in lu)
                {
                    //bool existe = buscarLogin(item.Mail, item.Password);

                    /*if (!existe)
                    {*/
                    //  Alta(item);
                    //}
                    
                    //tal vez lo hace de una forma directa sin tener que llamar al otro método
                    //con el contexto creado localmente en este método, será más eficiente esto, que llamar al método?
                    if (context.Usuarios.SingleOrDefault(e => e.Mail == item.Mail && e.Password == item.Password) == null)
                    {
                        context.Usuarios.Add(item);
                    }

                }

				

				int filasAfectadas = context.SaveChanges();
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
                //var usuarios = db.Usuarios.ToList();

                //get the single user who matches the mail and password, or return null
                //si single or default estuviera al final, agarra lo que haya y lo devuelve luego de hacer el filtro
                //solo si es 1 elemento único en la lista
                u = db.Usuarios.SingleOrDefault(c => c.Mail == mail && c.Password == password);
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
                return db.Usuarios.Find(id);
            }
        }

    }
}
