using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("SocioActividades")]
    public class SocioActividad
    {
        [Required]
        public int Id { get; set; }

        [Required, ForeignKey("Socio")]
        public int IdSocio { get; set; }
        //virtual socio
        public virtual Socio Socio { get; set; }

        [Required, ForeignKey("Actividad")]
        public int IdActividad { get; set; }
        //virtual actividad
        public virtual Actividad Actividad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
