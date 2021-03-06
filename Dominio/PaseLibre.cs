using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dominio
{
    [Table("PaseLibre")]
    public class PaseLibre : Membresia
    {
        public static int TopeAntiguedadParaDescuento { get { return TopeAntiguedadParaDescuento; } set { TopeAntiguedadParaDescuento = 7; } }
        public static int PorcentajeDescuento { get { return PorcentajeDescuento; } set { PorcentajeDescuento = 30; } }
        public static decimal PrecioFijoPorMes { get { return PrecioFijoPorMes; } set { PrecioFijoPorMes = 800; } }
        public override decimal CalcularPrecio()
        {
            if (Socio.CalcularAntiguedad() > TopeAntiguedadParaDescuento)
            {
                return PrecioFijoPorMes * PorcentajeDescuento / 100;
            }
            else
            {
                return PrecioFijoPorMes;
            }

        }
    }
}
