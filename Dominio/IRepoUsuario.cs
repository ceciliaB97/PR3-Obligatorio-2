using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IRepoUsuario : IRepositorio<Usuario>
    {
        int buscarLogin(string mail, string password);
	}
}
