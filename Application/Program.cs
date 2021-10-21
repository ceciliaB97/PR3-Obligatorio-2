using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Auxiliar;


namespace PruebasInterfacesN3BAgo2021
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositorioProductos repoProd = FabricaRepositorios.ObtenerRepoProductos();
            
            Producto p = repoProd.Buscar(5);
            if (p != null)
            {
                Console.WriteLine(p.Precio);
            }

            Console.ReadLine();
        }
    }
}
