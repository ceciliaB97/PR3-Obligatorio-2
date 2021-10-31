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

		[Required]
		public DateTime Fecha { get; set; }

		[Required]
		public virtual Actividad Actividad { get; set; }

		[Required]
		public virtual Socio Socio { get; set; }

		public ActividadSocio(DateTime fecha, Actividad actividad, Socio socio)
        {
			Fecha = fecha;
			Actividad = actividad;
			Socio = socio;
        }
	}
}
