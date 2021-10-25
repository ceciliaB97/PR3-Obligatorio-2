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
    [Table("Actividades")]
    public class Actividad
    {
        [Required, Key]
        public int Id { get; set; }


        // [ForeignKey("IdSocio")]

        [HiddenInput(DisplayValue = false)]
        public Socio Socio { get; set; }

        [HiddenInput(DisplayValue = false)] //ForeignKey("IdMembresia")
        public Membresia Membresia { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }
        [Required, Range(20, 500)]
        public int Cupos { get; set; }

        public string Nombre { get; set; }

        [Required, Range(4,89)]
        public int EdadMinima { get; set; }

        [Required, Range(4, 89)]
        public int EdadMaxima { get; set; }

        public List<Horario> Horarios { get; set; }

        public static bool ValidarFechaHora (DateTime fechaHora)
        {
            if (fechaHora.Hour >= 7 && fechaHora.Hour <= 22)
            {
                return true;
            }

            return false;
        }

    }
}
