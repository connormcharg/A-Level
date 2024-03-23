using SpaceSimulator.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Object = SpaceSimulator.classes.Object;
using Point = SpaceSimulator.classes.Point;

namespace SpaceSimulator
{
    public partial class frmMain : Form
    {
        public List<Object> objects;
        public Graphics g;
        public Bitmap bmp;
        public double timeScale;
        public int _frameCount = 0;
        public int _tickCount = 0;
        public DateTime _lastCheckTimeFps = DateTime.Now;
        public DateTime _lastCheckTimeTps = DateTime.Now;
        public List<Point> points;
        public int _TimeToLive = 10000;

        public frmMain()
        {
            InitializeComponent();

            bmp = new Bitmap(pbxFrame.Width, pbxFrame.Height);
            g = Graphics.FromImage(bmp);

            objects = new List<Object>();
            points = new List<Point>();
            timeScale = 10000;
            timeScale = 1 / timeScale;

            // // earth
            // objects.Add(new Object());
            // objects[0].Mass = 5.97 * Math.Pow(10, 24);
            // objects[0].Position[0] = -3 * Math.Pow(10, 7); objects[0].Position[1] = 0 * Math.Pow(10, 7);
            // objects[0].Acceleration[0] = 0; objects[0].Acceleration[1] = 0;
            // objects[0].Velocity[0] = 0; objects[0].Velocity[1] = -16000;
            // objects[0].Color = Brushes.Blue;

            // // moon
            // objects.Add(new Object());
            // objects[1].Mass = 7.35 * Math.Pow(10, 22);
            // //objects[1].Mass = 5.97 * Math.Pow(10, 24);
            // objects[1].Position[0] = -2.9 * Math.Pow(10, 7); objects[1].Position[1] = 0.1 * Math.Pow(10, 7);
            // objects[1].Acceleration[0] = 0; objects[1].Acceleration[1] = 0;
            // objects[1].Velocity[0] = -4000; objects[1].Velocity[1] = 0;
            // objects[1].Color = Brushes.Gray;
            // objects[1].Size[0] = 10; objects[1].Size[1] = 10;

            // // sun
            // objects.Add(new Object());
            // objects[2].Mass = 1.989 * Math.Pow(10, 26);
            // objects[2].Position[0] = 0; objects[2].Position[1] = 0;
            // objects[2].Acceleration[0] = 0; objects[2].Acceleration[1] = 0;
            // objects[2].Velocity[0] = 0; objects[2].Velocity[1] = 0;
            // objects[2].Color = Brushes.Yellow;
            // objects[2].Size[0] = 50; objects[2].Size[1] = 50;

            // // mars
            // objects.Add(new Object());
            // objects[3].Mass = 6.42 * Math.Pow(10, 23);
            // objects[3].Position[0] = 2.3 * Math.Pow(10, 7); objects[3].Position[1] = 0;
            // objects[3].Acceleration[0] = 0; objects[3].Acceleration[1] = 0;
            // objects[3].Velocity[0] = 0; objects[3].Velocity[1] = 24000;
            // objects[3].Color = Brushes.Red;
            // objects[3].Size[0] = 20; objects[3].Size[1] = 20;

            // // venus
            // objects.Add(new Object());
            // objects[4].Mass = 4.87 * Math.Pow(10, 24);
            // objects[4].Position[0] = 1.1 * Math.Pow(10, 7); objects[4].Position[1] = 0;
            // objects[4].Acceleration[0] = 0; objects[4].Acceleration[1] = 0;
            // objects[4].Velocity[0] = 0; objects[4].Velocity[1] = 35000;
            // objects[4].Color = Brushes.Orange;
            // objects[4].Size[0] = 15; objects[4].Size[1] = 15;

            // binary stars
            objects.Add(new Object());
            objects[0].Mass = 1.989 * Math.Pow(10, 25);
            objects[0].Position[0] = -2 * Math.Pow(10, 7); objects[0].Position[1] = 0;
            objects[0].Acceleration[0] = 0; objects[0].Acceleration[1] = 0;
            objects[0].Velocity[0] = 0; objects[0].Velocity[1] = -4063; // 4063
            objects[0].Color = Brushes.Yellow;
            objects[0].Size[0] = 50; objects[0].Size[1] = 50;

            objects.Add(new Object());
            objects[1].Mass = 1.989 * Math.Pow(10, 25);
            objects[1].Position[0] = 2 * Math.Pow(10, 7); objects[1].Position[1] = 0;
            objects[1].Acceleration[0] = 0; objects[1].Acceleration[1] = 0;
            objects[1].Velocity[0] = 0; objects[1].Velocity[1] = 4063;
            objects[1].Color = Brushes.Yellow;
            objects[1].Size[0] = 50; objects[1].Size[1] = 50;

            tmrPhysics.Interval = 10;
            tmrRender.Interval = 10;

            tmrPhysics.Start();
            tmrRender.Start();
        }

