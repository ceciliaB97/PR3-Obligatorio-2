using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
	public class RepoHelper
	{

		private static string _connStr ="";

		//SEBASTIAN
		private static readonly string _userid = "sa";
		private static readonly string _psw = "ah!9(xNbonq-hLk4Gm;Ez(dEe-RvB.tJ";
		private static readonly string _server = "localhost\\SQLEXPRESS";
		private static readonly string _database = "ObligatorioP3_GestionClub";

		//BERNARDO
		//private static readonly string _userid = "sa";
		//private static readonly string _psw = "1234";
		//private static readonly string _server = "LAPTOP-H8N5UBOT";
		//private static readonly string _database = "ObligatorioP3_GestionClub";

		////CECILIA
		//private static readonly string _userid = "sa";
		//private static readonly string _psw = "1234";
		//private static readonly string _server = "localhost";
		//private static readonly string _database = "ObligatorioP3_GestionClub";

		public static void PreCargaDatosPrueba()
		{
			try
			{
				using (ClubContext context = new ClubContext())
				{
					//prueba precarga datos
					var h = new Horario
					{
						DiaSemana = DayOfWeek.Monday,
						Hora = 7
					};
					context.Horarios.Add(h);

					var a1 = new Actividad
					{
						ActividadHorarios = new List<Horario>
							{
							  h
							},
						EdadMinima = 7,
						EdadMaxima = 70,
						Cupos = 20,
						Nombre = "Natacion"
					};

					context.Actividades.Add(a1);

					var m1 = new Cuponera
					{
						Nombre="Super cuponera",
						CantActividades = 10,
						Anio = 2021,
						Mes = 7,
						FechaPago = null,
						Precio = 800,
						TipoMembresia = "cuponera",
						Actividades = new List<Actividad>
							{
								a1
							}
					};
					var m2 = new PaseLibre
					{
						Nombre="Super pase libre",
						Anio = 2021,
						Mes = 8,
						FechaPago = null,
						Precio = 2000,
						TipoMembresia = "paselibre",
						Actividades = new List<Actividad>
							{
								a1
							}
					};

					context.Membresias.Add(m1);
					context.Membresias.Add(m2);

					var socio = new Socio()
					{
						Activo = true,
						Cedula = 45042994,
						ActividadSocios = new List<ActividadSocio>(),
						FechaIngreso = DateTime.Now,
						FechaNacimiento = DateTime.Now.AddYears(-30),
						NombreApellido = "Sebastian Piazza",
						Membresias = new List<Membresia>
						{
							m1,
							m2
						}

					};


					context.Socios.Add(socio);


					context.SaveChanges();
				}
			}
			
			catch (Exception)
			{

			}
		}

		public static string GetConnectionString()
		{
			if (String.IsNullOrEmpty(_connStr))
			{
				SqlConnectionStringBuilder builder =
				new SqlConnectionStringBuilder();

				builder.UserID = _userid;
				builder.Password = _psw;

				builder.AsynchronousProcessing = true;


				builder["Database"] = _database;
				builder["Server"] = _server;
				builder["Connect Timeout"] = 1000;
				builder["Trusted_Connection"] = true;

				_connStr = builder.ConnectionString;
				return _connStr;
			}
			else { 
				return _connStr; 
			}

		}


	}

}
