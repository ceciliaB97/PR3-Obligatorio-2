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
		private const string TABLE_NAME = "Usuario";

		public int Alta(Usuario t)
		{
			//string query = "INSERT into[dbo].[Usuario] (Mail, AdminPassword) VALUES(@Mail, @Password); SELECT CAST(SCOPE_IDENTITY() AS INT);";
			//var connStr = SQLADOHelper.GetConnectionString();

			//int result = -1;

			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{

			//		connection.Open();
			//		var command = new SqlCommand(query, connection);
			//		command.Parameters.AddWithValue("@Mail", t.Mail);
			//		command.Parameters.AddWithValue("@Password", CryptoUtils.Crypto.Encrypt(t.Password));

			//		int idAux = (int)command.ExecuteScalar();

			//		if (idAux != 0)
			//		{
			//			result = idAux;
			//		}

			//	}
			//	catch (Exception ex)
			//	{
			//		throw ex;
			//	}
			//	finally
			//	{
			//		if (connection != null)
			//		{
			//			if (connection.State == ConnectionState.Open) connection.Close();
			//			connection.Dispose();
			//		}
			//	}

			//}

			//return result;
			return -1;
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
			return false;
		}

		public int buscarLogin(string mail, string password)
        {
			//var connStr = SQLADOHelper.GetConnectionString();
			//var result = -1;
			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{
			//		connection.Open();

			//		var command = new SqlCommand("select * from [dbo].[Usuario] where Mail = @Mail and AdminPassword = @Password", connection);
			//		command.Parameters.AddWithValue("@Mail", mail);
			//		string passcrypto = CryptoUtils.Crypto.Encrypt(password);
			//		command.Parameters.AddWithValue("@Password", passcrypto);

			//		SqlDataReader reader = command.ExecuteReader();

			//                 if (reader.Read())
			//                 {
			//			result = 1;
			//                 }

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
			return -1;
		}

		public Usuario Buscar(int id)
		{
			//var connStr = SQLADOHelper.GetConnectionString();
			//var user = new Usuario();
			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{
			//		connection.Open();
			//		var command = SQLADOHelper.GetByIdSQLCommand(connection, TABLE_NAME, id);
			//		SqlDataReader reader = command.ExecuteReader();


			//		reader.Read();

			//		user.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdSocio"));
			//		user.Mail = reader.GetString(reader.GetOrdinal("Mail"));
			//		user.Password = CryptoUtils.Crypto.Decrypt(reader.GetString(reader.GetOrdinal("Password")));



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
			//return user;
			return null;
		}

		public List<Usuario> Listar()
		{
			//var connStr = SQLADOHelper.GetConnectionString();

			//var result = new List<Usuario>();

			//using (var connection = new SqlConnection(connStr))
			//{
			//	try
			//	{
			//		connection.Open();

			//		var command = SQLADOHelper.ListarSQLCommand(connection, TABLE_NAME);

			//		SqlDataReader reader = command.ExecuteReader();
			//		while (reader.Read())
			//		{
			//			var user = new Usuario();

			//			user.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
			//			user.Mail = reader.GetString(reader.GetOrdinal("Mail"));
			//			user.Password = CryptoUtils.Crypto.Decrypt(reader.GetString(reader.GetOrdinal("Password")));

			//			result.Add(user);
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
			return null;
		}

		public bool Modificacion(Usuario t)
		{
			//var result = false;

			//var query = "UPDATE [dbo].[Usuario] SET[Password] = @Password, [Mail] = @mail WHERE IdSocio = @id";

			//var connStr = SQLADOHelper.GetConnectionString();

			//using (var connection = new SqlConnection())
			//{
			//	try
			//	{
			//		connection.Open();
			//		var command = new SqlCommand(query, connection);			
			//		command.Parameters.AddWithValue("@Password", CryptoUtils.Crypto.Encrypt(t.Password));
			//		command.Parameters.AddWithValue("@Mail", t.Mail);

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
			return false;
		}
	}
}
