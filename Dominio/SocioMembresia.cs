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
        [Required, Key, ForeignKey("IdSocio")]
        public int IdSocio { get; set; }
        [Required, Key, ForeignKey("IdMembresia")]
        public int IdMembresia { get; set; }
    }
}
