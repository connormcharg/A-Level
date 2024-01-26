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
        long _frameCount { get; set; }
        DateTime _lastCheckTime = DateTime.Now;

        public frmMain()
        {
            InitializeComponent();
            image = new Bitmap(this.Width, this.Height);
            this.BackgroundImage = image;
            g = Graphics.FromImage(image);
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    image.SetPixel(j, i, Color.Aqua);
                }
            }
            g.DrawEllipse(new Pen(Color.Blue), new Rectangle(x, 50, 200, 100));
            this.BackgroundImage = image;
            this.Refresh();
            x += 10;
            _frameCount += 1;
            lblFPS.Text = $"{DisplayFps()} fps";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            g.Dispose();
            image.Dispose();
        }

        private double DisplayFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            double fps = _frameCount / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            _frameCount = 0;
            return fps;
        }
    }
}
