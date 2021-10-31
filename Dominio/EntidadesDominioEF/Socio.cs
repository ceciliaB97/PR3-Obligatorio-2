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
        //[Column("Id"), Key]
        public int Id { get; set; }

        /*TODO: corregir validacion esta... range no valida la cantidad de digitos*/
        /*Range(7, 8, ErrorMessage = "Cedula debe tener entre 7 y 8 digitos")*/

        [Required, Index(IsUnique = true)]
        public int Cedula { get; set; }
        [Required, StringLength(50, MinimumLength = 6), Display(Name = "Nombre Completo")]
        public string NombreApellido { get; set; }
        [Required, Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        //.value y .HasValue
        [Required, Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }
        
        
        //[ForeignKey("IdMembresia")]
        public List<Membresia> Membresias { get; set; }


        //[ForeignKey("IdActividad")]
        public List<ActividadSocio> ActividadSocios { get; set; }

        public bool Activo { get; set; }
        public Socio()
        {
            Membresias = new List<Membresia>();
            ActividadSocios = new List<ActividadSocio>(); 
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


        public static bool ValidarDatos(Socio socio)
        {
            string nomApe = socio.NombreApellido;
            DateTime fNacimiento = socio.FechaNacimiento;
            int esInt = socio.Cedula;
            string textoCI = esInt.ToString();

            if (textoCI.Length >= 7 && textoCI.Length <= 9)
            {
                int largo = nomApe.Length;
                int comparar = nomApe.Trim().Length;
                //si el primer o ultimo caracter son espacios
                if (nomApe[0].Equals(' ') || nomApe[largo - 1].Equals(' '))
                {
                    return false;
                }

                if (largo == comparar && largo >= 6 && nomApe.Contains(" "))
                {
                    int a = Math.Abs(fNacimiento.Year - DateTime.Today.Year);
                    if (a >= 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidarPagoMembresia()
        {
            bool result = false;
            DateTime mesAnio = DateTime.Now;
            int mes = mesAnio.Month;
            int anio = mesAnio.Year;

            foreach (Membresia m in Membresias)
            {
                if (m.FechaPago != null && m.FechaPago.HasValue && m.FechaPago.Value.Month == mes && m.FechaPago.Value.Year == anio)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private int DiffMonths(DateTime start, DateTime end)
        {
            int months = 0;
            DateTime tmp = start;

            while (tmp < end)
            {
                months++;
                tmp = tmp.AddMonths(1);
            }

            return months;
        }

        public double TotalAPagarMensualidad(Configuration config)
        {
            double result = 0;
            int antiguedad = DiffMonths(FechaIngreso, DateTime.Now);
            Membresia m = Membresias.SingleOrDefault(e => e.Active);
               if (m != null)
                {
                    result += m.calcularPagoFinal(config, antiguedad);
                }                
            

            return result;
        }

       
    }
}
