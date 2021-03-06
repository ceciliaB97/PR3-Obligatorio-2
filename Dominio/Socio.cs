using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Socios")]
    public class Socio
    {
        [Column("Id"), Key]
        public int Id { get; set; }
        [Required, Range(7, 9, ErrorMessage = "Cedula debe tener entre 7 y 9 digitos"), Index(IsUnique = true)]
        public int Cedula { get; set; }
        [Required, StringLength(50, MinimumLength = 6), Display(Name = "Nombre Completo")]
        public string NombreApellido { get; set; }
        [Required, Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        //.value y .HasValue
        [Required, Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }
        [InverseProperty("Socio")]
        public List<Membresia> Membresias { get; set; }

        public Socio()
        {

        }

        public Socio(int id, int cedula, string nombreApellido, DateTime fechaNacimiento)
        {
            Id = id;
            Cedula = cedula;
            NombreApellido = nombreApellido;
            FechaNacimiento = fechaNacimiento;
            FechaIngreso = DateTime.Now;
        }

        public static int CalcularEdad(DateTime nacimiento)
        {
            return DateTime.Now.Year - nacimiento.Year;
        }

        public int CalcularAntiguedad()
        {
            return Math.Abs((DateTime.Now.Month - FechaIngreso.Month) + 12 * (DateTime.Now.Year - FechaIngreso.Year));
        }

        public static bool ValidarNacimiento(DateTime nacimiento)
        {
            int edad = CalcularEdad(nacimiento);
            return edad > 3 && edad < 90;
        }

        public static bool ValidarNombreApellido(string nombreApellido)
        {
            int tieneEspacio = 0;
            for (int i = 0; i < nombreApellido.Length; i++)
            {

                if (i > 0 && i < nombreApellido.Length - 1 && nombreApellido[i] == ' ')
                {
                    tieneEspacio++;
                }
            }

            if (tieneEspacio == 1)
            {
                return true;
            }

            return false;
        }

    }
}
