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
            //          string query = @"INSERT INTO [dbo].[Membresia]
            //         ([Nombre]
            //         ,[Description]
            //         ,[Fechapago]
            //         ,[Active]
            //         ,[CantActividades]
            //         ,[Tipomembresia])
            //	 VALUES
            //		   (@nombre
            //		   ,@descripcion
            //		   ,@fechaPago
            //		   ,@active
            //		   ,@cantActividades
            //		   ,@tipoMembresia);
            //select SCOPE_IDENTITY() from [dbo].[Membresia]
            //GO";

            //          var connStr = SQLADOHelper.GetConnectionString();

            //          int result = -1;
            //          //SqlCommand cmd = new SqlCommand(sql, con, trans)
            //          using (var connection = new SqlConnection(connStr))
            //          {
            //              SqlTransaction tran = null;
            //              try
            //              {
            //                  connection.Open();
            //                  tran = connection.BeginTransaction();                  
            //                  var command = new SqlCommand(query, connection, tran);
            //                  command.Transaction = tran;
            //                  command.Parameters.AddWithValue("@idSocio", idSocio);
            //                  object o = t.FechaPago;

            //                  if (o == null)
            //                  {
            //                      o = DBNull.Value;
            //                  }
            //                  command.Parameters.AddWithValue("@fechaPago", o);

            //                  command.Parameters.AddWithValue("@nombre", t.Nombre);
            //                  command.Parameters.AddWithValue("@descripcion", t.Descipcion);
            //                  command.Parameters.AddWithValue("@active", t.Active);
            //                  if (t.TipoMembresia == "cuponera")
            //                  {
            //                      command.Parameters.AddWithValue("@cantActividades", ((Cuponera)t).CantActividades);

            //                  }
            //                  else
            //                  {
            //                      command.Parameters.AddWithValue("@cantActividades", 0);

            //                  }

            //                  command.Parameters.AddWithValue("@tipoMembresia", t.TipoMembresia);


            //                  object val = command.ExecuteScalar();

            //                  if (val != null)
            //                  {
            //                      string query2 = "INSERT INTO [dbo].[SocioMembresia] ([IdSocio], [IdMembresia]) VALUES(@idSocio, @idMembresia); select SCOPE_IDENTITY() from [dbo].[SocioMembresia] GO;";
            //                      var command2 = new SqlCommand(query2, connection, tran);
            //                      //SqlCommand cmd = new SqlCommand(sql, con, trans)
            //                      command2.Parameters.AddWithValue("@idSocio", idSocio);
            //                      command2.Parameters.AddWithValue("@idMembresia", val);
            //                      object val2 = command2.ExecuteScalar();

            //                      if (val != null && val2 != null)
            //                      {
            //                          result = val != null ? Convert.ToInt32(val) : -1;
            //                      }

            //                  }

            //                  tran.Commit();

            //              }
            //              catch (Exception ex)
            //              {
            //                  if (tran != null) tran.Rollback();
            //                  throw ex;
            //              }
            //              finally
            //              {
            //                  connection.Close();
            //              }

            //          }

            //          return result;
            return -1;
        }

        public int Alta(Membresia t)
        {
            //          string query = @"INSERT INTO [dbo].[Membresia]
            //         ([Nombre]
            //         ,[Description]
            //         ,[Fechapago]
            //         ,[Active]
            //         ,[CantActividades]
            //         ,[Tipomembresia])
            //	 VALUES
            //		   (@nombre
            //		   ,@descripcion
            //		   ,@fechaPago
            //		   ,@active
            //		   ,@cantActividades
            //		   ,@tipoMembresia);
            //select SCOPE_IDENTITY() from [dbo].[Membresia]
            //GO";

            //          var connStr = SQLADOHelper.GetConnectionString();

            //          int result = -1;

            //          using (var connection = new SqlConnection(connStr))
            //          {
            //              try
            //              {
            //                  connection.Open();
            //                  var command = new SqlCommand(query, connection);
            //                  command.Parameters.AddWithValue("@fechaPago", t.FechaPago);
            //                  command.Parameters.AddWithValue("@nombre", t.Nombre);
            //                  command.Parameters.AddWithValue("@descripcion", t.Descipcion);
            //                  command.Parameters.AddWithValue("@active", t.Active);
            //                  if (t.TipoMembresia == "cuponera")
            //                  {
            //                      command.Parameters.AddWithValue("@cantActividades", ((Cuponera)t).CantActividades);

            //                  }
            //                  else
            //                  {
            //                      command.Parameters.AddWithValue("@cantActividades", 0);

            //                  }

            //                  command.Parameters.AddWithValue("@tipoMembresia", t.TipoMembresia);


            //                  object val = command.ExecuteScalar();

            //                  result = val != null ? Convert.ToInt32(val) : -1;

            //              }
            //              catch (Exception ex)
            //              {
            //                  throw ex;
            //              }
            //              finally
            //              {
            //                  connection.Close();
            //              }

            //          }

            //          return result;

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
            //        var command = SQLADOHelper.BajaSQLCommand(connection, TABLE_NAME, false, id);
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

        public Membresia Buscar(int id)
        {
            //var connStr = SQLADOHelper.GetConnectionString();
            //Membresia membresia = null;
            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();
            //        var command = SQLADOHelper.GetByIdSQLCommand(connection, TABLE_NAME, id);
            //        SqlDataReader reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            if (reader["Tipomembresia"].ToString() == "paselibre") //ES IMPORTADO
            //            {
            //                membresia = new PaseLibre();
            //            }
            //            else
            //            {
            //                membresia = new Cuponera((int)reader["CantActividades"]);
            //            }
            //            membresia.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            //            membresia.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
            //            membresia.Descipcion = reader.GetString(reader.GetOrdinal("Description"));
            //            var index = reader.GetOrdinal("Fechapago");
            //            membresia.FechaPago = reader.IsDBNull(index) ?
            //              (DateTime?)null :
            //              (DateTime?)reader.GetDateTime(index);
            //            membresia.Active = reader.GetBoolean(reader.GetOrdinal("Active"));
            //            membresia.TipoMembresia = reader.GetString(reader.GetOrdinal("Tipomembresia"));
            //            if (membresia.TipoMembresia == "cuponera")
            //            {
            //                ((Cuponera)membresia).CantActividades = reader.GetInt32(reader.GetOrdinal("CantActividades"));
            //            }

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
            //return membresia;
            return null;
        }

        public List<Membresia> Listar()
        {
            //var connStr = SQLADOHelper.GetConnectionString();
            //Membresia membresia = null;
            //var result = new List<Membresia>();
            //using (var connection = new SqlConnection(connStr))
            //{
            //    try
            //    {
            //        connection.Open();
            //        var command = SQLADOHelper.ListarSQLCommand(connection, "Membresia");
            //        SqlDataReader reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            if (reader["Tipomembresia"].ToString() == "paselibre") //ES IMPORTADO
            //            {
            //                membresia = new PaseLibre();
            //            }
            //            else
            //            {
            //                membresia = new Cuponera((int)reader["CantActividades"]);
            //            }
            //            membresia.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            //            membresia.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
            //            membresia.Descipcion = reader.GetString(reader.GetOrdinal("Description"));
            //            var index = reader.GetOrdinal("Fechapago");
            //            membresia.FechaPago = reader.IsDBNull(index) ?
            //              (DateTime?)null :
            //              (DateTime?)reader.GetDateTime(index);
            //            membresia.Active = reader.GetBoolean(reader.GetOrdinal("Active"));
            //            membresia.TipoMembresia = reader.GetString(reader.GetOrdinal("Tipomembresia"));
            //            if (membresia.TipoMembresia == "cuponera")
            //            {
            //                ((Cuponera)membresia).CantActividades = reader.GetInt32(reader.GetOrdinal("CantActividades"));
            //            }
            //            result.Add(membresia);
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
        public List<Membresia> ListarPorSocioId(int id) { 
        //{
        //    var connStr = SQLADOHelper.GetConnectionString();
        //    Membresia membresia = null;
        //    var result = new List<Membresia>();
        //    using (var connection = new SqlConnection(connStr))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            var command = new SqlCommand($"select * from SocioMembresia where IdSocio = {id}", connection);
        //            SqlDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                if (reader["Tipomembresia"].ToString() == "paselibre") //ES pase libre
        //                {
        //                    membresia = new PaseLibre();
        //                }
        //                else
        //                {
        //                    membresia = new Cuponera((int)reader["CantActividades"]);
        //                }
        //                membresia.Id = reader.GetInt32(reader.GetOrdinal("Id"));
        //                membresia.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
        //                membresia.Descipcion = reader.GetString(reader.GetOrdinal("Description"));
        //                var index = reader.GetOrdinal("Fechapago");
        //                membresia.FechaPago = reader.IsDBNull(index) ?
        //                  (DateTime?)null :
        //                  (DateTime?)reader.GetDateTime(index);
        //                membresia.Active = reader.GetBoolean(reader.GetOrdinal("Active"));
        //                membresia.TipoMembresia = reader.GetString(reader.GetOrdinal("Tipomembresia"));
        //                if (membresia.TipoMembresia == "cuponera")
        //                {
        //                    ((Cuponera)membresia).CantActividades = reader.GetInt32(reader.GetOrdinal("CantActividades"));
        //                }
        //                result.Add(membresia);
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

        public bool Modificacion(Membresia t)
        {
            //           string query_update = @"UPDATE [dbo].[Membresia]
            //  SET [Nombre] = @nombre
            //     ,[Description] = @description
            //     ,[Fechapago] = @fechapago
            //     ,[Active] = @active
            //     ,[CantActividades] = @cantActividades
            //     ,[Tipomembresia] = @tipoMembresia
            //WHERE Id = @Id";

            //           var connStr = SQLADOHelper.GetConnectionString();
            //           bool result = false;

            //           using (var connection = new SqlConnection(connStr))
            //           {
            //               try
            //               {
            //                   connection.Open();
            //                   var command = new SqlCommand(query_update, connection);
            //                   command.Parameters.AddWithValue("@nombre", t.Nombre);
            //                   command.Parameters.AddWithValue("@description", t.Descipcion);
            //                   command.Parameters.AddWithValue("@fechapago", t.FechaPago);
            //                   command.Parameters.AddWithValue("@active", t.Active);
            //                   if (t.TipoMembresia == "cuponera")
            //                   {
            //                       command.Parameters.AddWithValue("@cantActividades", ((Cuponera)t).CantActividades);
            //                   }
            //                   else
            //                   {
            //                       command.Parameters.AddWithValue("@cantActividades", 0);
            //                   }
            //                   command.Parameters.AddWithValue("@tipoMembresia", t.TipoMembresia);

            //                   command.Parameters.AddWithValue("@Id", t.Id);

            //                   int res = command.ExecuteNonQuery();

            //                   result = res >= 0 ? true : false;
            //               }
            //               catch (Exception ex)
            //               {
            //                   throw ex;
            //               }
            //               finally
            //               {
            //                   connection.Close();
            //               }
            //           }

            //           return result;
            return false;
        }

        public bool ModificarFechaPagoHoy(Membresia t)
        {
            //           string query_update = @"UPDATE [dbo].[Membresia]
            //  SET [Nombre] = @nombre
            //     ,[Description] = @description
            //     ,[Fechapago] = @fechapago
            //     ,[Active] = @active
            //     ,[CantActividades] = @cantActividades
            //     ,[Tipomembresia] = @tipoMembresia
            //WHERE Id = @Id";

            //           var connStr = SQLADOHelper.GetConnectionString();
            //           bool result = false;

            //           using (var connection = new SqlConnection(connStr))
            //           {
            //               try
            //               {
            //                   connection.Open();
            //                   var command = new SqlCommand(query_update, connection);
            //                   command.Parameters.AddWithValue("@nombre", t.Nombre);
            //                   command.Parameters.AddWithValue("@description", t.Descipcion);
            //                   command.Parameters.AddWithValue("@fechapago", DateTime.Today);
            //                   command.Parameters.AddWithValue("@active", t.Active);
            //                   if (t.TipoMembresia == "cuponera")
            //                   {
            //                       command.Parameters.AddWithValue("@cantActividades", ((Cuponera)t).CantActividades);
            //                   }
            //                   else
            //                   {
            //                       command.Parameters.AddWithValue("@cantActividades", 0);
            //                   }
            //                   command.Parameters.AddWithValue("@tipoMembresia", t.TipoMembresia);

            //                   command.Parameters.AddWithValue("@Id", t.Id);

            //                   int res = command.ExecuteNonQuery();

            //                   result = res >= 0 ? true : false;
            //               }
            //               catch (Exception ex)
            //               {
            //                   throw ex;
            //               }
            //               finally
            //               {
            //                   connection.Close();
            //               }
            //           }

            //           return result;
            return false;
        }

        bool IRepositorio<Membresia>.Alta(Membresia t)
        {
            throw new NotImplementedException();
        }
    }
}
