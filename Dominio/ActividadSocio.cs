using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class ActividadSocio
	{
		public Socio Socio { get; set; }
		public Actividad Actividad { get; set; }
		public DateTime Fecha { get; set; }
	}
}
