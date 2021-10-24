using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Membresias")]
    public abstract class Membresia
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, Display(Name = "Id Socio"), ReadOnly(true)]
        public int IdSocio { get; set; }
        [Required, Range(1, 12), ReadOnly(true), HiddenInput(DisplayValue = false), ForeignKey("IdSocio")]
        public Socio Socio { get; set; }
        public int Mes { get; set; }
        [Required, Display(Name = "Año"), ReadOnly(true)]
        public int Anio { get; set; }
        [Required, Display(Name = "Fecha de pago"), ReadOnly(true)]
        public DateTime? FechaPago { get; set; }


        [Required]
        public string TipoMembresia { get; set; }
        
        public decimal Precio { get; set; }
        public List<Actividad> Actividades { get; set; }

        public string Tipo { get; set; }
        [Required]
        public bool ActivaEsteMes
        {
            get { return ActivaEsteMes; }

            set
            {
                if (FechaPago.HasValue && FechaPago.Value.Month != DateTime.Now.Month)
                {
                    ActivaEsteMes = false;
                }
                else
                {
                    ActivaEsteMes = true;
                }
            }
        }

        public Membresia()
        {

        }
        public Membresia(int id, int idSocio, int mes, int anio, DateTime fechaPago)
        {
            Id = id;
            IdSocio = idSocio;
            Mes = mes;
            Anio = anio;
            FechaPago = fechaPago;
            Actividades = new List<Actividad>();
        }
       // public abstract decimal CalcularPrecio();

        public abstract double calcularPagoFinal(Configuration config, int antiguedadSocio = 0);


    }
}
