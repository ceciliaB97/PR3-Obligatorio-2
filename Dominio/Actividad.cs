using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dominio
{
    [Table("Actividades")]
    public class Actividad
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, Index("Actividad_IdSocio_IdMembresia_Hora", IsUnique = true)]
        public int IdMembresia { get; set; }
        [Required, Index("Actividad_IdSocio_IdMembresia_Hora", IsUnique = true)]
        public int IdSocio { get { return IdSocio; } set { IdSocio = Socio.Id; } }
        [ForeignKey("IdSocio")]
        public Socio Socio { get; set; }
        [Required, Index("Actividad_IdSocio_IdMembresia_Hora", IsUnique = true)]
        public DateTime FechaHora { get; set; }
        [Required, Range(20, 500)]
        public int Cupos { get; set; }
        [Required, Range(4,89)]
        public int EdadMinima { get; set; }

        [Required, Range(4, 89)]
        public int EdadMaxima { get; set; }

        [HiddenInput(DisplayValue = false), ForeignKey("IdMembresia")]
        public Membresia Membresia { get; set; }

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
