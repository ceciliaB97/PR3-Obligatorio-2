using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class ActividadSocioIngresosDTO
    {
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; }
        public DateTime IngresoOriginal { set; get; }
       // public string Dia { get; set; }
        public string NombreSocio { get; set; }
        public int CedulaSocio { get; set; }

        public int Hora { get; set; }

    }
}
