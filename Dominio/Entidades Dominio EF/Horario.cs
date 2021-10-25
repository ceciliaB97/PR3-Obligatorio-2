using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Horarios")]
    public class Horario
    {
        //key
        public int Id { get; set; }
        [Required, ForeignKey("Id")]
        public Actividad Actividad { get; set; }
        [Range(0,6)]
        public DayOfWeek DiaSemana { get; set; } //De 1 a 7
        [Range(7, 23)]
        public int Hora { get; set; } // de 7 a 23

    }
}
