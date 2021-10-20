using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dominio
{
    [Table("Cuponera")]
    public class Cuponera : Membresia
    {
        [Required, Range(8,60)]
        public int CantIngresos { get; set; }

        [HiddenInput(DisplayValue = false)]
        public static int NroTopeIngresosParaDescuento { get; set; }

        [HiddenInput(DisplayValue = false)]
        public static int PorcentajeDescuento { get { return PorcentajeDescuento; } set { PorcentajeDescuento = 30; } }
        [HiddenInput(DisplayValue = false)]
        public static decimal PrecioPorActividad { get { return PrecioPorActividad; } set{ PrecioPorActividad = 100; } }

        public Cuponera(int cantingresos) : base()
        {
            CantIngresos = cantingresos;
            Tipo = "Cuponera";
        }

        public override decimal CalcularPrecio()
        {
            return (CantIngresos * PrecioPorActividad) * PorcentajeDescuento / 100;
        }
    }
}
