using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dominio;
using System.Data.SqlClient;

namespace Repositorios
{
    public class ClubContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Membresia> Membresias { get; set; }

        public DbSet<Actividad> Actividades { get; set; }

        public ClubContext() : base(SQLADOHelper.GetConnectionString())
        {

        }
    }
}
