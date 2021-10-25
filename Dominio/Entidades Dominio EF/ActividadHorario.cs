using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	[Table("ActividadHorarios")]
	public class ActividadHoraio
	{
		[Required]
		public int Id { get; set; }
		public string Nombre { get; set; }
		[Range(7, 23)]
		public int Hora { get; set; }
		[ForeignKey("Actividad")]
		public int IdActividad { get; set; }
		public virtual Actividad Actividad { get; set; }
	}
}
