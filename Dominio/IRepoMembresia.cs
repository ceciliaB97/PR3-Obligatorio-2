using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public interface IRepoMembresia : IRepositorio<Membresia>
	{
		// List<Producto> ProductosEnRangoDePrecio(decimal desde, decimal hasta);

		int Alta(int idSocio, Membresia t);
        List<Membresia> ListarPorSocioId(int idSocio);
        bool ModificarFechaPagoHoy(Membresia m);
        List<Membresia> ListarPorMesAnio(int month, int year);
    }
}
