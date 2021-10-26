using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IRepoUsuario
    {
        void Precarga();
        bool buscarLogin(string mail, string password);

        bool Alta(Usuario t);

        Usuario Buscar(int id);
    }
}