        private void tmrPhysics_Tick(object sender, EventArgs e)
        {
            // clear forces
            foreach (Object a in objects)
            {
                a.Forces.Clear();
            }

            // calculate forces
            foreach (Object a in objects)
            {
                foreach (Object b in objects)
                {
                    if (a != b)
                    {
                        a.Forces.Add(Calc.Gravitational(a, b));
                    }
                }
            }
            // calculate accelerations
            foreach (Object a in objects)
            {
                a.Acceleration = Calc.GetAcceleration(a);
            }
            // calculate velocities
            foreach (Object a in objects)
            {
                a.Velocity[0] += a.Acceleration[0] * (double)tmrPhysics.Interval / ((double)1000 * timeScale);
                a.Velocity[1] += a.Acceleration[1] * (double)tmrPhysics.Interval / ((double)1000 * timeScale);
            }
            // calculate positions
            foreach (Object a in objects)
            {
                a.Position[0] += a.Velocity[0] * (double)tmrPhysics.Interval / ((double)1000 * timeScale);
                a.Position[1] += a.Velocity[1] * (double)tmrPhysics.Interval / ((double)1000 * timeScale);
            }

            _tickCount += 1;
            if (_tickCount % 20 == 0)
            {
                lblTps.Text = $"{DisplayTps()} tps";
            }
        }

        private void tmrRender_Tick(object sender, EventArgs e)
        {
            // clear frame
            g.Clear(pbxFrame.BackColor);

            // draw objects
            foreach (Point point in points)
            {
                if (point.TimeToLive > 0)
                {
                    g.FillEllipse(Brushes.LimeGreen, (float)point.Position[0], (float)point.Position[1], 2, 2);
                    point.TimeToLive -= 1;
                }
            }
            foreach (Object a in objects)
            {
                float x = (float)a.Position[0] / (float)Calc._dConstant;
                x += pbxFrame.Width / 2;
                float y = -(float)a.Position[1] / (float)Calc._dConstant;
                y += pbxFrame.Height / 2;
                g.FillEllipse(a.Color, x - ((float)a.Size[0]/2f), y - ((float)a.Size[1]/2f), (float)a.Size[0], (float)a.Size[1]);
                points.Add(new Point(x, y, _TimeToLive));
            }

            // refresh frame
            pbxFrame.Invalidate();
            pbxFrame.Image = bmp;

            _frameCount += 1;
            if (_frameCount % 20 == 0)
            {
                lblFps.Text = $"{DisplayFps()} fps";
            }
        }

        private int DisplayFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTimeFps).TotalSeconds;
            double fps = _frameCount / secondsElapsed;
            _lastCheckTimeFps = DateTime.Now;
            _frameCount = 0;
            return (int)fps;
        }

        private int DisplayTps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTimeTps).TotalSeconds;
            double tps = _tickCount / secondsElapsed;
            _lastCheckTimeTps = DateTime.Now;
            _tickCount = 0;
            return (int)tps;
        }
    }
}
