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
	public class RepoSocios : IRepoSocios
	{
        private const string TABLE_NAME = "Socio";
        //TODO
        //public IngresosFechaData

        public int IngresarActividadSocio(int idSocio, Actividad actividad, DateTime dateTime)
		{

            //var insertSocioActividadSQL = @"INSERT INTO[dbo].[SocioActividad]
            //([IdSocio]
            // ,[IdActividad]
            // ,[Fecha])
            //     VALUES
            //  (@idSocio
            //  ,@idActividad
            //  ,@date)";

            //int result = -1;
            //using (var connection = new SqlConnection(SQLADOHelper.GetConnectionString()))
            //{
            //             SqlTransaction tran = null;

            //             try
            //	{
            //		connection.Open();
            //                 tran = connection.BeginTransaction();

            //                 var command = new SqlCommand(insertSocioActividadSQL, connection,tran);
            //                 command.Transaction = tran;

            //                 command.Parameters.AddWithValue("@idSocio", idSocio);
            //		command.Parameters.AddWithValue("@idActividad", actividad.Id);
            //		command.Parameters.AddWithValue("@date", dateTime);

            //		object val1 = command.ExecuteNonQuery();


            //                 var updateActividad = @"UPDATE [dbo].[Actividad]
            //                                            SET [Cupos] = @cupos
            //                                          WHERE Id = @id";

            //                 var command2 = new SqlCommand(updateActividad, connection, tran);
            //                 command2.Transaction = tran;
            //                 command2.Parameters.AddWithValue("@cupos", actividad.Cupos-1);
            //                 command2.Parameters.AddWithValue("@id", actividad.Id);

            //                 object val2 = command2.ExecuteNonQuery();
            //                 result = val1 != null && val2 != null ? Convert.ToInt32(val2) : -1;

            //                 tran.Commit();

            //             }
            //             catch (Exception ex)
            //	{
            //                 if (tran != null)
            //                 {
            //                     tran.Rollback();
            //                 }
            //                 throw ex;
            //	}
            //	finally
            //	{
            //		connection.Close();
            //	}

            //}

            //return result;


            return -1;
		}

        public List<SocioMembresia> ListarSocioMembresia(){

            //var connStr = SQLADOHelper.GetConnectionString();

            //var result = new List<SocioMembresia>();

            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();

            //        var command = SQLADOHelper.ListarSQLCommand(connection, "SocioMembresia");

            //        SqlDataReader reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            var socioM = new SocioMembresia();
            //            socioM.IdSocio = reader.GetInt32(reader.GetOrdinal("IdSocio"));
            //            socioM.IdMembresia = reader.GetInt32(reader.GetOrdinal("IdMembresia"));
            //            result.Add(socioM);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}

            //return result;            

            return null;
        }

        public List<SocioActividad> ListarSocioActividad()
        {

            //var connStr = SQLADOHelper.GetConnectionString();

            //var result = new List<SocioActividad>();

            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();

            //        var command = SQLADOHelper.ListarSQLCommand(connection, "SocioActividad");

            //        SqlDataReader reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            var socioA = new SocioActividad();
            //            socioA.IdSocio = reader.GetInt32(reader.GetOrdinal("IdSocio"));
            //            socioA.IdActividad = reader.GetInt32(reader.GetOrdinal("IdActividad"));
            //            socioA.Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"));
            //            result.Add(socioA);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}

            //return result;
            return null;
        }


        public int Alta(Socio t)
        {
            //            string query = @"INSERT into [dbo].[Socio] (Cedula, NombreApellido, FechaNacimiento, FechaIngreso, Active) 
            //VALUES (@ci, @nomApellido, @fnacimiento, @fingreso, @active);
            //select SCOPE_IDENTITY() from [dbo].[Socio]";

            //            var connStr = SQLADOHelper.GetConnectionString();

            //			int result = -1;
            //			using (var connection = new SqlConnection(connStr))
            //            {
            //                try
            //                {
            //                    connection.Open();
            //                    var command = new SqlCommand(query, connection);
            //                    command.Parameters.AddWithValue("@ci", t.Cedula);
            //                    command.Parameters.AddWithValue("@nomApellido", t.NombreApellido);
            //                    command.Parameters.AddWithValue("@fnacimiento", t.FechaNacimiento);
            //                    command.Parameters.AddWithValue("@fingreso", t.FechaIngreso);
            //                    command.Parameters.AddWithValue("@active", t.Activo);

            //                    object val = command.ExecuteScalar();

            //                    result = val != null ? Convert.ToInt32(val) : -1;

            //                }
            //                catch (Exception ex)
            //                {
            //                    throw ex;
            //                }
            //                finally
            //                {
            //                    connection.Close();
            //                }

            //            }

            //            return result;

            return -1;
        }

        public bool Baja(int id)
        {
            //var connStr = SQLADOHelper.GetConnectionString();

            //bool result = false;

            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();
            //        var command = new SqlCommand("Update Socio set Active=@active where idSocio = @id", connection);
            //        command.Parameters.AddWithValue("@active", false);
            //        command.Parameters.AddWithValue("@id", id);
            //        int res = command.ExecuteNonQuery();

            //        result = res >= 0 ? true : false;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}


            //return result;
            return false;

        }

        public Socio Buscar(int id)
        {
            //var connStr = SQLADOHelper.GetConnectionString();
            //Socio socio = null;
            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();
            //        var command = SQLADOHelper.GetByParamSQLCommand(connection, "Socio", "IdSocio", id);

            //        SqlDataReader reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            socio = new Socio();

            //            socio.IdSocio = reader.GetInt32(reader.GetOrdinal("IdSocio"));
            //            socio.NombreApellido = reader.GetString(reader.GetOrdinal("NombreApellido"));
            //            socio.Cedula = reader.GetDecimal(reader.GetOrdinal("Cedula"));
            //            socio.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));
            //            socio.FechaIngreso = reader.GetDateTime(reader.GetOrdinal("Fechaingreso"));
            //            socio.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));
            //            socio.Activo = reader.GetBoolean(reader.GetOrdinal("Active"));

            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}
            //return socio;
            return null;

        }

        public Socio BuscarPorCedula(decimal cedulaSocio)
        {
            //var connStr = SQLADOHelper.GetConnectionString();
            //Socio socio = null;
            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();
            //        var command = SQLADOHelper.GetByParamSQLCommand(connection, "Socio", "Cedula", cedulaSocio);
            //        SqlDataReader reader = command.ExecuteReader();


            //        while (reader.Read())
            //        {
            //            socio = new Socio();

            //            socio.IdSocio = reader.GetInt32(reader.GetOrdinal("IdSocio"));
            //            socio.NombreApellido = reader.GetString(reader.GetOrdinal("NombreApellido"));
            //            socio.Cedula = reader.GetDecimal(reader.GetOrdinal("Cedula"));
            //            socio.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));
            //            socio.FechaIngreso = reader.GetDateTime(reader.GetOrdinal("Fechaingreso"));
            //            socio.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));
            //            socio.Activo = reader.GetBoolean(reader.GetOrdinal("Active"));

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}
            //return socio;
            return null;
        }

        public List<Socio> Listar() { 
        //{
        //    var connStr = SQLADOHelper.GetConnectionString();

        //    var result = new List<Socio>();

        //    using (var connection = new SqlConnection(connStr))
        //    {
              
        //        try
        //        {
        //            connection.Open();
                   

        //            var command = SQLADOHelper.ListarSQLCommand(connection, TABLE_NAME," ORDER BY NombreApellido asc, Cedula desc");

        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                var socio = new Socio();
        //                //socio.NombreApellido = reader.GetString(reader.GetOrdinal("Nombre")); revisar tabla socio hay que agregar parametro NombreApellido
        //                socio.IdSocio = reader.GetInt32(reader.GetOrdinal("IdSocio"));
        //                socio.NombreApellido = reader.GetString(reader.GetOrdinal("NombreApellido"));
        //                socio.Cedula = reader.GetDecimal(reader.GetOrdinal("Cedula"));
        //                socio.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));
        //                socio.FechaIngreso = reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
        //                socio.Activo = reader.GetBoolean(reader.GetOrdinal("Active"));

        //                result.Add(socio);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }

        //    return result;
            return null;

        }

        public bool Modificacion(Socio t)
        {
            //var result = false;

            //var query = "UPDATE [dbo].[Socio] SET [Cedula] = @ci, NombreApellido = @nombre, [FechaNacimiento] = @fnacimiento, [FechaIngreso] = @fingreso, [Active] = @active WHERE IdSocio = @id";

            //var connStr = SQLADOHelper.GetConnectionString();

            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();
            //        var command = new SqlCommand(query, connection);
            //        //faltaría agregar parametro de nombre en caso que se agregue a la tabla
            //        command.Parameters.AddWithValue("@ci", t.Cedula);
            //        command.Parameters.AddWithValue("@nombre", t.NombreApellido);

            //        command.Parameters.AddWithValue("@fnacimiento", t.FechaNacimiento);
            //        command.Parameters.AddWithValue("@fingreso", t.FechaIngreso);
            //        command.Parameters.AddWithValue("@active", t.Activo);
            //        command.Parameters.AddWithValue("@Id", t.IdSocio);

            //        int res = command.ExecuteNonQuery();

            //        result = res >= 0 ? true : false;

            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}

            //return result;
            return false;

		}

        bool IRepositorio<Socio>.Alta(Socio t)
        {
            throw new NotImplementedException();
        }
    }
}