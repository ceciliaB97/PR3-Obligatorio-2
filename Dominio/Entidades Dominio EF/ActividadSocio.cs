using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	[Table("ActividadesSocio")]
	public class ActividadSocio
	{
		public int Id { get; set; }

		[ForeignKey("Socio")]
		public int IdSocio { get; set; }
		[ForeignKey("Actividad")]
		public int IdActividad { get; set; }
		[ForeignKey("Membresia")]
		public int IdMembresia { get; set; }
		public DateTime Fecha { get; set; }

		public virtual Actividad Actividad { get; set; }
		public virtual Socio Socio { get; set; }
		public virtual Membresia Membresia { get; set; }
	}
}
