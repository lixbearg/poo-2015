using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_paint

{
    public class Retangulo : Figura
    {
        private int plargura;
        private int paltura;
        static int pcontador;

        public Retangulo(int x, int y, int largura, int altura)
        {
            px = x;
            py = y;
            plargura = largura;
            paltura = altura;

            pcontador += 1;
        }

        public override string Imprime()
        {
            return "retangulo[x:" + px + ",y:" + py + ",l:" + plargura + ",a:" + paltura + "]";
        }

        public static void ZeraContador()
        {
            pcontador = 0;
        }

        public static int LeContador()
        {
            return pcontador;
        }
        
        public override void Desenha(Graphics g)
        {
            g.DrawRectangle(Pens.Black, px, py, plargura, paltura);
        }
    }
}
