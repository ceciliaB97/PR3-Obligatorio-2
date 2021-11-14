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
        [Required]
        public int Id { get; set; }

        //[Required, ReadOnly(true), ForeignKey("Socio")]
        //public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public int Mes { get; set; }
        [Required, Display(Name = "Año"), ReadOnly(true)]
        public int Anio { get; set; }

        [Display(Name = "Fecha de pago"), ReadOnly(true)]
        public DateTime? FechaPago { get; set; }
        //virtual socio


        [Required, MaxLength(50)]
        public string TipoMembresia { get; set; }

        public decimal Precio { get; set; }

        public virtual List<Socio> Socios { get; set; }

        public virtual List<Actividad> Actividades { get; set; }

        [Required, DefaultValue(true)]
        public bool Active { get; set; } = true;

       
        public Membresia()
        {
            Socios = new List<Socio>();
            Actividades = new List<Actividad>();
        }
        
        

        public bool GetActivaEsteMes()
        {
            bool ActivaEsteMes;
            if (FechaPago.HasValue && FechaPago.Value.Month != DateTime.Now.Month)
            {
                ActivaEsteMes = false;
            }
            else
            {
                ActivaEsteMes = true;
            }
            return ActivaEsteMes;
        }

        
        public Membresia(int id, int mes, int anio, DateTime fechaPago) //int idSocio, 
        {
            Id = id;
            Mes = mes;
            Anio = anio;
            FechaPago = fechaPago;
            Actividades = new List<Actividad>();
        }
        // public abstract decimal CalcularPrecio();

        public abstract double calcularPagoFinal(Configuration config, int antiguedadSocio = 0);


    }
}
