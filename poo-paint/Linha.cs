using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_paint
{
    class Linha : Figura
    {

        private int xinicial;
        private int yinicial;
        private int xfinal;
        private int yfinal;

        public Linha(int xini, int yini, int xfin, int yfin)
        {
            xinicial = xini;
            yinicial = yini;
            xfinal = xfin;
            yfinal = yfin;
        }

        public override string GeraLinhaArquivo()
        {
            return "Linha\r\n" + xinicial + "\r\n" + yinicial + "\r\n" + xfinal + "\r\n" + yfinal;
        }

        public override void Desenha(Graphics g)
        {
            g.DrawLine(Pens.Black, xinicial, yinicial, xfinal, yfinal);
        }
    }

}
