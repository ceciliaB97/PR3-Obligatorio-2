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

        public DbSet<Configuration> Configuracion { get; set; }

        public DbSet<Horario> Horarios { get; set; }
        public DbSet<ActividadSocio> ActividadSocios { get; set; }


        public ClubContext() : base(RepoHelper.GetConnectionString())
        {

        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Horario>()
        //    .HasIndex(p => new { p.DiaSemana, p.Hora,p.Actividad }).IsUnique();

        //    modelBuilder.Entity<ActividadSocio>()
        //        .HasIndex(p => new { p.Actividad, p.Socio, p.Fecha }).IsUnique();
        //}
    }
}
