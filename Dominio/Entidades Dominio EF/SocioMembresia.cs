using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("SocioMembresias")]
    public class SocioMembresia
    {
        [Required]
        public int Id { get; set; }
        [Required, ForeignKey("Socio")]
        public int IdSocio { get; set; }
        public virtual Socio Socio { get; set; }
        [Required, ForeignKey("Membresia")]
        public int IdMembresia { get; set; }
        //virtual membresia
        public virtual Membresia Membresia { get; set; }
    }
}
