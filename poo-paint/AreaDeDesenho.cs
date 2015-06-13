using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poo_paint
{
    public partial class AreaDeDesenho : Form
    {
        private static int qtdfiguras = 0;
        Figura[] figuras = new Figura[0];
        private int xinicial;
        private int yinicial;

        public AreaDeDesenho()
        {
            InitializeComponent();
        }

        public void AdicionaFigura(Figura f)
        {
            qtdfiguras++;
            Array.Resize(ref figuras, (qtdfiguras));
            figuras[qtdfiguras - 1] = f;
        }

        public void Desenha(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < this.figuras.Length; i++)
            {
                Figura f = new Figura();
                f = this.figuras[i];
                f.Desenha(g);
            }
        }

        private void DesenhaCliqueInicial(object sender, MouseEventArgs e)
        {
            xinicial = e.X;
            yinicial = e.Y;
        }

        private void DesenhaCliqueFinal(object sender, MouseEventArgs e)
        {
            if (e.X > xinicial)
            {                
                if (e.Y > yinicial)
                {
                    AdicionaFigura(new Retangulo(xinicial, yinicial, (e.X - xinicial), (e.Y - yinicial)));
                }
                else
                {
                    AdicionaFigura(new Retangulo(xinicial, e.Y, (e.X - xinicial), (yinicial - e.Y)));
                }
            }
            else
            {
                if (e.Y > yinicial)
                {
                    AdicionaFigura(new Retangulo(e.X, yinicial, (xinicial - e.X), (e.Y - yinicial)));
                }
                else
                {
                    AdicionaFigura(new Retangulo(e.X, e.Y, (xinicial - e.X), (yinicial - e.Y)));
                }
            }

            this.Invalidate();
        }
    }
}
