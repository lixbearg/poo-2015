using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_paint
{
    public class Circulo : Figura
    {
        private int praio;
        static int pcontador;

        public Circulo(int x, int y, int raio)
        {
            px = x;
            py = y;
            praio = raio;

            pcontador += 1;
        }

        public override string Imprime()
        {
            return "circulo[x:" + px + ",y:" + py + ",raio:" + praio + "]";
        }

        public static void ZeraContador()
        {
            pcontador = 0;
        }

        public static int LeContador()
        {
            return pcontador;
        }
    }
}
