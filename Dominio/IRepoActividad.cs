using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public interface IRepoActividad : IRepositorio<Actividad>
	{
		List<Horario> ListarHorariosActividad(int idActividad);
		ActividadSocio BuscarSocioActividad(int idSocio, int idActividad);
        Actividad Buscar(string nombre);
    }
}
