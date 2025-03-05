using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Életjáték
{
    internal class Kocka: Label
    {
        public static int méret = 20;
        public Kocka()
        {
            Height = méret;
            Width = méret;
            BackColor = Color.Fuchsia;
        }
    }
}
