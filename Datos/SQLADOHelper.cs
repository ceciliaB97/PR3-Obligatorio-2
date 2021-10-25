using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
	public class SQLADOHelper
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

		//CECILIA
		//private static readonly string _userid = "sa";
		//private static readonly string _psw = "1234";
		//private static readonly string _server = "localhost";
		//private static readonly string _database = "Obligatorio_2_P3_GestionClub";



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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="table">activididad, membresia, usuario, socios</param>
		/// <param name="id"></param>
		/// <returns></returns>
		//public static SqlCommand GetByIdSQLCommand(SqlConnection connection, string table, int id)
		//{
		//	var command = new SqlCommand($"select * from [{_database}].[dbo].{table} where Id = @Id", connection);
		//	command.Parameters.AddWithValue("@Id", id);

		//	return command;
		//}


		//public static SqlCommand GetByParamSQLCommand(SqlConnection connection, string table,string _column, object _val)
		//{
		//	var command = new SqlCommand($"select * from [{_database}].[dbo].{table} where {_column} = @{_column}", connection);
		//	command.Parameters.AddWithValue($"@{_column}", _val);

		//	return command;
		//}
		//public static SqlCommand ListarSQLCommand(SqlConnection connection, string table , string orderby="")
		//{
		//	var command = new SqlCommand($"select * from {table} {orderby}", connection);

		//	return command;
		//}

		//public static SqlCommand BajaSQLCommand(SqlConnection connection, string table, bool active, int id)
		//{
		//	var command = new SqlCommand($"update {table} set Active=@active where id = @id" , connection);
		//	command.Parameters.AddWithValue("@active", active);
		//	command.Parameters.AddWithValue("@id", id);
		//	return command;
		//}


		//public static DataTable GetDataTableUtil(string table)
		//{
		//	var connStr = GetConnectionString();

		//	var result = new DataTable();
		//	using (var connection = new SqlConnection(connStr))
		//	{
		//		try
		//		{
		//			connection.Open();
		//			var command = ListarSQLCommand(connection, table);
		//			SqlDataReader reader = command.ExecuteReader();

		//			result.Load(reader);

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
		//}


	}

}
