using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	[Table("ActividadHoras")]
	public class ActividadHora
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int Hora { get; set; }
	}
}
