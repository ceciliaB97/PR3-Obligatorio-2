using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public interface IRepoSocios : IRepositorio<Socio>
	{
		Socio BuscarPorCedula(decimal cedulaSocio);
		int IngresarActividadSocio(int idSocio, Actividad actividad,DateTime dateTime);
		List<Membresia> ListarSocioMembresia();
		List<SocioActividad> ListarSocioActividad();
	}
	
}
