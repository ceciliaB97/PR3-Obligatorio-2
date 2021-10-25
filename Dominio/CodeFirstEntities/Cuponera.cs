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
    [Table("Cuponera")]
    public class Cuponera : Membresia
    {
        [Required, Range(8,60)]
        public int CantActividades { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public static int NroTopeIngresosParaDescuento { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public static int PorcentajeDescuento { get { return PorcentajeDescuento; } set { PorcentajeDescuento = 30; } }
        //[HiddenInput(DisplayValue = false)]
        //public static decimal PrecioPorActividad { get { return PrecioPorActividad; } set{ PrecioPorActividad = 100; } }

        public Cuponera()
		{
            TipoMembresia = "cuponera";
        }
        public Cuponera(int cantingresos) : base()
        {
            CantActividades = cantingresos;
            TipoMembresia = "cuponera";
        }

        //public override decimal CalcularPrecio()
        //{
        //    return (CantIngresos * PrecioPorActividad) * PorcentajeDescuento / 100;
        //}


        public override double calcularPagoFinal(Configuration config, int antiguedadSocio = 0)
        {
            var result = config.MontoUnitarioCuponera * CantActividades;

            if (CantActividades > config.CantActividadesDescuento)
            {
                double descuento = config.DescuentoCuponera / 100;
                result -= descuento * result;
            }


            return result;
        }
    }
}
