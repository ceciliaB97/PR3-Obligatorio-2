using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IRepositorio<T>
    {
        int Alta(T t);
        bool Baja(int id);
        bool Modificacion(T t);
        T Buscar(int id);
        List<T> Listar();

    }
}
