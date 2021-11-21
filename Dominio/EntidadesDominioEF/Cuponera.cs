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
    //[Table("Cuponeras")]
    public class Cuponera : Membresia
    {
        [Required, Range(8,60)]
        public int CantActividades { get; set; }
        public Cuponera()
		{
            TipoMembresia = "cuponera";
        }
        public Cuponera(int cantingresos) : base()
        {
            CantActividades = cantingresos;
      
        }


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

		public override decimal obtenerDescuento(Configuration config)
		{
            decimal costoTotal =  (decimal)(config.MontoUnitarioCuponera * CantActividades);
            //Price = Costo - Descuento

            decimal descuento = Math.Abs(costoTotal - Precio)/Precio;

            return Math.Round(descuento*100);
		}
	}
}
