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

        [Required, ReadOnly(true), ForeignKey("Socio")]
        public int IdSocio { get; set; }
        public int Mes { get; set; }
        [Required, Display(Name = "Año"), ReadOnly(true)]
        public int Anio { get; set; }
        [Required, Display(Name = "Fecha de pago"), ReadOnly(true)]
        public DateTime? FechaPago { get; set; }
        //virtual socio
        public virtual Socio Socio { get; set; }


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
