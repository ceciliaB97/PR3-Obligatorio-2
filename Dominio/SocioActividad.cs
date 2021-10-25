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
        [Required, Key, ForeignKey("IdSocio")]
        public int IdSocio { get; set; }
        [Required, ForeignKey("IdActividad")]
        public int IdActividad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
