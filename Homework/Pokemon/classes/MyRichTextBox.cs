using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PokeGame
{
    public class MyRichTextBox : RichTextBox
    {
        private int[] bad = { 0x0201, 0x0203, 0x0202, 0x0209, 0x0207, 0x0208, 0x0206, 0x0204, 0x0205 };
        public string nameText = "";

        protected override void WndProc(ref Message m)
        {
            if (bad.Contains(m.Msg))
            {
                return;
            }
            base.WndProc(ref m);
        }

        public void AppendText(string text, Color color)
        {
            this.SelectionStart = this.TextLength;
            this.SelectionLength = 0;
            this.SelectionColor = color;
            this.AppendText(text);
            this.SelectionColor = this.ForeColor;
        }
    }
}
