using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
        public int Id { get; set; }
        public DayOfWeek DiaSemana { get; set; } //De 1 a 7
        public int Hora { get; set; } // de 7 a 23

        public virtual Actividad Actividad { get; set; }
    }
}
