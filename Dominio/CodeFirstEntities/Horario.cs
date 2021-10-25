using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
       // [Required, Key]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false), ForeignKey("Id")]
        public Actividad Actividad { get; set; }
        public DayOfWeek DiaSemana { get; set; } //De 1 a 7
        public int Hora { get; set; } // de 7 a 23

    }
}
