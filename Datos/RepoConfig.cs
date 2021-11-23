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
	public class RepoConfig : IRepoConfig
	{

		public void Precarga()
		{
			using (var context = new ClubContext())
			{
				if (!context.Configuracion.Any())
				{
					context.Configuracion.Add(new Configuration
					{
						CantActividadesDescuento = 10,
						DescuentoCuponera = 15,
						CostoFijo = 1000,
						DescuentoPaseLibre = 25,
						AntiguedadEstablecida = 5,
						MontoUnitarioCuponera = 30
					});
				}

				context.SaveChanges();
			}
		}
		public int Alta(Configuration t)
		{
			return -1;

		}

		public bool Baja(int id)
		{
			return true;

		}

		public Configuration GetConfiguration()
		{
			using (var context = new ClubContext())
			{
				return context.Configuracion.SingleOrDefault();
			}
		}

		public Configuration Buscar(int id)
		{
			using (var context = new ClubContext())
			{
				return context.Configuracion.Find(id);
			}

		}




		public List<Configuration> Listar()
		{
			using (var context = new ClubContext())
			{
				return context.Configuracion.ToList();
			}
		}

		public Configuration Modificacion(Configuration t)
		{
			return null;
		}

    }
}
