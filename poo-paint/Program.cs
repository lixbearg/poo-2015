using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_paint
{
    class Program
    {
        static void Main(string[] args)
        {
            Retangulo retangulo1 = new Retangulo(34, 20, 300, 40);
            Console.WriteLine(retangulo1.Imprime());
            Console.ReadKey();
        }
    }    
}
