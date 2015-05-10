using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_paint
{
    public class Figura
    {
        protected int px;
        protected int py;

        public virtual string Imprime()
        {
            return "figura[x:" + px + ",y:" + py + "]";
        }
    }
}
