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
			//var connStr = SQLADOHelper.GetConnectionString();
			//bool result = false;

			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{
			//		connection.Open();
			//		var command = SQLADOHelper.BajaSQLCommand(connection, TABLE_NAME, false, id);
			//		int res = command.ExecuteNonQuery();

			//		result = res >= 0 ? true : false;
			//	}
			//	catch (Exception ex)
			//	{
			//		throw ex;
			//	}
			//	finally
			//	{
			//		connection.Close();
			//	}
			//}


			//return result;
			return true;

		}

		public Actividad Buscar(int id)
		{
			//var connStr = SQLADOHelper.GetConnectionString();
			//var actividad = new Actividad();
			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{
			//		connection.Open();
			//		var command = SQLADOHelper.GetByIdSQLCommand(connection, TABLE_NAME, id);
			//		SqlDataReader reader = command.ExecuteReader();


			//		reader.Read();

			//		actividad.Id = reader.GetInt32(reader.GetOrdinal("Id"));
			//		actividad.EdadMax = reader.GetInt32(reader.GetOrdinal("Maxedad"));
			//		actividad.EdadMin = reader.GetInt32(reader.GetOrdinal("Minedad"));
			//		actividad.Cupos = reader.GetInt32(reader.GetOrdinal("Cupos"));
			//		actividad.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
			//		actividad.Active = reader.GetBoolean(reader.GetOrdinal("Active"));

			//	}
			//	catch (Exception ex)
			//	{
			//		throw ex;
			//	}
			//	finally
			//	{
			//		connection.Close();
			//	}
			//}
			//return actividad;

			return null;

		}

		public ActividadSocio BuscarSocioActividad(int idSocio, int idActividad)
		{
			//		var connStr = SQLADOHelper.GetConnectionString();
			//SocioActividad socioActividad = null;
			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{
			//		connection.Open();
			//		var command = new SqlCommand(@"SELECT TOP 1 [IdSocio]
			//			  ,[IdActividad]
			//			  ,[Fecha]
			//		  FROM [dbo].[SocioActividad] where IdSocio = @idSocio and IdActividad = @idActividad", connection);
			//		command.Parameters.AddWithValue("@idSocio",idSocio);
			//		command.Parameters.AddWithValue("@idActividad", idActividad);


			//		SqlDataReader reader = command.ExecuteReader();
			//		bool hasValues = reader.Read();

			//		if (hasValues)
			//		{
			//			socioActividad = new SocioActividad();
			//			socioActividad.IdActividad = reader.GetInt32(reader.GetOrdinal("IdActividad"));
			//			socioActividad.IdSocio = reader.GetInt32(reader.GetOrdinal("IdSocio"));
			//			socioActividad.Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"));
			//		}

			//	}
			//	catch (Exception ex)
			//	{
			//		throw ex;
			//	}
			//	finally
			//	{
			//		connection.Close();
			//	}
			//}
			//return socioActividad;

			return null;
		}

		public List<Horario> ListarHorariosActividad( int idActividad) { 
		//{
		//	var connStr = SQLADOHelper.GetConnectionString();

		//	var result = new List<Horario>();
		//	using (var connection = new SqlConnection(connStr))
		//	{
		//		try
		//		{
		//			connection.Open();
		//			var command = SQLADOHelper.GetByParamSQLCommand(connection, 
		//				"ActividadHorario","IdActividad",idActividad);
		//			SqlDataReader reader = command.ExecuteReader();

		//			while (reader.Read())
		//			{
		//				var horario = new Horario();

		//				int dayAux = reader.GetInt32(reader.GetOrdinal("Dia"));
		//				int day = (dayAux == 7) ? 0 : dayAux;

		//				horario.DiaSemana = (DayOfWeek)day;
		//				horario.Hora = reader.GetInt32(reader.GetOrdinal("Hora"));

		//				result.Add(horario);
		//			}

		//		}
		//		catch (Exception ex)
		//		{
		//			throw ex;
		//		}
		//		finally
		//		{
		//			connection.Close();
		//		}
		//	}

		//	return result;
			return new List<Horario>();
		}
		public List<Actividad> Listar()
		{
			//var connStr = SQLADOHelper.GetConnectionString();

			//var result = new List<Actividad>();
			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{
			//		connection.Open();
			//		var command = SQLADOHelper.ListarSQLCommand(connection,TABLE_NAME);
			//		SqlDataReader reader = command.ExecuteReader();

			//		while (reader.Read())
			//		{
			//			var actividad = new Actividad();
			//			actividad.Id = reader.GetInt32(reader.GetOrdinal("Id"));
			//			actividad.EdadMax = reader.GetInt32(reader.GetOrdinal("Maxedad"));
			//			actividad.EdadMin = reader.GetInt32(reader.GetOrdinal("Minedad"));
			//			actividad.Cupos = reader.GetInt32(reader.GetOrdinal("Cupos"));
			//			actividad.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
			//			actividad.Active = reader.GetBoolean(reader.GetOrdinal("Active"));

			//			result.Add(actividad);
			//		}

			//	}
			//	catch (Exception ex)
			//	{
			//		throw ex;
			//	}
			//	finally
			//	{
			//		connection.Close();
			//	}
			//}

			//return result;
			return new List<Actividad>();
		}

		public Actividad Modificacion(Actividad t)
		{
			//		string query_update = @"UPDATE [dbo].[Actividad]
			//  SET [Nombre] = @nombre
			//     ,[Minedad] = @minedad
			//     ,[Maxedad] = @maxedad
			//     ,[Active] = @active
			//     ,[Cupos] = @cupos
			//WHERE Id = @Id";

			//		var connStr = SQLADOHelper.GetConnectionString();
			//		bool result = false;

			//		using (var connection = new SqlConnection(connStr))
			//		{
			//			try
			//			{
			//				connection.Open();
			//				var command = new SqlCommand(query_update,connection);
			//				command.Parameters.AddWithValue("@nombre", t.Nombre);
			//				command.Parameters.AddWithValue("@minedad", t.EdadMin);
			//				command.Parameters.AddWithValue("@maxedad", t.EdadMax);
			//				command.Parameters.AddWithValue("@active", t.Active);
			//				command.Parameters.AddWithValue("@cupos", t.Cupos);
			//				command.Parameters.AddWithValue("@Id", t.Id);

			//				int res = command.ExecuteNonQuery();

			//				result = res >= 0 ? true : false;
			//			}
			//			catch (Exception ex)
			//			{
			//				throw ex;
			//			}
			//			finally
			//			{
			//				connection.Close();
			//			}
			//		}

			//		return result;

			return null;
		}

    }
}
