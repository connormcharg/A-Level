using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenderingV2
{
    public partial class frmMain : Form
    {
        Bitmap image {  get; set; }
        Graphics g { get; set; }
        int x { get; set; }
        int y { get; set; }
        int[] d { get; set; }
        long _frameCount { get; set; }
        DateTime _lastCheckTime = DateTime.Now;
        Rectangle _right;
        Rectangle _left;
        Rectangle _top;
        Rectangle _bottom;

        public frmMain()
        {
            InitializeComponent();
            image = new Bitmap(this.Width, this.Height);
            pbxFrame.BackgroundImage = image;
            pbxFrame.BackColor = Color.Black;
            g = Graphics.FromImage(image);
            _right = new Rectangle(pbxFrame.Width - 1, 0, 1, image.Height - 1);
            _left = new Rectangle(0, 0, 1, image.Height - 1);
            _top = new Rectangle(0, 0, image.Width - 1, 1);
            _bottom = new Rectangle(0, pbxFrame.Height - 1, image.Width - 1, 1);
            x = 20; y = 50; d = new int[2];
            d[0] = 1;
            d[1] = 0;

            this.KeyDown += readKey;
        }

        private void readKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    d[1] = -1; break;
                case Keys.Down:
                    d[1] = 1; break;
                case Keys.Left:
                    d[0] = -1; break;
                case Keys.Right:
                    d[0] = 1; break;
            }
        }

        private int onEdge(Rectangle r)
        {
            if (r.IntersectsWith(_left))
            {
                return 1;
            }
            if (r.IntersectsWith(_right))
            {
                return 2;
            }
            if (r.IntersectsWith(_top))
            {
                return 3;
            }
            if (r.IntersectsWith(_bottom))
            {
                return 4;
            }
            return 0;
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            g.Clear(pbxFrame.BackColor);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Rectangle eRect = new Rectangle(x, y, 25, 25);
            g.FillEllipse(redBrush, eRect);
            
            int i = onEdge(eRect);

            if (i == 1) // hit left
            {
                d[0] = 1;
            }
            else if (i == 2) // hit right
            {
                d[0] = -1;
            }
            else if (i == 3) // hit top
            {
                d[1] = 1;
            }
            else if (i == 4) // hit bottom
            {
                d[1] = -1;
            }

            pbxFrame.Invalidate();
            pbxFrame.Image = image;

            x += 10 * d[0];
            y += 10 * d[1];
            _frameCount += 1;
            if (_frameCount % 20 == 0)
            {
                lblFPS.Text = $"{DisplayFps()} fps";
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            g.Dispose();
            image.Dispose();
        }

        private int DisplayFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            double fps = _frameCount / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            _frameCount = 0;
            return (int)fps;
        }
    }
}
