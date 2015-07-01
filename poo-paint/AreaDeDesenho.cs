using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private bool desenhando = false;
        private string desenhos = "";

        public AreaDeDesenho()
        {
            InitializeComponent();
            comboxFerramenta.Items.Add("Retangulo");
            comboxFerramenta.Items.Add("Circulo");
            comboxFerramenta.Items.Add("Linha");

            comboxFerramenta.SelectedIndex = 0;
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
                desenhos += f.GeraLinhaArquivo();
                desenhos += Environment.NewLine;
            }
        }

        private void DesenhaCliqueInicial(object sender, MouseEventArgs e)
        {
            xinicial = e.X;
            yinicial = e.Y;
            desenhando = true;
        }

        private void DesenhaCliqueFinal(object sender, MouseEventArgs e)
        {
            if (comboxFerramenta.SelectedIndex == 0)
            {
                DesenhaCliqueRetangulo(e.X, e.Y);
            }
            else if (comboxFerramenta.SelectedIndex == 1)
            {
                DesenhaCliqueCirculo(e.X, e.Y);
            }
            else if (comboxFerramenta.SelectedIndex == 2)
            {
                DesenhaCliqueLinha(e.X, e.Y);
            }

            desenhando = false;
        }

        private void DesenhaCliqueRetangulo(int xfinal, int yfinal)
        {
            if (xfinal > xinicial)
            {
                if (yfinal > yinicial)
                {
                    AdicionaFigura(new Retangulo(xinicial, yinicial, (xfinal - xinicial), (yfinal - yinicial)));
                }
                else
                {
                    AdicionaFigura(new Retangulo(xinicial, yfinal, (xfinal - xinicial), (yinicial - yfinal)));
                }
            }
            else
            {
                if (yfinal > yinicial)
                {
                    AdicionaFigura(new Retangulo(xfinal, yinicial, (xinicial - xfinal), (yfinal - yinicial)));
                }
                else
                {
                    AdicionaFigura(new Retangulo(xfinal, yfinal, (xinicial - xfinal), (yinicial - yfinal)));
                }
            }
            this.Invalidate();
        }

        private void DesenhaCliqueCirculo(int xfinal, int yfinal)
        {
            if (xfinal > xinicial)
            {
                if (yfinal > yinicial)
                {
                    AdicionaFigura(new Circulo(xinicial, yinicial, ((xfinal - xinicial) / 2)));
                }
                else
                {
                    AdicionaFigura(new Circulo(xinicial, yfinal, (xfinal - xinicial) / 2));
                }
            }
            else
            {
                if (yfinal > yinicial)
                {
                    AdicionaFigura(new Circulo(xfinal, yinicial, (xinicial - xfinal) / 2));
                }
                else
                {
                    AdicionaFigura(new Circulo(xfinal, yfinal, (xinicial - xfinal) / 2));
                }
            }

            this.Invalidate();
        }

        private void DesenhaCliqueLinha(int xfinal, int yfinal)
        {
            AdicionaFigura(new Linha(xinicial, yinicial, xfinal, yfinal));
            this.Invalidate();
        }

        private void DesenhaMove(object sender, MouseEventArgs e)
        {
            //if ((desenhando == true) & (comboxFerramenta.SelectedIndex == 0))
            //{
            //    DesenhaCliqueRetangulo(e.X, e.Y);
            //}
            //else if ((desenhando == true) & (comboxFerramenta.SelectedIndex == 1))
            //{
            //    DesenhaCliqueCirculo(e.X, e.Y);
            //}
            //else if ((desenhando == true) & (comboxFerramenta.SelectedIndex == 2))
            //{
            //    DesenhaCliqueLinha(e.X, e.Y);
            //}
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirdialog = new OpenFileDialog();
            abrirdialog.Filter = "Arquivos de Texto|*.txt";
            abrirdialog.Title = "Selecione um arquivo para abrir";

            if (abrirdialog.ShowDialog() == DialogResult.OK)
            {
                string linhaArquivo, caminho = abrirdialog.FileName;
                StreamReader stream = new StreamReader(caminho);
                int p1, p2, p3, p4;
                try
                {
                    figuras = new Figura[0];
                    qtdfiguras = 0;
                    while ((linhaArquivo = stream.ReadLine()) != null)
                    {
                        switch (linhaArquivo)
                        {
                            case "Retangulo":
                                p1 = Convert.ToInt32(stream.ReadLine());
                                p2 = Convert.ToInt32(stream.ReadLine());
                                p3 = Convert.ToInt32(stream.ReadLine());
                                p4 = Convert.ToInt32(stream.ReadLine());
                                AdicionaFigura(new Retangulo(p1, p2, p3, p4));
                                break;
                            case "Circulo":
                                p1 = Convert.ToInt32(stream.ReadLine());
                                p2 = Convert.ToInt32(stream.ReadLine());
                                p3 = Convert.ToInt32(stream.ReadLine());
                                AdicionaFigura(new Circulo(p1, p2, p3));
                                break;
                            case "Linha":
                                p1 = Convert.ToInt32(stream.ReadLine());
                                p2 = Convert.ToInt32(stream.ReadLine());
                                p3 = Convert.ToInt32(stream.ReadLine());
                                p4 = Convert.ToInt32(stream.ReadLine());
                                AdicionaFigura(new Linha(p1, p2, p3, p4));
                                break;
                            default:
                                throw new Exception();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("O arquivo selecionado é inválido.", "Erro");
                }
                finally
                {
                    this.Invalidate();
                    stream.Close();
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SaveFileDialog salvardialog = new SaveFileDialog();
            salvardialog.Filter = "Arquivo de texto|*.txt";
            salvardialog.FileName = "Desenho";
            salvardialog.Title = "Salvar desenhos";
            if (salvardialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string caminho = salvardialog.FileName;
                StreamWriter stream = new StreamWriter(File.Create(caminho));
                stream.Write(desenhos);
                stream.Dispose();
            }
        }
    }
}
