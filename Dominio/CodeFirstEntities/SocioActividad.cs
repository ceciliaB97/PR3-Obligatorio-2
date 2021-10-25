using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class SocioActividad
    {
        public int Id { get; set; }
        public Socio Socio { get; set; }
        public Actividad Actividad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
