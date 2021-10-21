using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Configuration
	{
		public int CantActividadesDescuento { get; set; }
		public double DescuentoCuponera { get; set; }
		public double CostoFijo { get; set; }

		public double DescuentoPaseLibre { get; set; }

		public int AntiguedadEstablecida { get; set; }

		public double MontoUnitarioCuponera { get; set; }

		public Configuration()
        {
			CantActividadesDescuento = 15;
			DescuentoCuponera = 25;
			CostoFijo = 50;
			DescuentoPaseLibre = 25;
			AntiguedadEstablecida = 120;
			MontoUnitarioCuponera = 20;
        }

	}
}
