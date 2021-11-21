using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dominio
{
    //[Table("PaseLibre")]
    public class PaseLibre : Membresia
    {
        //public static int TopeAntiguedadParaDescuento { get { return TopeAntiguedadParaDescuento; } set { TopeAntiguedadParaDescuento = 7; } }
        //public static int PorcentajeDescuento { get { return PorcentajeDescuento; } set { PorcentajeDescuento = 30; } }
        //public static decimal PrecioFijoPorMes { get { return PrecioFijoPorMes; } set { PrecioFijoPorMes = 800; } }
        //public override decimal CalcularPrecio()
        //{
        //    if (Socio.CalcularAntiguedad() > TopeAntiguedadParaDescuento)
        //    {
        //        return PrecioFijoPorMes * PorcentajeDescuento / 100;
        //    }
        //    else
        //    {
        //        return PrecioFijoPorMes;
        //    }

        //}

        public PaseLibre() : base()
        {
            TipoMembresia = "paselibre";
        }

        public override double calcularPagoFinal(Configuration config, int antiguedadSocio = 0)
        {
            double result = config.CostoFijo;

            if (antiguedadSocio > config.AntiguedadEstablecida)
            {
                result -= result * (config.DescuentoPaseLibre / 100);
            }

            //PrecioFinal = config.CostoFijo - config.CostoFijo * (descuentoPorc); 
            //PrecioFinal = config.CostoFijo - DescuentoSinPorc

            //DescuentoSinPorc = CostoFijo - PrecioFinal;

            //DescuentoSinPorc = config.CostoFijo * (descuentoPorc)


            return result;
        }

        public override decimal obtenerDescuento(Configuration config)
        {
            decimal costoTotal = (decimal)(config.CostoFijo);
            decimal descuento = Math.Abs(costoTotal - Precio);
            
            return Math.Round(descuento);
        }
    }
}
